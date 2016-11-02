using System;
using Gunit.Core.Logging;

namespace Gunit.Core.Internal.Comparers
{
    public static class ListComparer
    {
        public static bool CompareLists(Type ptype, object lhs, object rhs, string propCrumb, string name, ILog log)
        {
            // todo, list implementation : check if type has a genEnumerator
            if (ptype.Name.Contains("IList`")) return true;

            return false;
        }
    }
}
