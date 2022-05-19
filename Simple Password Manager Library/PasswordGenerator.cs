using System;
using System.Diagnostics;
using System.Security.Cryptography;

namespace SimplePM.Library
{
    public class PasswordGenerator
    {
        private static Stopwatch timer = new Stopwatch();
        private const long maxExecutionTimeInMillisec = 10000;

        /// <summary>
        /// Generates new reliable cryptographically secure byte sequence and returns this as string. 
        /// By reliable means that result string will contain at least one uppercase letter, one lowercase letter, 
        /// one number and one non-digit and non-letter symbol. 
        /// All length values lower than 1 and greater than 100 will throw ArgumentOutOfRangeException.
        /// If method execution time exesses 10 seconds throws TimeoutException.
        /// </summary>
        /// <param name="length">Required password length</param>
        /// <exception cref="ArgumentOutOfRangeException">Throws this type of exception if length value is greater then 100 or lower then 1</exception>
        /// <exception cref="TimeoutException">Throws this type of exception if method execution time excesses 10 seconds</exception>
        /// <returns>Cryptographically secure password with specified length</returns>
        public static string GenerateReliable(int length)
        {
            if (length > 100 || length <= 0)
            {
                throw new ArgumentOutOfRangeException("Password of this length cannot be generated", "length");
            }
            timer.Restart();
            while (true)
            {
                if (timer.ElapsedMilliseconds > maxExecutionTimeInMillisec)
                {
                    timer.Stop();
                    throw new TimeoutException("Application was unable to generate password in alloted time");
                }
                string password = GenerateAny(length);
                if (password.IsReliablePassword())
                {
                    timer.Stop();
                    return password;
                }
            }
        }

        private static string GenerateAny(int length)
        {
            using (var rng = RandomNumberGenerator.Create())
            {
                var passBytes = new byte[128];
                rng.GetBytes(passBytes);
                string password = Convert.ToBase64String(passBytes);
                password = password.Substring(0, length);
                return password;
            }
        }
    }
}
