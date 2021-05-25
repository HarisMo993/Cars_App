
using Cars.Application.Mappings;
using Cars.Domain.Interfaces;
using Cars.Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cars.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Application Layer
            services.AddAutoMapper(typeof(Maps));

            //Infra.Data Layer
            services.AddScoped<IVehicleMakeRepository, VehicleMakeRepository>();
            services.AddScoped<IVehicleModelRepository, VehicleModelRepository>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
