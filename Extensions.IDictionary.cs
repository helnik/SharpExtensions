using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomExtensions
{
    public static partial class Extensions
    {
        /// <summary>
        /// Retuns the value if key exist else add the value
        /// </summary>      
        public static TValue AddOrUpdate<TKey, TValue>(this IDictionary<TKey, TValue> dic, TKey key, TValue value)
        {
            if (!dic.ContainsKey(key))
            {                
                dic.Add(key, value);
            }
            else
            {
                dic[key] = value;
            }

            return dic[key];
        }

        /// <summary>
        /// returns the value if key exists else adds it
        /// </summary>      
        public static TValue GetOrAdd<TKey, TValue>(this IDictionary<TKey, TValue> dic, TKey key, TValue value)
        {
            if (!dic.ContainsKey(key))
            {
                dic.Add(key, value);
            }

            return dic[key];
        }
    }
}
