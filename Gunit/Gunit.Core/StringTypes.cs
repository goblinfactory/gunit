using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Gunit.Core
{
    public static class StringTypes
    {
        private static readonly string[] _types = 
        {
            "byte",
            "sbyte",
            "int32",
            "uint32",
            "int16",
            "uint16",
            "int64",
            "uint64",
            "single",
            "double",
            "char",
            "boolean",
            "string",
            "decimal",
            "enum",
            "short",
            "long",
            "float",
            "int",
            "datetime",
            "string"            
        };

        public static bool Comparable(this object src)
        {
            var name = src.GetType().Name.ToLower();
            return _types.Contains(name);
        }

        public static bool Comparable(this Type type)
        {
            // mmm, check if code below works in Droid?
            if (type.GetTypeInfo().IsEnum) return true;
            var name = type.Name.ToLower();
            return _types.Contains(name);
        }

    }
}
