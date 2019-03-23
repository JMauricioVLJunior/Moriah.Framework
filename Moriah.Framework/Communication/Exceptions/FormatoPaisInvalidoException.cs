using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Moriah.Framework.Communication.Exceptions
{
    public class FormatoPaisInvalidoException : NumeroTelefoneInvalidoException
    {
        public FormatoPaisInvalidoException() : base("Formato do país no número de telefone inválido!")
        {
        }

        public FormatoPaisInvalidoException(string message) : base(message)
        {
        }

        public FormatoPaisInvalidoException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FormatoPaisInvalidoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
