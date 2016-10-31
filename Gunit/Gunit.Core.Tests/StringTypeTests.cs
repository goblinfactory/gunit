using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gunit.Core.Tests.Internal;
using NUnit.Framework;
using Gunit.Core;

namespace Gunit.Core.Tests
{


    public class StringTypeTests
    {

        [Test]
        [TestCase("PASS", "NA", 12, 40.231F, 'C', 'C', true, "Fred", "3.14", Weekday.Friday, 20230, 987654321, 2, 2, "31/10/2016 18:41:24", false)]
        [TestCase("Loop","byte", 99, 40.231F,'C', 'C', true,"Fred","3.14",Weekday.Friday,20230, 987654321, 2,2, "31/10/2016 18:41:24",true)]
        [TestCase("Distance","float", 12, 123.456F,'C', 'C', true,"Fred","3.14",Weekday.Friday,20230, 987654321, 2,2, "31/10/2016 18:41:24",true)]
        [TestCase("Initial","char", 12, 40.231F,'$','C', true,"Fred","3.14",Weekday.Friday,20230, 987654321, 2,2, "31/10/2016 18:41:24",true)]
        [TestCase("InitialN","charNullable", 12, 40.231F,'$',null, true,"Fred","3.14",Weekday.Friday,20230, 987654321, 2,2, "31/10/2016 18:41:24",true)]
        [TestCase("Done","bool", 12, 40.231F,'C', 'C', false,"Fred","3.14",Weekday.Friday,20230, 987654321, 2, 2,"31/10/2016 18:41:24",true)]
        [TestCase("Name","string", 12, 40.231F,'C', 'C', true,"Freds","3.14",Weekday.Friday,20230, 987654321, 2,2, "31/10/2016 18:41:24",true)]
        [TestCase("Name", "string", 12, 40.231F,'C', 'C', true,null,"3.14",Weekday.Friday,20230, 987654321, 2,2, "31/10/2016 18:41:24",true)]
        [TestCase("Name", "string", 12, 40.231F,'C', 'C', true,"","3.14",Weekday.Friday,20230, 987654321, 2, 2,"31/10/2016 18:41:24",true)]
        [TestCase("Day","enum", 12, 40.231F,'C', 'C', true,"Fred","3.14",Weekday.Thursday,20230, 987654321, 2,2, "31/10/2016 18:41:24",true)]
        [TestCase("Gap","short", 12, 40.231F,'C', 'C', true,"Fred","3.14",Weekday.Friday,20231, 987654321, 2,2, "31/10/2016 18:41:24",true)]
        [TestCase("BigNum","long", 12, 40.231F,'C', 'C', true,"Fred","3.14",Weekday.Friday,20230, 100000000, 2,2, "31/10/2016 18:41:24",true)]
        [TestCase("Laps","int", 12, 40.231F,'C', 'C', true,"Fred","3.14",Weekday.Friday,20230, 987654321, 5238,2, "31/10/2016 18:41:24",true)]
        [TestCase("LapsN","intNullable", 12, 40.231F,'C', 'C', true,"Fred","3.14",Weekday.Friday,20230, 987654321, 5238,null, "31/10/2016 18:41:24",true)]
        [TestCase("Born","DateTime", 12, 40.231F,'C', 'C', true,"Fred","3.14",Weekday.Friday,20230, 987654321, 2,2, "31/10/2015 18:41:24",true)]
        [TestCase("Born","DateTime", 12, 40.231F,'C', 'C', true,"Fred","3.14",Weekday.Friday,20230, 987654321, 2,2, "31/10/2015",true)]
        public void simple_properties_of_pocos_tests(
                    string field,
                    string type,
                    byte loop ,
                    float distance ,
                    char initial ,
                    char? initialN,
                    bool done ,
                    string name ,
                    string decimalText,
                    Weekday day ,
                    short gap ,
                    long bigNum ,
                    int laps ,
                    int? lapsN,
                    string bornText,
                    bool shouldThrow
            )
        {

            bool pass = false;
            Console.WriteLine(field);
            Console.WriteLine("------");

            var left = new StringFields()
            {
                Loop     = loop,
                Distance = distance,
                Initial  = initial,
                Done     = done,
                Name     = name,
                Amount   = decimal.Parse(decimalText),
                Day      = day,
                Gap      = gap,
                BigNum   = bigNum,
                Laps     = laps,
                Born     = DateTime.Parse(bornText)
            };

            var right = new StringFields()
            {
                Loop     = 12,
                Distance = 50.231F,
                Initial  = 'C',
                Done     = true,
                Name     = "Fred",
                Amount   = 3.14M,
                Day      = Weekday.Friday,
                Gap      = 20230,
                BigNum   = 98765432154321,
                Laps     = 2,
                Born     = new DateTime(2016,10,28)
            };

            try
            {
                left.VerifySame(right);
                if(shouldThrow) pass = false;
            }
            catch (Exception ae)
            {
                if(shouldThrow) pass = true;
                Console.WriteLine(ae.Message);
            }
            if (!pass)
            {
                if(shouldThrow)
                    Assert.Fail("Expected assertion, but was not thrown.");
                else
                    Assert.Fail("Expected comparison to pass, but exception was thrown.");
            }
        }
    }
}
