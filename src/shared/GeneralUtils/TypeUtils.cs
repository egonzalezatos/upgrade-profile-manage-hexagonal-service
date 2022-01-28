using System;
using System.Linq;

namespace GeneralUtils
{
    public class TypeUtils
    {
        public static Type[] GetTypesFromInterface(Type type)
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p))
                .Where(p => !type.Equals(p))
                .ToArray();
        }
    }
}