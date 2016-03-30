using System.Text.RegularExpressions;

namespace MyCustomExtensions
{
    public static class StringExtensions
    {
        #region Formating
        /// <summary>
        /// Reduces the white spaces of a given string to single whitespace
        /// </summary>        
        public static string ConvertWhiteSpacesToSingleSpaces(this string stringToConvert)
        {
            return Regex.Replace(stringToConvert, @"\s+", " ");
        }

        /// <summary>
        /// Completly remove whitespaces        
        public static string RemoveWhiteSpacesCompletly(this string stringToConvert)
        {
            return stringToConvert.Replace(" ", "");
        }

        /// <summary>
        /// Returns the 'x' Right chars of the string
        /// </summary>        
        public static string Right(this string sValue, int maxLength)
        {
            //Check if the value is valid
            if (string.IsNullOrEmpty(sValue))
            {
                //Set valid empty string as string could be null
                sValue = string.Empty;
            }
            else if (sValue.Length > maxLength)
            {
                //Make the string no longer than the max length
                sValue = sValue.Substring(sValue.Length - maxLength, maxLength);
            }

            //Return the string
            return sValue;
        }

        /// <summary>
        /// Returns the 'x' Left chars of the string
        /// </summary> 
        public static string Left(this string sValue, int maxLength)
        {
            //Check if the value is valid
            if (string.IsNullOrEmpty(sValue))
            {
                //Set valid empty string as string could be null
                sValue = string.Empty;
            }
            else if (sValue.Length > maxLength)
            {
                //Make the string no longer than the max length
                sValue = sValue.Substring(0, maxLength);
            }

            //Return the string
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
                else
                    counter++;
            }

            sValue = sValue.Substring(counter, sValue.Length - counter);
            return sValue;
        }
        #endregion

        /// <summary>
        /// Shorter way for string.IsNullOrEmpty
        /// </summary> 
        public static bool HasContext(this string stringToTest)
        {
            if (!string.IsNullOrEmpty(stringToTest))
                return true;
            else 
                return false;
        }

        /// <summary>
        /// Checks if string matches a specific pattern
        /// </summary>        
        public static bool Matches(this string value, string pattern)
        {
            Regex regex = new Regex(pattern);
            return regex.IsMatch(value);
        }
    }
}
