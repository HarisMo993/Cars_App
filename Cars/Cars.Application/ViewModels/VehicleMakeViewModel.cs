using Cars.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cars.Application.ViewModels
{
    public class VehicleMakeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
    }
}
