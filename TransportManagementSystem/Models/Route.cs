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
        [Required(ErrorMessage = "Route number is required!!!")]
        public int RouteNumber { get; set; }
        [Required(ErrorMessage = "Route Name is required!!!")]
        [StringLength(100, MinimumLength = 3)]
        public string RouteName { get; set; }
        [Required(ErrorMessage = "Stop-1 is mandatory  field !!!")]
        [StringLength(100, MinimumLength = 4)]

        public string Stop1 { get; set; }
        public string Stop2 { get; set; }
        public string Stop3 { get; set; }



    }
}
