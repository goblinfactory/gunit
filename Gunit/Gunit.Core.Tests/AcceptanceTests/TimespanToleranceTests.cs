using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gunit.Core.Packages.MUnit;
using NUnit.Framework;

namespace Gunit.Core.Tests.AcceptanceTests
{
    public class TimespanToleranceTests
    {
        internal class B2
        {
            public TimeSpan Duration { get; set; }
        }

        [Test]
        [TestCase(0, false)]
        [TestCase(50, false)]
        [TestCase(250, true)]
        public void Timespan_within_200ms_should_be_considered_equivalent(int gap, bool throws)
        {
            var b1 = new B2() { Duration = TimeSpan.FromMilliseconds(5000) };
            var b2 = new B2() { Duration = TimeSpan.FromMilliseconds(5000).Add(TimeSpan.FromMilliseconds(gap)) };

            if (throws)
                Assert.Throws<VerifyException>(() => b1.VerifySame(b2));
            else
                b1.VerifySame(b2);
        }

    }
}
