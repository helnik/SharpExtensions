using Newtonsoft.Json;
using System;
using System.Linq;
using System.Reflection;

namespace SharpExtensions
{
    public static partial class Extensions
    {
        public static object GetPropertyValue(this object obj, string propertyName)
        {
            if (obj == null) return null;
            try
            {
                return obj.GetType().GetProperty(propertyName)?.GetValue(obj, null);
            }
            catch (Exception ex)
            {
                throw new Exception($"Could not get value from property: {propertyName} from Type {obj.GetType().Name}", ex);
            }
        }

        public static void SetPropertyValue(this object obj, string propertyName, object valueToSet)
        {
            if (obj != null)
            {
                try
                {
                    obj.GetType().GetProperty(propertyName)?.SetValue(obj, valueToSet);                    
                }
                catch (Exception ex)
                {
                    throw new Exception($"Could not set value for property {propertyName} fom Type: {obj.GetType().Name}", ex);
                }
            }
        }

        public static Assembly GetAssemblyFromName(this string assemblyName)
        {
            if (string.IsNullOrEmpty(assemblyName)) return null;
            return AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(a => assemblyName.Equals(a.FullName));
        }

        public static T Copy<T>(this T source) where T : class
        {
            T newObj = Activator.CreateInstance<T>();
            foreach (PropertyInfo pinfo in newObj.GetType().GetProperties())
            {               
                if (pinfo.CanWrite)
                {
                    object value = source.GetType().GetProperty(pinfo.Name).GetValue(source, null);
                    pinfo.SetValue(newObj, value, null);
                }
            }
            return newObj;
        }

        public static T DeepCloneWithJson<T>(T original) where T : class
        {
            if (original is null) return default(T);

            var deserializeSettings = new JsonSerializerSettings { ObjectCreationHandling = ObjectCreationHandling.Replace };
            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(original), deserializeSettings);
        }
    }
}
