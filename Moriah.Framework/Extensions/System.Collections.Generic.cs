using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Collections.Generic
{
    public static class ExtensionsMethods
    {
        public static void AddRange<T>(this ICollection<T> colecao, ICollection<T> novaColecao)
        {
            if (novaColecao != null && novaColecao.Count > 0)
                foreach (var item in novaColecao)
                {
                    colecao.Add(item);
                }
        }
    }
}
