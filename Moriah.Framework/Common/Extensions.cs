using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moriah.Framework.Common
{
    public static class Extensions
    {
        public static string Encripty(this string str)
        {

            return Security.Encripity(str);

        }
    }
}
