using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Linq
{
    public static class ExtensionsMethods
    {
        public static IQueryable<T> SelectAll<T>(this IQueryable<T> type)
        {
            return type.Select(i => i);
        }
    }
}
