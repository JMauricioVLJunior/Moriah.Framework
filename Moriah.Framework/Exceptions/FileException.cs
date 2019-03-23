using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Moriah.Framework.Exceptions
{

    [Serializable]
    public class FileException : Exception
    {
        public FileException() : base("Ocorreu uma exceção no arquivo!") { }
        public FileException(string message) : base(message) { }
        public FileException(string message, Exception inner) : base(message, inner) { }
        protected FileException(SerializationInfo info,StreamingContext context) : base(info, context)
        { }
    }
}
