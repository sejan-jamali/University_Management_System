using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityRegistrationSystemApp.Model
{
    public class Department
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Provide Department Name")]
        
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Provide Department Code")]
        
        public string Code { get; set; }
    }
}