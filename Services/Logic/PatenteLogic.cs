using Composite;
using Services.Dal.Implementations;
using Services.DataAccess.Interfaces;
using System;

namespace Services.Logic
{
    internal static class PatenteLogic
    {
        private static readonly IPatenteRepository _repo = new PatenteRepository();

        public static void Agregar(Patente patente)
        {
            _repo.Agregar(patente);
        }

        public static Patente GetById(Guid id)
        {
            return _repo.GetById(id);
        }
    }
}
