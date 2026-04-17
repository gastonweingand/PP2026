using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface ICustomerRepository : IGenericRepository<Cliente>
    {
        //Agregar método de filtros por ejemplo
        List<Cliente> GetByDate(DateTime fechaCreacionDesde, DateTime fechaCreacionHsta);
    }
}
