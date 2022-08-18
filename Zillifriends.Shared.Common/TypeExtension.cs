using System.Reflection;

namespace Zillifriends.Shared.Common
{
    public static class TypeExtension
    {
        public static IEnumerable<PropertyInfo> GetInheritedInterfaceProperties(this Type interfaceType)
        {
            IEnumerable<Type> allInterfacesRecursive = GetInheritedInterfaces(interfaceType);

            var pis = new List<PropertyInfo>();
            pis.AddRange(allInterfacesRecursive.GetProperties(false));
            pis.AddRange(interfaceType.GetProperties());
            return new HashSet<PropertyInfo>(pis);
        }

        /// <summary>
        /// Ermittelt, ob die Instanz einer Klasse gleich dem Default-Wert der Klasse ist.
        /// Funktioniert auch für einfache Typen.
        /// </summary>
        public static bool IsDefault<T>(this T obj)
        {
            // eine Prüfung auf ArgumentNullExeption entfällt, da null ein sinnvoller Default-Wert sein kann.
            return EqualityComparer<T>.Default.Equals(obj, default(T));
        }

        public static IEnumerable<Type> GetInheritedInterfaces(this Type interfaceType, bool distinct = true)
        {
            var directInterfaces = interfaceType.GetInterfaces();
            var interfaces = new List<Type>();
            foreach (var interf in directInterfaces)
            {
                interfaces.AddRange(interf.GetInheritedInterfaces(distinct: false));
            }
            interfaces.AddRange(interfaceType.GetInterfaces());
            return distinct ? (IEnumerable<Type>)new HashSet<Type>(interfaces) : interfaces;
        }

        public static IEnumerable<PropertyInfo> GetProperties(this IEnumerable<Type> types, bool distinct = true)
        {
            var pis = new List<PropertyInfo>();
            foreach (var type in types)
            {
                pis.AddRange(type.GetProperties());
            }
            return distinct ? (IEnumerable<PropertyInfo>) new HashSet<PropertyInfo>(pis) : pis.ToArray();
        }
    }
}
