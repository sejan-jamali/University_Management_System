using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityRegistrationSystemApp.Model
{
    public class StudentEnroll
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Select Student Reg No")]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Please Select Course")]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Please Select Date")]
        public string Date { get; set; }
    }
}