using Cars.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cars.Infra.Data.Context
{
    public class CarsDbContext : DbContext
    {
        public CarsDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<VehicleMake> VehicleMakes { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }

    }
}
