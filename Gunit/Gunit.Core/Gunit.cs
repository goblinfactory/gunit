using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Gunit.Core
{
    public static class Gunit
    {
        private static Fail _fail = null;
        private static Config _config = null;

        private static void Check()
        {
            if(_fail==null) throw new Exception("Gunit not initialised. Please initialise Gunit before using. e.g. on windows, call Gunit.Init(Assert.Fail)");
        }

        /// <summary>
        /// Pass in a delegate to your test platform's Assert.Fail, e.g. for Nunit call -&gt; SetPlatform(Assert.Fail);
        /// </summary>
        public static void Init(Fail fail)
        {
            _fail = fail;
            _config = new Config();
        }

        /// <summary>
        /// Initialise the test platform and default configuration.
        /// </summary>
        /// <param name="config">default system configuration</param>
        /// <param name="fail">delegate to the platform's equivalent of Assert.Fail, e.g. for Nunit call -&gt; SetPlatform(Assert.Fail);</param>
        public static void Init(Config config, Fail fail)
        {
            _fail = fail;
            _config = config;
        }

        public static void Ensure<TSource>(this TSource source, params Expression<Func<TSource, bool>>[] actions)
        {
            Check();
            foreach (var expression in actions)
            {
                Ensure(source, expression);
            }
        }

        public static void Ensure<TSource>(this TSource source, Expression<Func<TSource, bool>> action)
        {
            Check();
            var propertyCaller = action.Compile();
            bool result = propertyCaller(source);
            if (result) return;
            _fail($"\nProperty check failed -> {action.ToString()}\n\n");
        }

        public static void VerifySame(this object left, object right, int? maxDepth = null)
        {
            throw new Exception("left not equal right field [Loop]");
        }

    }
}
