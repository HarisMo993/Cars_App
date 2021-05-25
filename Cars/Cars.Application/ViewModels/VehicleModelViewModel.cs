using Cars.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cars.Application.ViewModels
{
    public class VehicleModelViewModel
    {
        public IEnumerable<VehicleModel> VehicleModels { get; set; }
    }
}
