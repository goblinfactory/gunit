using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gunit.Core.Logging;
using Gunit.Core.Packages.MUnit;
using NUnit.Framework;

namespace Gunit.Core.Tests
{
    public class LoggerTests
    {
        public class Cat
        {
            public int Age { get; set; }
            public string Name { get; set; }
        }

        [Test]
        public void should_record_the_name_of_the_class_and_the_properties()
        {
            var c1 = new Cat() {Age = 5, Name = "Buttons"};
            var c2 = new Cat() {Age = 5, Name = "Buttons"};
            var logger = new Logger(Level.Debug);
            c1.VerifySame(c2, log:logger);

            Assert.AreEqual("     1. Cat", logger.Logs[0]);
            Assert.AreEqual(3, logger.Logs.Length);
            Assert.AreEqual("          2. Age", logger.Logs[1]);
            Assert.AreEqual("          3. Name", logger.Logs[2]);
        }
    }
}
