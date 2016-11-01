using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gunit.Core.Packages.MUnit;
using NUnit.Framework;

namespace Gunit.Core.Tests
{
    public class DateTimeToleranceTests
    {

        internal class B1
        {
            public DateTime Appointment { get; set; }
        }


        [Test]
        [TestCase(0, false)]
        [TestCase(50, false)]
        [TestCase(250, true)]
        public void DateTime_within_200ms_should_be_considered_equivalent(int gap, bool throws)
        {
            var b1 = new B1() {Appointment = new DateTime(2016, 1, 1)};
            var b2 = new B1() {Appointment = new DateTime(2016, 1, 1).AddMilliseconds(gap)};

            if (throws)
                Assert.Throws<VerifyException>(() => b1.VerifySame(b2));
            else
                b1.VerifySame(b2);            
        }

    }
}
