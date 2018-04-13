using System;
using System.Security.Cryptography;
using System.Text;

namespace CustomExtensions
{
    public static partial class Extensions
    {
         public static string CalculateMd5HashString(this string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;
            using (var md5 = MD5.Create())
            {
                byte[] textData = Encoding.UTF8.GetBytes(text);
                byte[] hash = md5.ComputeHash(textData);
                return BitConverter.ToString(hash).Replace("-", string.Empty);
            }
        }

        public static string CalculateSha256HashString(this string text)
        {
            if (string.IsNullOrEmpty(text)) return string.Empty;
            using (var sha256 = SHA256Managed.Create())
            {
                byte[] textData = Encoding.UTF8.GetBytes(text);
                byte[] hashBytes = sha256.ComputeHash(textData);
                return BitConverter.ToString(hashBytes).Replace("-", string.Empty);
            }
        }

        private static string CalculateSha512HashString(this string text)
        {
            using (var sha512 = SHA512Managed.Create())
            {
                byte[] textData = Encoding.UTF8.GetBytes(text);
                byte[] hashBytes = sha512.ComputeHash(textData);
                return BitConverter.ToString(hashBytes).Replace("-", string.Empty);
            }
        }
    }
}
