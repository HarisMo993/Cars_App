using AutoMapper;
using Cars.Application.ViewModels;
using Cars.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cars.Application.Mappings
{
    public class Maps : Profile
    {
        public Maps()
        {
            CreateMap<VehicleMake, VehicleMakeViewModel>().ReverseMap();
            CreateMap<VehicleModel, VehicleModelViewModel>().ReverseMap();
        }
    }
}
