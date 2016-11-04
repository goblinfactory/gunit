using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gunit.Core.Internal;
using Gunit.Core.Internal.Comparers;
using Gunit.Core.Logging;
using StringComparer = Gunit.Core.Internal.Comparers.StringComparer;

namespace Gunit.Core
{
    using System.Reflection;

    namespace Packages.MUnit
    {
        public static class StringExtensions
        {
            public static string Indent(this string src, int indent)
            {
                return $"{new String(' ', 5*indent)}{src}";
            }
        }

        public static class Comparer
        {
            public static void VerifySame(this object left, object right, int maxDepth = 5, int toleranceMs = 200, ILog log = null)
            {
                ILog logger = log ?? new Logger(Logger.DefaultLevel);
                var type = left.GetType();
                var state = new State(type, type.Name, left, right, 1, maxDepth, toleranceMs, "", logger);
                _verifySame(state);
            }

            private static void _verifySame(State state)
            {
                object left = state.Left;
                object right = state.Right;
                string crumb = state.Crumb;
                int maxDepth = state.MaxDepth;
                var log = state.Log;
                int depth = state.CurrentDepth;
                log.Info(state.ToString(),state.CurrentDepth);
                if (depth > maxDepth)
                {
                    var msg = $"Maximum object depth of {state.MaxDepth} exceeded. {crumb}";
                    throw new VerifyException(msg,"NA",  "NA", "NA");
                }

                if (NullComparer.BothNull(state)) return;
                
                var properties = PropertyHelper.ComparableProperties(left, right);
                foreach (var prop in properties)
                {
                    var name = prop.Name;
                    var propCrumb = $"{crumb}.{name}";
                    
                    var newstate = state.CreateChildState(prop.Type, name, prop.LHS, prop.RHS, propCrumb);

                    // NULLS
                    // -----
                    if (NullComparer.BothNull(newstate)) continue;

                    //DATETIME 
                    // -------
                    if (DateTimeComparer.Compare(newstate)) continue;

                    //TIMESPAN
                    // -------
                    if (TimeSpanComparer.Compare(newstate)) continue;

                    // STRING COMPARABLE
                    // -----------------
                    if (StringComparer.CompareByStrings(newstate)) continue;

                    // LISTS
                    if (name.Contains("IList`")) continue;

                    // CLASS
                    // -----
                    
                    _verifySame(newstate);
                }
            }
        }
    }
}
