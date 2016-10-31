using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gunit.Core
{
    using System.Reflection;

    namespace Packages.MUnit
    {
        public static class Comparer
        {
            public class Continue : Exception {}

            public static void VerifySame(this object left, object right, int maxDepth = 5) 
            {
                _verifySame(left.GetType().Name, left, right,"", maxDepth);
            }

            private static void _verifySame(string fieldName, object left, object right, string crumb, int maxDepth)
            {
                if (maxDepth <= 0)
                {
                    throw new VerifyException($"Maximum object depth of exceeded. {crumb}","NA",  "NA", "NA");
                }

                if (BothNull(fieldName,left,right,crumb)) return;

                var type = left.GetType();


                foreach (var property in type.GetRuntimeProperties().Where(p=> !p.GetMethod.IsStatic))
                {
                    var ptype = property.PropertyType;
                    // skip IList
                    if (ptype.Name.Contains("IList`")) continue;
                    var name = property.Name;
                    var propCrumb = $"{crumb}.{name}";
                    var lhs = property.GetValue(left);
                    var rhs = property.GetValue(right);

                    if (BothNull(name, lhs, rhs, propCrumb)) continue;

                    if (ptype.Comparable())
                    {
                        if (!lhs.ToString().Equals(rhs.ToString()))                        
                            throw new VerifyException(propCrumb,name, lhs.ToString(), rhs.ToString());
                        continue;
                    }
                    // process child objects
                    // ---------------------
                    _verifySame(name, lhs, rhs, propCrumb, maxDepth - 1);
                }
            }

            private static bool BothNull(string fieldName, object left, object right, string crumb)
            {
                if (left == null && right == null) return true;
                if (left == null)
                    throw new VerifyException(crumb, fieldName, "NULL", "NOTNULL");
                if (right == null)
                    throw new VerifyException(crumb, fieldName, "NOTNULL", "NULL");
                return false;
            }
        }
    }
}
