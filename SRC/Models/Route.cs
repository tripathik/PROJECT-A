using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TransportManagementSystem.Models
{
   
    public class Route
    {
        [Key]
        public int RouteNumber { get; set; }
        public string Stop { get; set; }
        

        public List<Vehicle> Vehicles { get; set; }

       

    }
}
