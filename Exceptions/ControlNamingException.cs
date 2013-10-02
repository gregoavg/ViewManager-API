using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewManager_API.Exception
{
    public class ControlNamingException : System.Exception
    {
        String exceptionMessage;
        public ControlNamingException(String exceptionMessage)
        {
            this.exceptionMessage = exceptionMessage;
        }

        public override String ToString()
        {
            return this.exceptionMessage;
        }
        
    }
}
