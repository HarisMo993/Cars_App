using System;
using System.Collections.Generic;
using System.Text;

namespace Cars.Application.Interfaces
{
    public interface IUnitOfWorkService
    {
        IVehicleMakeService VehicleMake { get; }
        IVehicleModelService VehicleModel { get; }
    }
}
