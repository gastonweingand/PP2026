using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DataAccess.Interfaces
{
    internal interface IJoinRepository <T, Y>
    {
        List<T> GetByObject(Y obj);
        void Agregar(T obj, Y parent);
    }
}
