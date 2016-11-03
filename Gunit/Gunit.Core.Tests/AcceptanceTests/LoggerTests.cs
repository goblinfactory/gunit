using Gunit.Core.Logging;
using Gunit.Core.Packages.MUnit;
using NUnit.Framework;

namespace Gunit.Core.Tests.AcceptanceTests
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

            Assert.AreEqual("     Cat", logger.Logs[0]);
            Assert.AreEqual(3, logger.Logs.Length);
            Assert.AreEqual("          Cat.Age", logger.Logs[1]);
            Assert.AreEqual("          Cat.Name", logger.Logs[2]);
        }
    }
}
