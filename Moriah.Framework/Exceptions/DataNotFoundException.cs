using System;
using System.Runtime.Serialization;

namespace Moriah.Framework.Exceptions
{
    public class DataNotFoundException : DataException
    {
        const string msgDefault = "Dados não encontrados!";

        public DataNotFoundException() : base(msgDefault)
        {
            
        }

        public DataNotFoundException(string message) : base(message)
        {
        }

        public DataNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DataNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
