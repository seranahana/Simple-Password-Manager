using Newtonsoft.Json;
using SimplePM.Library.Cryptography;
using SimplePM.Library.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimplePM.Library.Networking
{
    public class UserDataSyncProvider
    {
        /// <summary>
        /// Performs request to check if login is already occupied
        /// </summary>
        /// <param name="login">Desirable login</param>
        /// <returns>True - if login is available, false - if it's not</returns>
        /// <exception cref="ArgumentNullException">The login parameter is null or whitespace</exception>
        /// <exception cref="HttpRequestException">The request failed due to an underlying issue or was rejected by server</exception>
        /// <exception cref="InvalidOperationException">The request message was already sent by the System.Net.Http.HttpClient instance.</exception>
        /// <exception cref="System.Security.Cryptography.CryptographicException">
        /// The cryptographic service provider (CSP) cannot be acquired. 
        /// -or- The length of the login parameter is greater than the maximum allowed length. 
        /// -or- OAEP padding is not supported.</exception>
        public static async Task<bool> CheckLoginAvailabilityAsync(string login)
        {
            if (string.IsNullOrWhiteSpace(login))
            {
                throw new ArgumentNullException(nameof(login));
            }
            HttpResponseResult rsaResponse = await HttpProvider.CreateAndSend<string>(HttpMethod.Get, ServiceType.RSA);
            if (!rsaResponse.IsSuccessfull)
            {
                throw new HttpRequestException(rsaResponse.ResponseMessage);
            }
            string rsaPublicKey = rsaResponse.ResponseMessage;
            string encryptedLogin = CryptographyProvider.RSA.Encrypt(login, rsaPublicKey);
            Dictionary<string, string> headers = new Dictionary<string, string>
            {
                { "encryptedLogin", encryptedLogin }
            };
            HttpResponseResult response = await HttpProvider.CreateAndSend<string>(HttpMethod.Get, ServiceType.Accounts, "login/availability", null, headers);
            if (response.IsSuccessfull)
            {
                return bool.Parse(response.ResponseMessage);
            }
            else
            {
                throw new HttpRequestException(rsaResponse.ResponseMessage);
            }
        }

        /// <summary>
        /// Performs request to register new user account.
        /// </summary>
        /// <param name="data">Full new user account data without identificator</param>
        /// <returns>New user account identificator as string</returns>
        /// <exception cref="ArgumentNullException">The login, password or masterPassword parameters is null or whitespace</exception>
        /// <exception cref="HttpRequestException">The request failed due to an underlying issue or was rejected by server</exception>
        /// <exception cref="InvalidOperationException">The request message was already sent by the System.Net.Http.HttpClient instance.</exception>
        /// <exception cref="System.Security.Cryptography.CryptographicException">
        /// The cryptographic service provider (CSP) cannot be acquired. 
        /// -or- The length of the login parameter is greater than the maximum allowed length. 
        /// -or- OAEP padding is not supported.</exception>
        /// POST
        /// ServiceType.Accounts, FromBody: UserData newData
        public static async Task<string> RegisterAsync(string login, string password, string masterPassword)
        {
            HttpResponseResult rsaResponse = await HttpProvider.CreateAndSend<string>(HttpMethod.Get, ServiceType.RSA);
            if (!rsaResponse.IsSuccessfull)
            {
                throw new HttpRequestException(rsaResponse.ResponseMessage);
            }
            string rsaPublicKey = rsaResponse.ResponseMessage;
            UserData data = new UserData(login, password, masterPassword);
            data.EncryptPrivateData(rsaPublicKey);
            HttpResponseResult response = await HttpProvider.CreateAndSend(HttpMethod.Post, ServiceType.Accounts, null, data);
            if (response.IsSuccessfull)
            {
                UserData userLoginData = JsonConvert.DeserializeObject<UserData>(response.ResponseMessage);
                return userLoginData.ID;
            }
            else
            {
                throw new HttpRequestException(response.ResponseMessage);
            }
        }

        /// <summary>
        /// Performs request to authorize existing user account.
        /// </summary>
        /// <param name="login">User Account login</param>
        /// <param name="password">User Account password</param>
        /// <returns>Tuple where: ID - user unique identificator, MasterPassword - salted and hashed master password, MasterSalt - salt</returns>
        /// <exception cref="ArgumentException">Login or password were rejected by server as incorrect</exception>
        /// <exception cref="ArgumentNullException">The login or password parameters is null or whitespace</exception>
        /// <exception cref="HttpRequestException">The request failed due to an underlying issue or was rejected by server</exception>
        /// <exception cref="InvalidOperationException">The request message was already sent by the System.Net.Http.HttpClient instance.</exception>
        /// <exception cref="System.Security.Cryptography.CryptographicException">
        /// The cryptographic service provider (CSP) cannot be acquired. 
        /// -or- The length of the login or password parameters is greater than the maximum allowed length. 
        /// -or- OAEP padding is not supported.</exception>
        /// GET
        /// ServiceType.Accounts, FromHeader: string login, FromHeader: string password
        public static async Task<(string ID, string MasterPassword, string MasterSalt)> AuthorizeAsync(string login, string password)
        {
            if (String.IsNullOrWhiteSpace(login))
            {
                throw new ArgumentNullException(nameof(login));
            }
            if (String.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentNullException(nameof(password));
            }
            HttpResponseResult rsaResponse = await HttpProvider.CreateAndSend<string>(HttpMethod.Get, ServiceType.RSA);
            if (!rsaResponse.IsSuccessfull)
            {
                throw new HttpRequestException(rsaResponse.ResponseMessage);
            }
            string rsaPublicKey = rsaResponse.ResponseMessage;
            // Encrypting entered password with retrieved Public key and sending it to remote server
            string encryptedLogin = CryptographyProvider.RSA.Encrypt(login, rsaPublicKey);
            string encryptedPassword = CryptographyProvider.RSA.Encrypt(password, rsaPublicKey);
            Dictionary<string, string> headers = new Dictionary<string, string>
            {
                {"encryptedLogin",  encryptedLogin},
                {"encryptedPassword", encryptedPassword}
            };
            HttpResponseResult response = await HttpProvider.CreateAndSend<string>(HttpMethod.Get, ServiceType.Accounts, null, null, headers);
            if (response.IsSuccessfull)
            {
                UserData userLoginData = JsonConvert.DeserializeObject<UserData>(response.ResponseMessage);
                userLoginData.Decontructor(out string id, out string masterPassword, out string masterSalt);
                return (id, masterPassword, masterSalt);
            }
            else
            {
                if (response.ResponseMessage.Contains("encryptedLogin"))
                {
                    throw new ArgumentException(nameof(login));
                }
                if (response.ResponseMessage.Contains("encryptedPassword"))
                {
                    throw new ArgumentException(nameof(password));
                }
                throw new HttpRequestException(response.ResponseMessage);
            }
        }

        /// <summary>
        /// Performs request to change user account login
        /// </summary>
        /// <param name="accountID">User account identificator</param>
        /// <param name="newLogin">User's new login</param>
        /// <param name="currentPassword">Current user account password</param>
        /// <exception cref="ArgumentException">Entered login is already occupied</exception>
        /// <exception cref="ArgumentNullException">One of the parameters is null or whitespace</exception>
        /// <exception cref="HttpRequestException">The request failed due to an underlying issue or was rejected by server</exception>
        /// <exception cref="InvalidOperationException">The request message was already sent by the System.Net.Http.HttpClient instance.</exception>
        /// <exception cref="System.Security.Cryptography.CryptographicException">
        /// The cryptographic service provider (CSP) cannot be acquired. 
        /// -or- The length of the login or password parameters is greater than the maximum allowed length. 
        /// -or- OAEP padding is not supported.</exception>
        /// PATCH
        /// ServiceType.Accounts, FromBody: updatedData, FromHeader: string encryptedCurrentPassword
        public static async Task ChangeAccountLoginAsync(string accountID, string newLogin, string currentPassword)
        {
            if (String.IsNullOrWhiteSpace(accountID))
            {
                throw new ArgumentNullException(nameof(accountID));
            }
            if (String.IsNullOrWhiteSpace(newLogin))
            {
                throw new ArgumentNullException(nameof(newLogin));
            }
            if (String.IsNullOrWhiteSpace(currentPassword))
            {
                throw new ArgumentNullException(nameof(currentPassword));
            }
            if (!await CheckLoginAvailabilityAsync(newLogin))
            {
                throw new ArgumentException(nameof(newLogin));
            }
            HttpResponseResult rsaResponse = await HttpProvider.CreateAndSend<string>(HttpMethod.Get, ServiceType.RSA);
            if (!rsaResponse.IsSuccessfull)
            {
                throw new HttpRequestException(rsaResponse.ResponseMessage);
            }
            string rsaPublicKey = rsaResponse.ResponseMessage;
            string encryptedNewLogin = CryptographyProvider.RSA.Encrypt(newLogin, rsaPublicKey);
            string encryptedCurrentPassword = CryptographyProvider.RSA.Encrypt(currentPassword, rsaPublicKey);
            Dictionary<string, string> headers = new Dictionary<string, string>
            {
                {"accountID", accountID },
                {"encryptedNewLogin", encryptedNewLogin },
                {"encryptedCurrentPassword", encryptedCurrentPassword}
            };
            HttpResponseResult response = await HttpProvider.CreateAndSend<string>(new HttpMethod("PATCH"), ServiceType.Accounts, null, null, headers);
            if (!response.IsSuccessfull)
            {
                throw new HttpRequestException(response.ResponseMessage);
            }
        }

        /// <summary>
        /// Performs request to change user account password
        /// </summary>
        /// <param name="accountID">User account identificator</param>
        /// <param name="newPassword">New password</param>
        /// <param name="currentPassword">Current account password</param>
        /// <exception cref="ArgumentNullException">One of the parameters is null or whitespace</exception>
        /// <exception cref="HttpRequestException">The request failed due to an underlying issue or was rejected by server</exception>
        /// <exception cref="InvalidOperationException">The request message was already sent by the System.Net.Http.HttpClient instance.</exception>
        /// <exception cref="System.Security.Cryptography.CryptographicException">
        /// The cryptographic service provider (CSP) cannot be acquired. 
        /// -or- The length of the login or password parameters is greater than the maximum allowed length. 
        /// -or- OAEP padding is not supported.</exception>
        /// PATCH
        /// ServiceType.Accounts, FromBody: updatedData, FromHeader: string encryptedCurrentPassword
        public static async Task ChangeAccountPasswordAsync(string accountID, string newPassword, string currentPassword)
        {
            if (String.IsNullOrWhiteSpace(accountID))
            {
                throw new ArgumentNullException(nameof(accountID));
            }
            if (String.IsNullOrWhiteSpace(newPassword))
            {
                throw new ArgumentNullException(nameof(newPassword));
            }
            if (String.IsNullOrWhiteSpace(currentPassword))
            {
                throw new ArgumentNullException(nameof(currentPassword));
            }
            HttpResponseResult rsaResponse = await HttpProvider.CreateAndSend<string>(HttpMethod.Get, ServiceType.RSA);
            if (!rsaResponse.IsSuccessfull)
            {
                throw new HttpRequestException(rsaResponse.ResponseMessage);
            }
            string rsaPublicKey = rsaResponse.ResponseMessage;
            string encryptedNewPassword = CryptographyProvider.RSA.Encrypt(newPassword, rsaPublicKey);
            string encryptedCurrentPassword = CryptographyProvider.RSA.Encrypt(currentPassword, rsaPublicKey);
            Dictionary<string, string> headers = new Dictionary<string, string>
            {
                {"accountID", accountID },
                {"encryptedNewPassword", encryptedNewPassword },
                {"encryptedCurrentPassword", encryptedCurrentPassword}
            };
            HttpResponseResult response = await HttpProvider.CreateAndSend<string>(new HttpMethod("PATCH"), ServiceType.Accounts, null, null, headers);
            if (!response.IsSuccessfull)
            {
                throw new HttpRequestException(response.ResponseMessage);
            }
        }

        /// <summary>
        /// Performs request to delete user account
        /// </summary>
        /// <param name="accountID">User account identificator</param>
        /// <param name="password">Current account password</param>
        /// <exception cref="ArgumentNullException">The accountID or password parameters is null or whitespace</exception>
        /// <exception cref="HttpRequestException">The request failed due to an underlying issue or was rejected by server</exception>
        /// <exception cref="InvalidOperationException">The request message was already sent by the System.Net.Http.HttpClient instance.</exception>
        /// <exception cref="System.Security.Cryptography.CryptographicException">
        /// The cryptographic service provider (CSP) cannot be acquired. 
        /// -or- The length of the login or password parameters is greater than the maximum allowed length. 
        /// -or- OAEP padding is not supported.</exception>
        /// DELETE
        /// ServiceType.Accounts, AdditionToURI: accountID, FromHeader: string encryptedPassword
        public static async Task DeleteAccountAsync(string accountID, string password)
        {
            if (string.IsNullOrWhiteSpace(accountID))
            {
                throw new ArgumentNullException(nameof(accountID));
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentNullException(nameof(password));
            }
            HttpResponseResult rsaResponse = await HttpProvider.CreateAndSend<string>(HttpMethod.Get, ServiceType.RSA);
            if (!rsaResponse.IsSuccessfull)
            {
                throw new HttpRequestException(rsaResponse.ResponseMessage);
            }
            string rsaPublicKey = rsaResponse.ResponseMessage;
            string encryptedPassword = CryptographyProvider.RSA.Encrypt(password, rsaPublicKey);
            Dictionary<string, string> headers = new Dictionary<string, string>
            {
                {"accountID",  accountID},
                {"encryptedPassword", encryptedPassword}
            };
            HttpResponseResult response = await HttpProvider.CreateAndSend<string>(HttpMethod.Delete, ServiceType.Accounts, accountID, null, headers);
            if (!response.IsSuccessfull)
            {
                throw new HttpRequestException(response.ResponseMessage);
            }
        }

        /// <summary>
        /// Retrieves master password in salted and hashed form from remote server and assigned salt.
        /// </summary>
        /// <param name="accountID">Existing user account identificator</param>
        /// <exception cref="ArgumentNullException">The accountID parameter is null or whitespace</exception>
        /// <exception cref="HttpRequestException">The request failed due to an underlying issue or was rejected by server</exception>
        /// <exception cref="InvalidOperationException">The request message was already sent by the System.Net.Http.HttpClient instance.</exception>
        /// <returns>Returns pair of master password and it's salt as Tuple<string, string> or HttpRequestException if request was not successfull</returns>
        /// GET
        /// ServiceType.MasterPassword, Inside URI: accountID
        public static async Task<(string MasterPassword, string MasterSalt)> GetMasterPasswordAsync(string accountID)
        {
            if (String.IsNullOrWhiteSpace(accountID))
            {
                throw new ArgumentNullException(nameof(accountID));
            }
            HttpResponseResult response = await HttpProvider.CreateAndSend<string>(HttpMethod.Get, ServiceType.MasterPassword);
            if (response.IsSuccessfull)
            {
                UserData masterPassData = JsonConvert.DeserializeObject<UserData>(response.ResponseMessage);
                return (masterPassData.MasterPassword, masterPassData.MasterSalt);
            }
            else
            {
                throw new HttpRequestException(response.ResponseMessage);
            }
        }

        /// <summary>
        /// Saltes and hashes master password and upload it to server. 
        /// Current master password is required for authorize.
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="newMasterPassword">New master password</param>
        /// <param name="saltedAndHashedCurrentMasterPass">Current master password</param>
        /// <exception cref="ArgumentNullException">The accountID, saltedAndHashedCurrentMasterPass or new MasterPass parameters is null</exception>
        /// <exception cref="HttpRequestException">The request failed due to an underlying issue or was rejected by server</exception>
        /// <exception cref="InvalidOperationException">The request message was already sent by the System.Net.Http.HttpClient instance.</exception>
        /// POST
        /// ServiceType.MasterPassword, FromHeader: string encryptedOldMasterPass, FromBody: MasterPassData updatedData
        public static async Task UploadMasterPasswordAsync(string accountID, string currentMasterPass, string newMasterPass)
        {
            if (String.IsNullOrWhiteSpace(accountID))
            {
                throw new ArgumentNullException(nameof(accountID));
            }
            if (String.IsNullOrWhiteSpace(currentMasterPass))
            {
                throw new ArgumentNullException(nameof(currentMasterPass));
            }
            if (String.IsNullOrWhiteSpace(newMasterPass))
            {
                throw new ArgumentNullException(nameof(newMasterPass));
            }
            HttpResponseResult rsaResponse = await HttpProvider.CreateAndSend<string>(HttpMethod.Get, ServiceType.RSA);
            if (!rsaResponse.IsSuccessfull)
            {
                throw new HttpRequestException(rsaResponse.ResponseMessage);
            }
            string rsaPublicKey = rsaResponse.ResponseMessage;
            string encryptedCurrentMasterPass = CryptographyProvider.RSA.Encrypt(currentMasterPass, rsaPublicKey);
            UserData updatedData = new UserData(accountID, newMasterPass);
            updatedData.EncryptPrivateData(rsaPublicKey);
            Dictionary<string, string> headers = new Dictionary<string, string>
            {
                { "encryptedCurrentMasterPass", encryptedCurrentMasterPass }
            };
            HttpResponseResult response = await HttpProvider.CreateAndSend(HttpMethod.Post, ServiceType.MasterPassword, null, updatedData, headers);
            if (!response.IsSuccessfull)
            {
                throw new HttpRequestException(response.ResponseMessage);
            }
        }

        public static async Task<(string NewMasterPassword, string NewSalt)> ResetMasterPasswordAsync(string login, string password, string newMasterPassword)
        {
            if (String.IsNullOrWhiteSpace(login))
            {
                throw new ArgumentNullException(nameof(login));
            }
            if (String.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentNullException(nameof(password));
            }
            if (String.IsNullOrWhiteSpace(newMasterPassword))
            {
                throw new ArgumentNullException(nameof(newMasterPassword));
            }
            HttpResponseResult rsaResponse = await HttpProvider.CreateAndSend<string>(HttpMethod.Get, ServiceType.RSA);
            if (!rsaResponse.IsSuccessfull)
            {
                throw new HttpRequestException(rsaResponse.ResponseMessage);
            }
            string rsaPublicKey = rsaResponse.ResponseMessage;
            string encryptedLogin = CryptographyProvider.RSA.Encrypt(login, rsaPublicKey);
            string encryptedPassword = CryptographyProvider.RSA.Encrypt(password, rsaPublicKey);
            string encryptedNewMasterPassword = CryptographyProvider.RSA.Encrypt(newMasterPassword, rsaPublicKey);
            Dictionary<string, string> headers = new Dictionary<string, string>
            {
                { "encryptedLogin", encryptedLogin },
                { "encryptedPassword", encryptedPassword },
                { "encryptedNewMasterPassword", encryptedNewMasterPassword }
            };
            HttpResponseResult response = await HttpProvider.CreateAndSend<string>(HttpMethod.Post, ServiceType.MasterPassword, "reset", null, headers);
            if (response.IsSuccessfull)
            {
                UserData masterPassData = JsonConvert.DeserializeObject<UserData>(response.ResponseMessage);
                return (masterPassData.MasterPassword, masterPassData.MasterSalt);
            }
            else
            {
                throw new HttpRequestException(response.ResponseMessage);
            }
        }
    }
}
