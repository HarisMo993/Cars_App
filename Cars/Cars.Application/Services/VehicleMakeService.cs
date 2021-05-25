using Cars.Application.Interfaces;
using Cars.Application.ViewModels;
using Cars.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cars.Application.Services
{
    public class VehicleMakeService : IVehicleMakeService
    {
        private IVehicleMakeRepository _vehicleMakeRepository;

        public VehicleMakeService(IVehicleMakeRepository vehicleMakeRepository)
        {
            _vehicleMakeRepository = vehicleMakeRepository;
        }

        public VehicleMakeViewModel GetVehicleMakes()
        {
            return new VehicleMakeViewModel()
            {
                VehicleMakes = _vehicleMakeRepository.GetAll()
            };
        }
    }
}
