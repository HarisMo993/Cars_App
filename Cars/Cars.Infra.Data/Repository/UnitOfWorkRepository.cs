using Cars.Domain.Interfaces;
using Cars.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cars.Infra.Data.Repository
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {
        private readonly CarsDbContext _db;

        public UnitOfWorkRepository(CarsDbContext db)
        {
            _db = db;
            VehicleModel = new VehicleModelRepository(_db);
            VehicleMake = new VehicleMakeRepository(_db);
        }

        public IVehicleMakeRepository VehicleMake  { get; private set; }

        public IVehicleModelRepository VehicleModel { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
