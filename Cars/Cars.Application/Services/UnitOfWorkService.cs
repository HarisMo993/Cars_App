using Cars.Application.Interfaces;
using Cars.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cars.Application.Services
{
    public class UnitOfWorkService : IUnitOfWorkService
    {
        private readonly IVehicleMakeRepository _vehicleMakeRepository;
        private readonly IVehicleModelRepository _vehicleModelRepository;

        public UnitOfWorkService(IVehicleMakeRepository vehicleMakeRepository, IVehicleModelRepository vehicleModelRepository)
        {
            _vehicleMakeRepository = vehicleMakeRepository;
            _vehicleModelRepository = vehicleModelRepository;
            VehicleMake = new VehicleMakeService(_vehicleMakeRepository);
            VehicleModel = new VehicleModelService(_vehicleModelRepository);
        }

        public IVehicleMakeService VehicleMake { get; private set; }

        public IVehicleModelService VehicleModel { get; private set; }

       
    }
}
