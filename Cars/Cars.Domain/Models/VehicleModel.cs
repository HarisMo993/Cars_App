﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cars.Domain.Models
{
    public class VehicleModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }

        [ForeignKey("VehicleMakeId")]
        public int VehicleMakeId { get; set; }
        public VehicleMake VehicleMake { get; set; }
    }
}
