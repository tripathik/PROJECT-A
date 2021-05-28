using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TransportManagementSystem.Models
{
    public class Allocate
    {
        [Key]
        public int AllocateId { get; set; }
        public int EmpId { get; set; }
        [ForeignKey("EmpId")]
        public  Employee Employee { get; set; }
        public int VehicleNumber { get; set; }
        [ForeignKey("VehicleNumber")]
        public Vehicle Vehicle { get; set; }
        public int RouteNumber { get; set; }
        [ForeignKey("RouteNumber")]
        public Route Route { get; set; }
    }
}
