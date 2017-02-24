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
    }
}
