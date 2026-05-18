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

        void Delete(T obj);

        void Add(T obj, Y parent);

        void AddRange(List<T> children, Y parent);
    }
}
