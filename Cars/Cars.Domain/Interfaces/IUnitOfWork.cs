using Cars.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<VehicleMake> VehicleMake { get; }
        IRepository<VehicleModel> VehicleModel { get; }

        Task Save();
    }
}
