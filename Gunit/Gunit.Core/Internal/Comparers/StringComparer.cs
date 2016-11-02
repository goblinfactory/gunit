using System;
using Gunit.Core.Logging;

namespace Gunit.Core.Internal.Comparers
{
    internal static class StringComparer
    {
        public static bool CompareByStrings(State state)
        {
            var log = state.Log;
            if (state.Type.Comparable())
            {
                if (!state.Left.ToString().Equals(state.Right.ToString()))
                {
                    var ex = new VerifyException(state.Crumb, state.FieldName, state.Left.ToString(), state.Right.ToString());
                    log.Error(ex.ToString(), state.CurrentDepth);
                    throw ex;
                }
                log.Info(state.ToString(),state.CurrentDepth);                    
                return true;
            }
            return false;
        }
    }
}
