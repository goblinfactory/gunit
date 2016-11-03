using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Gunit.Core.Internal
{
    public static class PropertyHelper
    {

        public class CompareProperty
        {
            public Type Type { get; set; }
            public string Name { get; set; }
            public object LHS { get; set; }
            public object RHS { get; set; }
        }

        public static IEnumerable<CompareProperty> ComparableProperties(Type type, object left, object right)
        {
            IsInterface(type);
            var runtimeProps = type.GetRuntimeProperties().Where(p => !p.GetMethod.IsStatic);
            var props = runtimeProps
                .Select(p => new CompareProperty()
                {
                    Type = p.PropertyType,
                    Name = p.Name,
                    LHS = p.GetValue(left),
                    RHS = p.GetValue(right)
                });

            var fields = type.GetRuntimeFields().Where(f => f.IsPublic);

            var publicFields = fields
                .Select(f => new CompareProperty()
                {
                    Type = f.FieldType,
                    Name = f.Name,
                    LHS = f.GetValue(left),
                    RHS = f.GetValue(right),
                });
            var allProps = new List<CompareProperty>();

            allProps.AddRange(props);
            allProps.AddRange(publicFields);
            return allProps;
        }

        public static bool IsInterface<T>(T src)
        {
            var t = typeof(T);
            return false;
        }

        //private static IEnumerable<CompareProperty> ComparableInterfaceProperties(Type type, object left, object right)
        //{
        //}


        public static IEnumerable<string> ComparablePropertyNames(object src)
        {
            var cp = ComparableProperties(src.GetType(), src, src);
            var names = cp.Select(p => p.Name);
            return names.ToArray();
        }
    }
}
