using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Gunit.Core.Internal;
using NUnit.Framework;

namespace Gunit.Core.Tests.UnitTests
{
    public class PropertyHelperTests
    {

        internal class Vehicle
        {
            public string Make { get; set; }
        }

        internal class Car : Vehicle
        {
            // should exclude
            // ----------------------
            public static int TopSpeed(){return 100;}       // public static method
            public static int FastestCar { get; set; }      // public static field
            private int PCurrentSpeed() { return 4; }       // private methods
            private char Middle;                            // private fields

            // should include
            // ----------------------
            // inherited properties that are not 'excluded' => Make
            public int CurrentSpeed { get; set; }           // public method
            public char Initial;                            // public field
            public string Model { get; set; }               // public property
            public Car PreviousModel { get; set; }          // public property
        }

        [Test]
        public void ComparableProperties_should_return_only_public_methods_properties_and_fields()
        {
            var car = new Car();
            var type = car.GetType();
            var props = PropertyHelper.ComparablePropertyNames(car);
            props.Should().BeEquivalentTo(new[] { "CurrentSpeed", "Initial", "Model", "PreviousModel", "Make"});
        }
    }
}
