using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Moriah.Framework.Communication.Exceptions
{
    public class DDDInvalidoException : NumeroTelefoneInvalidoException
    {
        public DDDInvalidoException() : base("Código DDD inválido!")
        {
        }

        public DDDInvalidoException(string message) : base(message)
        {
        }

        public DDDInvalidoException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DDDInvalidoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
