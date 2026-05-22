using Services.Dal.Implementations;
using Services.DomainModel.Composite;
using Services.DataAccess.Interfaces;
using System;

namespace Services.Logic
{
    internal static class PatenteLogic
    {
        private static readonly IPatenteRepository _repo = new PatenteRepository();

        public static void Add(Patente patente)
        {
            _repo.Add(patente);
        }

        public static Patente GetById(Guid id)
        {
            return _repo.GetById(id);
        }
    }
}
