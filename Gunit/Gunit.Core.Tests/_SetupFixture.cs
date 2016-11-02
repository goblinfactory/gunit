using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gunit.Core.Logging;
using NUnit.Framework;

namespace Gunit.Core.Tests
{
    [SetUpFixture]
    public class _SetupFixture
    {
        [OneTimeSetUp]
        public void Setup()
        {
            Logger.Echo = Console.WriteLine;
            Logger.DefaultLevel = Level.Debug;
        }
    }
}
