using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Collections
{
    public static class ExtensionsMethods
    {
        public static void RemoveAll(this IList colecao)
        {
            while (colecao.Count > 0)
            {
                colecao.RemoveAt(0);
            };
        }
    }
}
