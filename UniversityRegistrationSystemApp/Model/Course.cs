using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityRegistrationSystemApp.Model
{
    public class Course
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Provide a Course Code")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Please Provide a Course Name")]
        public string Name { get; set; }

        [Required]
        [Range(0.5, 5.0, ErrorMessage = "Credit Must be between 0.5 to 5.0")]
        public decimal Credit { get; set; }

        [Required(ErrorMessage = "Please Provide Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please Provide Department")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Please Provide Department")]
        public int SemesterId { get; set; }
    }
}