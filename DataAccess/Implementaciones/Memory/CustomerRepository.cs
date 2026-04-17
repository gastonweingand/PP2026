using DataAccess.Interfaces;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Implementaciones.Memory
{
    internal class CustomerRepository : ICustomerRepository
    {
        private List<Cliente> _clienteList = new List<Cliente>();

        public CustomerRepository()
        {
            _clienteList.Add(new Cliente() { Codigo = Guid.NewGuid(), Nombre = "Pedro"  });
            _clienteList.Add(new Cliente() { Codigo = Guid.NewGuid(), Nombre = "Fernando" });
        }

        public void Add(Cliente entity)
        {
            _clienteList.Add(entity);
        }

        public void Delete(Guid id)
        {
            //Después vemos el método tradicional estructurado
            _clienteList.RemoveAll(o => o.Codigo == id);
        }

        public List<Cliente> GetAll()
        {
            return _clienteList;
        }

        public List<Cliente> GetByDate(DateTime fechaCreacionDesde, DateTime fechaCreacionHsta)
        {
            throw null;
        }

        public Cliente GetById(Guid id)
        {
            return _clienteList.FirstOrDefault(o => o.Codigo == id);
        }

        public void Update(Cliente entity)
        {
            Cliente clienteEncontrado = GetById(entity.Codigo);

            if (clienteEncontrado != null)
            {
                //Puedo actualizarlo
                clienteEncontrado.Nombre = entity.Nombre;
                clienteEncontrado.CUIT = entity.CUIT;
                clienteEncontrado.FechaNacimiento = entity.FechaNacimiento;
            }
        }
    }
}
