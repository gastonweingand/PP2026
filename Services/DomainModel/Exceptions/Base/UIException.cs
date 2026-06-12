using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DomainModel.Exceptions.Base
{
    internal class UIException : ApplicationException
    {
        public UIException(): base("An unexpected error occurred in the user interface.")
        {
            
        }
    }
}
