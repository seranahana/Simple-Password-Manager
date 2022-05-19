using SimplePM.Library.Cryptography;

namespace SimplePM
{
    internal static class SettingsProcessor
    {
        internal static void UpdateFirstRunStatus(bool isFirstRun)
        {
            Properties.Settings.Default.IsFirstRun = isFirstRun;
            Properties.Settings.Default.Save();
        }

        internal static void UpdateSignedInStatus(bool isSignedIn)
        {
            Properties.Settings.Default.IsSignedIn = isSignedIn;
            Properties.Settings.Default.Save();
        }

        internal static void UpdateResetStatus(bool isReset)
        {
            Properties.Settings.Default.IsReset = isReset;
            Properties.Settings.Default.Save();
        }

        internal static void UpdateAccountID(string id)
        {
            Properties.Settings.Default.AccountID = id;
            Properties.Settings.Default.Save();
        }

        internal static void UpdateMasterPassword(string masterPassword, string masterSalt = null)
        {
            if (masterSalt is not null)
            {
                Properties.Settings.Default.MasterPassword = masterPassword;
                Properties.Settings.Default.MasterSalt = masterSalt;
            }
            else
            {
                string salt = CryptographyProvider.GenerateSalt();
                var saltedhashedPassword = CryptographyProvider.SaltAndHashPassword(masterPassword, salt);
                Properties.Settings.Default.MasterPassword = saltedhashedPassword;
                Properties.Settings.Default.MasterSalt = salt;
            }
            Properties.Settings.Default.Save();
        }

        internal static bool IsEnteredPasswordMatch(string enteredPassword)
        {
            string currentMasterPassword = Properties.Settings.Default.MasterPassword;
            string masterSalt = Properties.Settings.Default.MasterSalt;
            var saltedhashedPassword = CryptographyProvider.SaltAndHashPassword(enteredPassword, masterSalt);
            return (saltedhashedPassword == currentMasterPassword);
        }
    }
}
