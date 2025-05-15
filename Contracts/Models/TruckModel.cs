using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Models
{
    public class TruckModel : IVehicle
    {
        public int Id { get; set; }
        public float Price { get; set; }
        public string Name { get; set; }
        //some other stuff
    }
}
