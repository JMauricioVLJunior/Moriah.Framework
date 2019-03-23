using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moriah.Framework.Common
{
    public class ReturnAction : IReturnAction
    {
        private Exception exception;

        public int Id { get; set; }
        public int AffectedLines { get; set; }
        public string Log { get; set; }
        public string Message { get; set; }
        public bool Ok { get; set; }
        public Exception Exception
        {
            get { return exception; }
            set
            {
                exception = value;
                Message = value.Message;
            }
        }
        
        public ReturnAction(bool ok = true)
        {
            Ok = ok;
        }
    }

    public class ReturnAction<T> : ReturnAction, IReturnAction<T>
        where T : class
    {
        public T DataPrimary { get; set; }

        public ReturnAction(bool ok = true, T data = null) : base(ok)
        {
            DataPrimary = data;
        }
    }
    public class ReturnAction<T, X> : ReturnAction<T>, IReturnAction<T, X> 
        where T : class 
        where X : class
    {
        public X DataSecondary { get; set; }

        public ReturnAction(bool ok = true, T data = null, X data2 = null) : base(ok, data) 
        {
            DataSecondary = data2;
        }
    }
}
