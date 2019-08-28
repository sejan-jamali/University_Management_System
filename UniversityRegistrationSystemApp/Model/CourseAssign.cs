using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityRegistrationSystemApp.Model
{
    public class CourseAssign
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Select a Department")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Please Select a Course Code")]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Please Select a Teacher's Name")]
        public int TeacherId { get; set; }

        public int Credit { get; set; }
        public decimal CreditTaken { get; set; }
        public int RemainingCredit { get; set; }
        public int Flag { get; set; }
    }
}