using Cars.Domain.Interfaces;
using Cars.Domain.Models;
using Cars.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cars.Infra.Data.Repository
{
    public class VehicleModelRepository : Repository<VehicleModel>, IVehicleModelRepository
    {
        private readonly CarsDbContext _db;

        public VehicleModelRepository(CarsDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
