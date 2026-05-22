using Services.DomainModel.Composite;
using System;

namespace Services.Facade
{
    public static class PatenteService
    {
        public static void Add(Patente patente)
        {
            Logic.PatenteLogic.Add(patente);
        }

        public static Patente GetById(Guid id)
        {
            return Logic.PatenteLogic.GetById(id);
        }
    }
}
