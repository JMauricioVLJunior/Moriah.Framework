using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moriah.Framework.Common
{
    public class ReturnAction : IReturnAction
    {
        public int Id { get; set; }
        public int AffectedLines { get; set; }
        public string Log { get; set; }
        public string Message { get; set; }
        public bool Ok { get; set; }
        public Exception Exception { get; set; }
    }

    public class ReturnAction<T> : ReturnAction, IReturnAction<T>
    {
        public T DataPrimary { get; set; }
    }
    public class ReturnAction<T, X> : ReturnAction<T>, IReturnAction<T, X>
    {
        public X DataSecondary { get; set; }        
    }
}
