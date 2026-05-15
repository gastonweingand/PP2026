using Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DataAccess.Interfaces
{
    internal interface IPatenteRepository
    {
        Patente GetById(Guid id);
    }
}
