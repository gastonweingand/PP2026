using Composite;
using System;

namespace Services.Facade
{
    public static class PatenteService
    {
        public static void Agregar(Patente patente)
        {
            Logic.PatenteLogic.Agregar(patente);
        }

        public static Patente GetById(Guid id)
        {
            return Logic.PatenteLogic.GetById(id);
        }
    }
}
