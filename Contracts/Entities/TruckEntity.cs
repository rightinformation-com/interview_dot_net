﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Entities
{
    public class TruckEntity : IVehicle
    {
        public int Id { get; set; }
        public float Price { get; set; }
        public string Name { get; set; }
        //some other stuff
    }
}
