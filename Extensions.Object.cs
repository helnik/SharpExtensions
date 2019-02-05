using System.Collections.Generic;
using System.Reflection;

namespace SharpExtensions
{
    public static partial class Extensions
    {
        public static IEnumerable<KeyValuePair<string, object>> EnumerateProperties<T>(this T obj)
        {
            if (obj == null) yield break;

            if (obj is IDictionary<string, object> dictionary)
            {
                foreach (var item in dictionary)
                {
                    yield return item;
                }
                yield break;
            }

            var properties = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var property in properties)
            {
                yield return new KeyValuePair<string, object>(property.Name, property.GetValue(obj));
            }

        }
    }
}

