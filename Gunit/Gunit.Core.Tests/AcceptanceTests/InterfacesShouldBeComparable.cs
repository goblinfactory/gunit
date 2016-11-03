using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gunit.Core.Logging;
using Gunit.Core.Packages.MUnit;
using NUnit.Framework;

namespace Gunit.Core.Tests.AcceptanceTests
{
    public class InterfacesShouldBeComparable
    {
        public class Cat : IAnimal
        {
            public string Mother { get; set; }
            public int Age { get; set; }
            public string Name { get; set; }
            public char Sex { get; set; }
        }

        public interface IAnimal
        {
            int Age { get; }
        }

        public class Dog : IAnimal
        {
            public string Breed { get; set; }
            public int Age { get; set;  }
        }

        [Test]
        public void two_objects_the_same_compared_by_interface_should_be_ok()
        {
            IAnimal c1 = new Cat() { Age = 5, Name = "Buttons", Sex = 'M', Mother = "Froya"};
            IAnimal d1 = new Dog() { Age = 5, Breed = "Alsation" };
            c1.VerifySame(d1);
        }

        //[Test]
        //public void two_different_objects_compared_by_interface_should_throw_verify_exception()
        //{
        //    IAnimal c1 = new Cat() { Age = 5, Name = "Buttons" };
        //    IAnimal d1 = new Dog() { Age = 5, Breed = "Alsation" };
        //    var logger = new Logger(Level.Debug);
        //    c1.VerifySame(d1, log: logger);

        //    Assert.AreEqual("     IAnimal", logger.Logs[0]);
        //    Assert.AreEqual(3, logger.Logs.Length);
        //    Assert.AreEqual("          IAnimal.Age", logger.Logs[1]);
        //}

    }
}
