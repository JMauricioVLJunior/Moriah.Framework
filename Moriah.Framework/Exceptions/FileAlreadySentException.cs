using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Moriah.Framework.Exceptions
{
    
    public class FileAlreadySentException : FileException
    {
        public FileAlreadySentException() : base("Arquivo já enviado!")
        {
        }

        public FileAlreadySentException(string message) : base(message)
        {            
        }

        public FileAlreadySentException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FileAlreadySentException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
 