using DataAccess.Interfaces;
using DomainModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Implementaciones.SqlServer.Adaptadores
{

    public sealed class ClienteAdaptador : IAdaptador<Cliente>
    {
        #region singleton
        private readonly static ClienteAdaptador _instance = new ClienteAdaptador();

        public static ClienteAdaptador Current
        {
            get
            {
                return _instance;
            }
        }

        private ClienteAdaptador()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public Cliente Fill(object[] values)
        {
            return new Cliente
            {
                IdCliente = (Guid)values[0],
                Nombre = (string)values[1],
                CUIT = (string)values[2],
                FechaNacimiento = (DateTime)values[3]
            };
        }

        /// <summary>
        /// Si se desea se puede hacer más declarativo el índice en cuestión
        /// </summary>
        private enum Columnas
        {
            IdCliente = 0,
            Nombre = 1,
            CUIT = 2,
            FechaNacimiento = 3
        }
    }
}
