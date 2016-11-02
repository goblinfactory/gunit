using Gunit.Core.Packages.MUnit;

namespace Gunit.Core.Internal.Comparers
{
    internal static class NullComparer
    {
        public static bool BothNull(State state)
        {
            var log = state.Log;
            if (state.Left == null && state.Right == null)
            {
                log.Info($"{state.FieldName} lhs && rhs are both NULL.",state.CurrentDepth);
                return true;
            }
            if (state.Left == null)
            {
                log.Error($"{state.FieldName} lhs is NULL and rhs is NOTNULL.",state.CurrentDepth);
                throw new VerifyException(state.Crumb, state.FieldName, "NULL", "NOTNULL");
            }

            if (state.Right == null)
            {
                log.Error($"{state.FieldName} lhs is NOTNULL and rhs is NULL.",state.CurrentDepth);
                throw new VerifyException(state.Crumb, state.FieldName, "NOTNULL", "NULL");
            }
            return false;
        }
    }
}
