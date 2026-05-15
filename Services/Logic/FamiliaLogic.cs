using Services.Dal.Implementations;
using Services.DataAccess.DomainModel.Composite;
using Services.DataAccess.Interfaces;
using System;

namespace Services.Logic
{
    internal static class FamiliaLogic
    {
        private static readonly IFamiliaRepository _repo = new FamiliaRepository();

        public static void Add(Familia familia)
        {
            _repo.Add(familia);
        }

        public static void AgregarPatente(Patente patente, Familia familia)
        {
            new FamiliaPatenteRepository().Agregar(patente, familia);
        }

        public static void AgregarFamilia(Familia hijo, Familia padre)
        {
            new FamiliaFamiliaRepository().Agregar(hijo, padre);
        }

        public static Familia GetById(Guid id)
        {
            return _repo.GetById(id);
        }
    }
}
