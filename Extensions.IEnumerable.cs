using System.Collections.Generic;
using System.Linq;

namespace CustomExtensions
{
    public static partial class Extensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> collection)
        {
            return collection == null || !collection.Any();
        }
        
        /// <summary>
        /// Outputs the number of the elements and elements in a string 
        /// </summary>        
        /// <param name="collection">The IEnumerable collection </param>
        /// <param name="separator">Separator of the elements. Default is comma followed by space </param>
        /// <returns></returns>
        private static string ContentToString<T>(this IEnumerable<T> collection, string separator = ", ")
        {
            if (collection.IsNullOrEmpty()) return $"Collection contains zero elements";
            string output = string.Empty;
            bool isFirst = true;

            foreach (var element in collection)
            {
                if (isFirst)
                {
                    output += element.ToString();
                    isFirst = false;
                }
                else output += separator + element.ToString();                
            }
            return $"Collection contains {collection.Count()} elements: {output} ";
        }
    }
}
