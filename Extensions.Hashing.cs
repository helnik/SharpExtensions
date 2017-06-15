using System;
using System.Security.Cryptography;
using System.Text;

namespace CustomExtensions
{
    public static partial class Extensions
    {
        public static string GetMD5HashString(this string text)
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

        public static string GetSha256HashString(this string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;
            using (var sha = new SHA256Managed())
            {
                byte[] textData = Encoding.UTF8.GetBytes(text);
                byte[] hash = sha.ComputeHash(textData);
                return BitConverter.ToString(hash).Replace("-", string.Empty);
            }
        }
    }
}
