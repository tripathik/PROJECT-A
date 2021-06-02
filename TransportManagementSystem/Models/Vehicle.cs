using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TransportManagementSystem.Models
{
    public class Vehicle
    {
        [Key]
        public int VehicleNumber { get; set; }

        
        public Employee Employee { get; set; }



        [Display(Name = "Vehicle Name")]
        [Column(TypeName = "nvarchar(30)")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage ="Please Enter the Vehicle Name")]
        [StringLength(20, MinimumLength =4,ErrorMessage ="Must be atleast 4 Characters Long")]
        public string VehicleName { get; set; }




     
        public int Capacity { get; set; }

        public int AvailableSeats { get; set; }
        public bool IsOperable { get; set; }
        public bool IsAC { get; set; }
        
    }
}
