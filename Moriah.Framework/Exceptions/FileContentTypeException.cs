using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Moriah.Framework.Exceptions
{
    public class FileContentTypeException : FileException
    {
        public FileContentTypeException(string ContentType) : base(string.Format("O Tipo de Conteúdo do Arquivo é inválido! ({0})", ContentType))
        {
        }

        public FileContentTypeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FileContentTypeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
