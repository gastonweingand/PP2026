using Services.DomainModel.Composite;
using System;

namespace Services.Facade
{
    public static class FamiliaService
    {
        public static void Add(Familia familia)
        {
            Logic.FamiliaLogic.Add(familia);
        }

        public static void AgregarPatente(Patente patente, Familia familia)
        {
            Logic.FamiliaLogic.AgregarPatente(patente, familia);
        }

        public static void AgregarFamilia(Familia hijo, Familia padre)
        {
            Logic.FamiliaLogic.AgregarFamilia(hijo, padre);
        }

        public static Familia GetById(Guid id)
        {
            return Logic.FamiliaLogic.GetById(id);
        }
    }
}
