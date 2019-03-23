using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Web
{
    public static class ExtensionsMethods
    {
        public static bool IsPDF(this HttpPostedFileBase file)
        {
            return file.ContentType.Equals("application/pdf");
        }
    }
}
