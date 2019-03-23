using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moriah.Framework.Exceptions
{
    public class UserNotAuthenticatedException : DataException
    {
        public UserNotAuthenticatedException() : base("Necessário efetuar login!")
        { }
    }
}
