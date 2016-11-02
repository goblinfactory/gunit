using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
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
        [TestCase(199, false)]
        [TestCase(200, false)]
        [TestCase(250, true)]
        [TestCase(500, true)]
        [TestCase(2000, true)]
        public void DateTime_within_200ms_should_be_considered_equivalent(int gap, bool throws)
        {
            var b1 = new B1() {Appointment = new DateTime(2016, 1, 1, 11, 55, 50)};
            var b2 = new B1() {Appointment = new DateTime(2016, 1, 1, 11, 55, 50).AddMilliseconds(gap)};

            if (throws)
                Assert.Throws<VerifyException>(() => b1.VerifySame(b2));
            else
                b1.VerifySame(b2);
        }

        [Test]
        public void tolerance_exception_should_show_differences_in_ticks()
        {
            var b1 = new B1() {Appointment = new DateTime(2016, 1, 1, 11, 55, 50)};
            var b2 = new B1() {Appointment = new DateTime(2016, 1, 1, 11, 55, 50).AddMilliseconds(201)};

            try
            {
                b1.VerifySame(b2);
            }
            catch (VerifyException ve)
            {
                Console.WriteLine(ve.Message);
                ve.Message.Should()
                    .Be("B1.Appointment [01/01/2016 11:55:50 [635872461500000000] ticks] != [01/01/2016 11:55:50 [635872461502010000] ticks]");
            }
        }



    }
}
