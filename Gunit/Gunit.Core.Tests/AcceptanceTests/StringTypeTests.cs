using System;
using Gunit.Core.Packages.MUnit;
using Gunit.Core.Tests.Internal;
using NUnit.Framework;

namespace Gunit.Core.Tests.AcceptanceTests
{


    public class StringTypeTests
    {

    [Test]
        [TestCase(1, "PASS", "NA", 12, 40.231F, 'C', 'C', true, "Fred", "3.14", Weekday.Friday, 20230, 98765432154321, 2, 2, "31/10/2016 18:41:24", false)]
        [TestCase(2, "Born", "DateTime", 12, 40.231F, 'C', 'C', true, "Fred", "3.14", Weekday.Friday, 20230, 98765432154321, 2, 2, "31/10/2016 18:41:25", true)] // 1 second difference
        [TestCase(3, "Loop","byte", 99, 40.231F,'C', 'C', true,"Fred","3.14",Weekday.Friday,20230, 98765432154321, 2,2, "31/10/2016 18:41:24",true)]
        [TestCase(4, "Distance","float", 12, 123.456F,'C', 'C', true,"Fred","3.14",Weekday.Friday,20230, 98765432154321, 2,2, "31/10/2016 18:41:24",true)]
        [TestCase(5, "Initial","char", 12, 40.231F,'$','C', true,"Fred","3.14",Weekday.Friday,20230, 98765432154321, 2,2, "31/10/2016 18:41:24",true)]
        [TestCase(6, "InitialN","charNullable", 12, 40.231F,'C',null, true,"Fred","3.14",Weekday.Friday,20230, 98765432154321, 2,2, "31/10/2016 18:41:24",true)]
        [TestCase(7, "Done","bool", 12, 40.231F,'C', 'C', false,"Fred","3.14",Weekday.Friday,20230, 98765432154321, 2, 2,"31/10/2016 18:41:24",true)]
        [TestCase(8, "Name","string", 12, 40.231F,'C', 'C', true,"Freds","3.14",Weekday.Friday,20230, 98765432154321, 2,2, "31/10/2016 18:41:24",true)]
        [TestCase(9, "Name", "string", 12, 40.231F,'C', 'C', true,null,"3.14",Weekday.Friday,20230, 98765432154321, 2,2, "31/10/2016 18:41:24",true)]
        [TestCase(10, "Name", "string", 12, 40.231F,'C', 'C', true,"","3.14",Weekday.Friday,20230, 98765432154321, 2, 2,"31/10/2016 18:41:24",true)]
        [TestCase(11, "Day","enum", 12, 40.231F,'C', 'C', true,"Fred","3.14", Weekday.Thursday,20230, 98765432154321, 2,2, "31/10/2016 18:41:24",true)]
        [TestCase(12, "Gap","short", 12, 40.231F,'C', 'C', true,"Fred","3.14",Weekday.Friday,20231, 98765432154321, 2,2, "31/10/2016 18:41:24",true)]
        [TestCase(13, "BigNum","long", 12, 40.231F,'C', 'C', true,"Fred","3.14",Weekday.Friday,20230, 100000000, 2,2, "31/10/2016 18:41:24",true)]
        [TestCase(14, "Laps","int", 12, 40.231F,'C', 'C', true,"Fred","3.14",Weekday.Friday,20230, 98765432154321, 5238,2, "31/10/2016 18:41:24",true)]
        [TestCase(15, "LapsNullable", "intNullable", 12, 40.231F,'C', 'C', true,"Fred","3.14",Weekday.Friday,20230, 98765432154321, 2,null, "31/10/2016 18:41:24",true)]
        [TestCase(16, "Born","DateTime", 12, 40.231F,'C', 'C', true,"Fred","3.14",Weekday.Friday,20230, 98765432154321, 2,2, "31/10/2015 18:41:24",true)]
        [TestCase(17, "Born","DateTime", 12, 40.231F,'C', 'C', true,"Fred","3.14",Weekday.Friday,20230, 98765432154321, 2,2, "31/10/2015",true)]
        public void scalar_property_tests(
                    int testnum,
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
                Loop         = loop,
                Distance     = distance,
                Initial      = initial,
                InitialNullable = initialN,
                Done         = done,
                Name         = name,
                Amount       = decimal.Parse(decimalText),
                Day          = day,
                Gap          = gap,
                BigNum       = bigNum,
                Laps         = laps,
                LapsNullable = lapsN,
                Born         = DateTime.Parse(bornText)
            };

            var right = new StringFields()
            {
                Loop     = 12,
                Distance = 40.231F,
                Initial  = 'C',
                InitialNullable = 'C',
                Done     = true,
                Name     = "Fred",
                Amount   = 3.14M,
                Day      = Weekday.Friday,
                Gap      = 20230,
                BigNum   = 98765432154321,
                Laps     = 2,
                LapsNullable = 2,
                Born     = new DateTime(2016,10,31, 18,41,24)
            };

            try
            {
                left.VerifySame(right);
                pass = !shouldThrow;
            }
            catch (VerifyException ae)
            {
                if (shouldThrow)
                {
                    StringAssert.Contains(field,ae.Message);
                    pass = true;
                }
                Console.WriteLine(ae.Message);
            }
            if (!pass)
            {
                if(shouldThrow)
                    Assert.Fail("Expected CompareException, but was not thrown.");
                else
                    Assert.Fail("Expected comparison to pass, but exception was thrown.");
            }
        }
    }
}
