using System.Reflection;

namespace Zillifriends.Shared.Common
{
    /// <summary>
    ///     Extension methoden für Reflection, achtung Reflection ist langsam.
    /// </summary>
    public static class ReflectionExtensions
    {
        /// <summary>
        ///     Nimmt den System.Type und übergibt ihn als ersten Type-Parameter der generischen Klasse
        /// </summary>
        public static object? CreateWith<TGeneric>(this Type firstGenericType) where TGeneric : class, new()
        {
            var genTypeDefinition = typeof(TGeneric).GetGenericTypeDefinition();
            var constructedClass = genTypeDefinition?.MakeGenericType(firstGenericType);
            return constructedClass != null ? Activator.CreateInstance(constructedClass) : null;
        }

        public static TResult? GetPropertyValue<TResult>(this object data, string propertyName, TResult? defaultValue = default(TResult))
        {
            if (data != null)
            {
                var prop = data.GetType().GetProperty(propertyName);
                if (prop != null)
                {
                    if (!prop.CanRead)
                    {
                        throw new InvalidOperationException($"The Property {propertyName} has no getter");
                    }
                    return (TResult)prop.GetValue(data);
                }
                throw new InvalidOperationException($"The Property {propertyName} does not exist");
            }
            return defaultValue;
        }

        public static bool HasProperty(this object data, string propertyName)
        {
            if (data is Type dataType)
            {
                return dataType.GetProperty(propertyName) != null;
            }
            if (data != null)
            {
                return data.GetType().GetProperty(propertyName) != null;
            }
            return false;
        }

        public static object? InvokeMethod(this object item, string methodName, object argument1)
        {
            var method = item.GetType().GetMethod(methodName);
            return method?.Invoke(item, new[]
            {
                argument1
            });
        }

        public static object? InvokeMethod(this object item, string methodName, object argument1, object argument2)
        {
            var method = item.GetType().GetMethod(methodName);
            return method?.Invoke(item, new[]
            {
                argument1,
                argument2
            });
        }

        public static object? InvokeMethod(this object item, string methodName, object argument1, object argument2, object argument3)
        {
            var method = item.GetType().GetMethod(methodName);
            return method?.Invoke(item, new[]
            {
                argument1,
                argument2,
                argument3
            });
        }

        public static void SetPropertyValue(this object data, string propertyName, object value)
        {
            if (data != null)
            {
                var prop = data.GetType().GetProperty(propertyName);
                if (prop != null)
                {
                    if (!prop.CanWrite)
                    {
                        throw new InvalidOperationException($"The Property {propertyName} has no setter");
                    }
                    prop.SetValue(data, value);
                }
                else
                {
                    throw new InvalidOperationException($"The Property {propertyName} does not exist");
                }
            }
        }

        /// <summary>
        /// Kopiert die les- und schreibbaren Properties eines Objektes auf ein Zweites.
        /// </summary>
        public static void CopyPropertiesTo<T>(this T source, T dest)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (dest == null)
            {
                throw new ArgumentNullException(nameof(dest));
            }

            var pList = typeof(T).GetProperties().Where(p => p.CanRead && p.CanWrite);

            foreach (PropertyInfo prop in pList)
            {
                prop.SetValue(dest, prop.GetValue(source, null), null);
            }
        }
    }
}