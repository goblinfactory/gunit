using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gunit.Core
{
    public class VerifyException : Exception
    {
        public static Func<string, string, string, string> Format = (crumb, left, right) => $"{crumb} [{left}] != [{right}]";

        public string Crumb { get; private set; }
        public string FieldName { get; private set; }
        public string ExpectedLeft { get; private set; }
        public string ActualRight { get; private set; }

        public VerifyException(string crumb, string fieldName, string expectedLeft, string actualRight) : base(Format(crumb,expectedLeft,actualRight))
        {
            Crumb = crumb;
            FieldName = fieldName;
            ExpectedLeft = expectedLeft;
            ActualRight = actualRight;
        }
    }
}
