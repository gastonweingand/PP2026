using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DataAccess.Interfaces
{
    internal interface IAdapter<T> where T : class
    {
        T Get(object[] values);
    }
}
