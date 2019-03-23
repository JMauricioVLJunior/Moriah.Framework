using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moriah.Framework.Common
{
        public interface IReturnAction
        {
            bool Ok { get; }
            int AffectedLines { get; }
            string Message { get; }
            string Log { get; }
            int Id { get; }
            Exception Exception { get; }

        }

        public interface IReturnAction<T> : IReturnAction
        {
            T DataPrimary { get; }
        }

        public interface IReturnAction<T, X> : IReturnAction<T>
        {
            X DataSecondary { get; }
        }
    
}
