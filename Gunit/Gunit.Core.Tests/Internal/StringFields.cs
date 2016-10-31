using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gunit.Core.Tests.Internal
{
    public enum Weekday {  Monday, Tuesday, Wednesday, Thursday, Friday }

    public class StringFields
    {
        public byte Loop { get; set; }
        public float Distance { get; set; }
        public char Initial { get; set; }
        public char InitialNullable { get; set; }
        public bool Done { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public Weekday Day { get; set; }
        public short Gap { get; set; }
        public long BigNum { get; set; }
        public int Laps { get; set; }
        public int? LapsNullable { get; set; }
        public DateTime Born { get; set; }

    }

}
