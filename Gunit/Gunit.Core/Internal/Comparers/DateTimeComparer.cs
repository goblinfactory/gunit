using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gunit.Core.Logging;

namespace Gunit.Core.Internal.Comparers
{
    internal static class DateTimeComparer
    {
        public static bool Compare(State state)
        {
            if (!(state.Left is DateTime)) return false;
            var left = (DateTime)state.Left;
            var right = (DateTime) state.Right;
            var diff = Math.Abs(left.Subtract(right).TotalMilliseconds);

            if (diff > state.ToleranceMs)
            {
                var expected = $"{left} [{left.Ticks}] ticks";
                var actual = $"{right} [{right.Ticks}] ticks";
                throw new VerifyException(state.Crumb, state.FieldName, expected, actual);
            };
            return true;
        }
    }
}
