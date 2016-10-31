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
        public static Config Config = null;

        static Gunit()
        {
            Config = new Config();
        }

    }
}
