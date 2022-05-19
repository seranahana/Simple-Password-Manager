using System;
using SimplePM.Library.Cryptography;

namespace SimplePM.Library.Models
{
    internal class UserData
    {
        internal string ID { get; set; }
        internal string Login { get; set; }
        internal string Password { get; set; }
        internal string Salt { get; set; }
        internal string MasterPassword { get; set; }
        internal string MasterSalt { get; set; }

        internal UserData()
        {
        }

        internal UserData(string login, string password, string masterPassword)
        {
            Login = login;
            Password = password;
            MasterPassword = masterPassword;
        }

        internal UserData(string id, string masterPassword)
        {
            ID = id;
            MasterPassword = masterPassword;
        }

        internal void Decontructor(out string id, out string masterPassword, out string masterSalt)
        {
            id = ID;
            masterPassword = MasterPassword;
            masterSalt = MasterSalt;
        }

        /// <summary>
        /// Encrypts all data in instance that is not null with RSA public key
        /// </summary>
        /// <param name="rsaOpenKey">RSA public key</param>
        /// <exception cref="ArgumentNullException">RSA public key is null</exception>
        /// <exception cref="System.Security.Cryptography.CryptographicException"></exception>
        internal void EncryptPrivateData(string rsaPublicKey)
        {
            if (rsaPublicKey is null)
            {
                throw new ArgumentNullException(nameof(rsaPublicKey));
            }
            if (Login is not null)
            {
                string encryptedLogin = CryptographyProvider.RSA.Encrypt(Login, rsaPublicKey);
                Login = encryptedLogin;
            }
            if (Password is not null)
            {
                string encryptedPassword = CryptographyProvider.RSA.Encrypt(Password, rsaPublicKey);
                Password = encryptedPassword;
            }
            if (Salt is not null)
            {
                string encryptedSalt = CryptographyProvider.RSA.Encrypt(Salt, rsaPublicKey);
                Salt = encryptedSalt;
            }
            if (MasterPassword is not null)
            {
                string encryptedMasterPassword = CryptographyProvider.RSA.Encrypt(MasterPassword, rsaPublicKey);
                MasterPassword = encryptedMasterPassword;
            }
            if (MasterSalt is not null)
            {
                string encryptedMasterSalt = CryptographyProvider.RSA.Encrypt(MasterSalt, rsaPublicKey);
                MasterSalt = encryptedMasterSalt;
            }
        }
    }
}
