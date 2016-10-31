using System;

namespace Gunit.Core
{
    public class EnsureException : Exception
    {
        public EnsureException(string message) : base(message) {}
    }
}