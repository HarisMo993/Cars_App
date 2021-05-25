using Cars.Domain.Interfaces;
using Cars.Domain.Models;
using Cars.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Infra.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CarsDbContext _db;
        private IRepository<VehicleMake> _vehicleMakes;
        private IRepository<VehicleModel> _vehicleModels;

        public UnitOfWork(CarsDbContext db)
        {
            _db = db;
        }

        public IRepository<VehicleMake> VehicleMake => _vehicleMakes ??= new Repository<VehicleMake>(_db);

        public IRepository<VehicleModel> VehicleModel => _vehicleModels ??= new Repository<VehicleModel>(_db);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool dispose)
        {
            if (dispose)
            {
                _db.Dispose();
            }
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }
    }
}
