using Composite;
using Services.DomainModel;
using System;

namespace Services.DataAccess.Implementations
{
    internal interface IFamiliaRepository
    {
        Familia GetById(Guid id);
    }
}