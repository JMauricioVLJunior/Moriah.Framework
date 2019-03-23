using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Moriah.Framework.Exceptions
{
    public class FileNameException : FileException
    {

        const string msgDefault = "Invalid File Name!";

        private static string GerarMensagem(HttpPostedFileBase arquivo)
        {
            
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(msgDefault);
            sb.AppendLine();
            sb.AppendLine("** File Info ** ");
            sb.AppendLine(string.Format("FileName: {0}", arquivo.FileName));
            sb.AppendLine(string.Format("ContentType: {0}", arquivo.ContentType));
            sb.AppendLine(string.Format("ContentLength: {0}", arquivo.ContentLength));

            return sb.ToString();

        }

        public FileNameException(HttpPostedFileBase arquivo) : base(GerarMensagem(arquivo)) 
        {
            
        }

        public FileNameException(string message) : base(message)
        {
        }

        public FileNameException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FileNameException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
