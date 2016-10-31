using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Gunit.Core
{
    public static class Ensurer
    {
        public static void Ensure<TSource>(this TSource source, params Expression<Func<TSource, bool>>[] actions)
        {
            foreach (var expression in actions)
            {
                Ensure(source, expression);
            }
        }

        public static void Ensure<TSource>(this TSource source, Expression<Func<TSource, bool>> action)
        {
            var propertyCaller = action.Compile();
            bool result = propertyCaller(source);
            if (result) return;
            throw new EnsureException($"\nProperty check failed -> {action.ToString()}\n\n");
        }

    }
}
