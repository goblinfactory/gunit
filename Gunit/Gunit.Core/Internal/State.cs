using System;
using Gunit.Core.Logging;

namespace Gunit.Core.Internal
{
    internal interface IObjectState
    {
        Type Type { get; }
        object Left { get; }
        object Right { get; }
        string Crumb { get; }
        string FieldName { get; }
        ILog Log { get; }
    }

    internal class State : IObjectState
    {
        public State(Type type, string fieldName, object left, object right, int currentDepth, int maxDepth, int toleranceMs, string crumb, ILog log)
        {
            Type = type;
            CurrentDepth = currentDepth;
            MaxDepth = maxDepth;
            FieldName = fieldName;
            Crumb = string.IsNullOrEmpty(crumb) ? fieldName : crumb;
            ToleranceMs = toleranceMs;
            Log = log;
            Left = left;
            Right = right;
        }

        public Type Type { get; private set;  }
        public object Left { get; private set; }
        public object Right { get; private set; }
        public int CurrentDepth { get; private set; }
        public int MaxDepth { get; private set; }
        public string FieldName { get; private set; }
        public string Crumb { get; private set; }
        public int ToleranceMs { get; private set; }
        public ILog Log { get; private set; }

        public State CreateChildState(Type type, string fieldname, object left, object right, string crumb)
        {
            return new State(type, fieldname, left, right, CurrentDepth + 1, MaxDepth, ToleranceMs, crumb, Log);
        }

        public override string ToString()
        {
            return Crumb;
        }
    }
}