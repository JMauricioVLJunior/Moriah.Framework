using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Moriah.Framework.Exceptions
{
    public class FileFormatException : FileException
    {

        const string msgDefault = "Formato do Arquivo Inválido!";

        private static string GerarMensagem(HttpPostedFileBase arquivo)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(msgDefault);
            sb.AppendLine();
            sb.AppendLine("** Informações do Arquivo ** ");
            sb.AppendLine(string.Format("ContentType: {0}", arquivo.ContentType));
            sb.AppendLine(string.Format("ContentLength: {1}", arquivo.ContentLength));
            sb.AppendLine(string.Format("FileName: {0}", arquivo.FileName));

            return sb.ToString();

        }

        public FileFormatException(HttpPostedFileBase arquivo) : base(GerarMensagem(arquivo)) 
        {
            
        }

        public FileFormatException(string message) : base(message)
        {
        }

        public FileFormatException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FileFormatException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
