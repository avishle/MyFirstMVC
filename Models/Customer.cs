using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyFirstMVC.Models
{
    public class Customer
    {
        [Required(ErrorMessage ="requeired field")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "requeired field")]
        [StringLength(50,MinimumLength =2)]
        public string LastName { get; set; }
        [Key]
        [Required(ErrorMessage = "requeired field")]
        [RegularExpression("^[0-9]{4}$")]
        public string CustomerNumber { get; set; }
    }
}