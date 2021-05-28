using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TransportManagementSystem.Models
{
    public class Vehicle
    {
        [Key]
        public int VehicleNumber { get; set; }
        public string VehicleName { get; set; }
        public string DriverName { get; set; }
        public string DriverContact { get; set; }
        public int Capacity { get; set; }
        public int AvailableSeats { get; set; }
        public bool IsOperable { get; set; }
        public bool IsAC { get; set; }
    }
}
