using Cars.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cars.Application.Interfaces
{
    public interface IVehicleModelService
    {
        VehicleModelViewModel GetVehicleModels();
    }
}
