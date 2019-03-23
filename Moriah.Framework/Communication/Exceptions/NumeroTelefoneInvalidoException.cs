using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Moriah.Framework.Communication.Exceptions
{
    public class NumeroTelefoneInvalidoException : Exception
    {
        public NumeroTelefoneInvalidoException() : base("Número de telefone inválido!")
        {
        }

        public NumeroTelefoneInvalidoException(string message) : base(message)
        {
        }

        public NumeroTelefoneInvalidoException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NumeroTelefoneInvalidoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
