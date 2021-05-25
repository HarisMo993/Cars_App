using Cars.Application.Interfaces;
using Cars.Application.ViewModels;
using Cars.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cars.Application.Services
{
    public class VehicleModelService : IVehicleModelService
    {
        private IVehicleModelRepository _vehicleModelRepository;

        public VehicleModelService(IVehicleModelRepository vehicleModelRepository)
        {
            _vehicleModelRepository = vehicleModelRepository;
        }

        public VehicleModelViewModel GetVehicleModels()
        {
            return new VehicleModelViewModel()
            {
                VehicleModels = _vehicleModelRepository.GetAll()
            };
        }
    }
}
