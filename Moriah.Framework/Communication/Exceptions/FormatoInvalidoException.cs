using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Moriah.Framework.Communication.Exceptions
{
    public class FormatoInvalidoException : NumeroTelefoneInvalidoException
    {
        public FormatoInvalidoException() : base("Formato de telefone inválido!")
        {
        }

        public FormatoInvalidoException(string message) : base(message)
        {
        }

        public FormatoInvalidoException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FormatoInvalidoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
