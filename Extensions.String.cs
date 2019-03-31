using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SharpExtensions
{
    public static partial class Extensions
    {
        #region Utils
        /// <summary>
        /// Create a random string based on a given string and a given <paramref name="length"/>
        /// </summary>  
        public static string Randomize(this string sValue, int length)
        {
            Random random = new Random();
            StringBuilder result = new StringBuilder(length);
            for (int i = 0; i < length; i++)
                result.Append(sValue[random.Next(sValue.Length)]);
            return result.ToString();
        }

        /// <summary>
        /// Reverses the current string. If string is null or empty return empty string
        /// </summary>
        public static string Reverse(this string sValue)
        {
            if (string.IsNullOrEmpty(sValue)) return string.Empty;
            char[] array = sValue.ToCharArray();
            Array.Reverse(array);
            return new String(array);
        }
        #endregion

        #region Formating
        /// <summary>
        /// Reduces the white spaces of a given string to single whitespace
        /// </summary>        
        public static string ConvertWhiteSpacesToSingleSpaces(this string sValue)
        {
            return Regex.Replace(sValue, @"\s+", " ");
        }

        /// <summary>
        /// Completly remove whitespaces  
        /// </summary> 
        public static string RemoveAllWhiteSpaces(this string sValue)
        {
            return sValue.Replace(" ", "");
        }

        /// <summary>
        /// Returns the 'x' Right chars of the string
        /// </summary>        
        public static string Right(this string sValue, int maxLength)
        {
            if (string.IsNullOrEmpty(sValue))
                sValue = string.Empty;
            else if (sValue.Length > maxLength)
                sValue = sValue.Substring(sValue.Length - maxLength, maxLength);
            return sValue;
        }

        /// <summary>
        /// Returns the 'x' Left chars of the string
        /// </summary> 
        public static string Left(this string sValue, int maxLength)
        {
            if (string.IsNullOrEmpty(sValue))
                sValue = string.Empty;
            else if (sValue.Length > maxLength)
                sValue = sValue.Substring(0, maxLength);
            return sValue;
        }

        /// <summary>
        /// Eliminates the first 'x' chars of the string
        /// </summary> 
        public static string EliminateFirstChars(this string sValue, char charToEliminate)
        {
            int counter = 0;
            foreach (char c in sValue)
            {
                if (c != charToEliminate)
                    break;
                counter++;
            }
            sValue = sValue.Substring(counter, sValue.Length - counter);
            return sValue;
        }
        #endregion

        #region ToSomething
        public static int ToIntOrZero(this string sValue)
        {
            int.TryParse(sValue, out int result);
            return result;
        }

        public static decimal ToDecimalOrZero(this string sValue)
        {
            decimal.TryParse(sValue, out var result);
            return result;
        }

        public static double ToDoubleOrZero(this string sValue)
        {
            double.TryParse(sValue, out var result);
            return result;
        }

        public static float ToFloatOrZero(this string sValue)
        {
            float.TryParse(sValue, out var result);
            return result;
        }

        public static string TrimmedContextOrEmpty(this string sValue)
        {
            return string.IsNullOrEmpty(sValue) ? string.Empty : sValue.Trim();
        }
        #endregion

        #region Context        
        public static bool HasContext(this string sValue)
        {
            return !string.IsNullOrEmpty(sValue);
        }

        /// <summary>
        /// Checks if string matches a specific pattern
        /// </summary>        
        public static bool Matches(this string sValue, string pattern)
        {
            Regex regex = new Regex(pattern);
            return regex.IsMatch(sValue);
        }

        /// <summary>
        /// Checks if string is a valid number (number is defined as a decimal -comma or dot sepparated- with digits only)
        /// Same as Matches but pattern is specified
        /// </summary>   
        /// <remarks>https://stackoverflow.com/a/4247184</remarks> 
        public static bool IsNumber(this string sValue)
        {
            Regex regex = new Regex(@"^([-+] ?)?[0-9]+([\.\,][0-9]+)?$");
            return regex.IsMatch(sValue);
        }

        /// <summary>
        /// Get the maximum occurrence of a char within a string
        /// </summary>        
        private static long GetMaximumOccurenceOfChar(this string sValue)
        {
            return sValue.Length == 0 ? 0 : sValue.GroupBy(c => c).Max(group => group.Count());
        }

        /// <summary>
        /// Gets the char and it's occurrence count within a string
        /// </summary>        
        /// <returns>Dictionary&#60;char&#44; long&#62;</returns>
        private static Dictionary<char, long> GetCharsAndOccurrence(this string sValue)
        {
            var result = new Dictionary<char, long>();
            if (string.IsNullOrEmpty(sValue)) return result;

            foreach (var c in sValue)
            {
                if (result.TryGetValue(c, out long exists))
                    continue;
                result.Add(c, sValue.Count(ch => ch.Equals(c)));
            }
            return result;
        }

        /// <summary>
        /// Get string value between [first] a and [last] b.
        /// Source https://www.dotnetperls.com/between-before-after
        /// </summary>
        public static string Between(this string sValue, string a, string b)
        {
            int posA = sValue.IndexOf(a);
            int posB = sValue.LastIndexOf(b);
            if (posA == -1)
            {
                return "";
            }
            if (posB == -1)
            {
                return "";
            }
            int adjustedPosA = posA + a.Length;
            if (adjustedPosA >= posB)
            {
                return "";
            }
            return sValue.Substring(adjustedPosA, posB - adjustedPosA);
        }

        /// <summary>
        /// Get string value after [first] a.
        /// Source https://www.dotnetperls.com/between-before-after
        /// </summary>
        public static string Before(this string sValue, string a)
        {
            int posA = sValue.IndexOf(a);
            if (posA == -1)
            {
                return "";
            }
            return sValue.Substring(0, posA);
        }

        /// <summary>
        /// Get string value after [last] a.
        /// Source https://www.dotnetperls.com/between-before-after
        /// </summary>
        public static string After(this string sValue, string a)
        {
            int posA = sValue.LastIndexOf(a);
            if (posA == -1)
            {
                return "";
            }
            int adjustedPosA = posA + a.Length;
            if (adjustedPosA >= sValue.Length)
            {
                return "";
            }
            return sValue.Substring(adjustedPosA);
        }

        /// <summary>
        ///Get the first unique char of a string (e.g. "tertrfddfg" should return e)
        /// </summary>
        public static string FirstUniqueChar(this string sValue)
        {
            return sValue
                .GroupBy(c => c.ToString(), c => c, StringComparer.OrdinalIgnoreCase)
                .Where(g => g.Count() == 1)
                .Select(g => g.Key)
                .FirstOrDefault();
        }

        /// <summary>
        /// Check if a string contains at least one of the given strings
        /// </summary>
        /// <param name="sValue">The string to be checked</param>
        /// <param name="stringComparison">Default stringComparison is CurrentCulture</param>
        /// <param name="valuesToBeChecked">At least one of the strings must be contained to return true</param>
        /// <returns></returns>
        public static bool ContainsAny(this string sValue, StringComparison stringComparison = StringComparison.CurrentCulture,
            params string[] valuesToBeChecked)
        {
            return valuesToBeChecked.Any(s => sValue.IndexOf(s, stringComparison) != -1);
        }

        /// <summary>
        /// Check if a string contains all the given strings
        /// </summary>
        /// <param name="sValue">The string to be checked</param>
        /// <param name="stringComparison">Default stringComparison is CurrentCulture</param>
        /// <param name="valuesToBeChecked">The strings we want to check if contained</param>
        /// <returns></returns>
        public static bool ContainsAll(this string sValue, StringComparison stringComparison = StringComparison.CurrentCulture,
            params string[] valuesToBeChecked)
        {
            return valuesToBeChecked.All(s => sValue.IndexOf(s, stringComparison) != -1);
        }
        #endregion
    }
}
