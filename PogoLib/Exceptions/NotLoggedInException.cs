using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PogoLib.Exceptions
{
    public class NotLoggedInException : Exception
    {
        public override string Message
        {
            get
            {
                return "You must be logged in to use this method";
            }
        }
    }
}
