using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TransportManagementSystem.Models
{
    public class Employee
    {
        [Key]
        [Required(ErrorMessage = "Id is mandatory")]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Please Enter the Employee Name")]
        [Column(TypeName = "nvarchar(50)")]
        [DataType(DataType.Text)]
        public string EmployeeName { get; set; }
        public string Gender { get; set; }

        [Required(ErrorMessage = "Please Enter the Contact Number")]
        [DataType(DataType.PhoneNumber)]
        public string EmployeeContact { get; set; }
        public int Age { get; set; }

        public string Location { get; set; }
        public string Address { get; set; }
        public int VehicleNumber { get; set; }

        [ForeignKey("VehicleNumber")]
        public Vehicle Vehicles { get; set; }

        public int RouteNumber { get; set; }

        [ForeignKey("RouteNumber")]
        public Route Routes { get; set; }

    }
}
