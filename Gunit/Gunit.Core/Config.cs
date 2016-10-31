using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gunit.Core
{
    public class Config
    {
        /// <summary>
        /// Maximimum child depth that Verify will traverse when comparing objects.
        /// </summary>
        public int MaxDepth { get; private set; }

        /// <summary>
        /// Tolerance in milliseconds when comparing DateTime fields.
        /// </summary>
        /// <remarks>
        /// This allows a small wriggle room when creating objects on the fly, and confirming they are almost identical, or close enough.
        /// Really handy when working with legacy code where you can't refactor and inject a DateTime delegate.
        /// </remarks>
        public int ToleranceMs { get; private set; }

        public Config()
        {
            MaxDepth = 5;
            ToleranceMs = 200;
        }

        public Config(int maxDepth, int toleranceMs)
        {
            MaxDepth = maxDepth;
            ToleranceMs = toleranceMs;
        }
    }
}
