using System;
using System.Collections.Generic;
using System.Text;

namespace Cars.Domain.Interfaces
{
    public interface IUnitOfWorkRepository : IDisposable
    {
        IVehicleMakeRepository VehicleMake { get; }
        IVehicleModelRepository VehicleModel { get; }

        void Save();
    }
}
