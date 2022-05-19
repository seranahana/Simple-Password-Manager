using System.Linq;

namespace SimplePM.Library
{
    public static class StringExtensions
    {
        public static bool IsReliablePassword(this string password)
        {
            if (password != null)
            {
                bool alphabetic = password.Any(ch => char.IsUpper(ch)) && password.Any(ch => char.IsLower(ch));
                bool numeric = password.Any(ch => char.IsDigit(ch));
                bool symbolic = password.Any(ch => !char.IsLetterOrDigit(ch));
                return (alphabetic && numeric && symbolic);
            }
            else
            {
                return false;
            }
        }
    }
}
