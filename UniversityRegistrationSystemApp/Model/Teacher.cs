using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityRegistrationSystemApp.Model
{
    public class Teacher
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Provide Teacher's Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Provide Teacher's Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please Provide EmailAddress")]
        [EmailAddress]
        public string Email { get; set; }

        [RegularExpression("([0-9]*)", ErrorMessage = "Contact Number must be a natural number")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Contact Number Must Be 11 Digit Long!")]
        public string ContactNo { get; set; }

        [Required(ErrorMessage = "Please select a Designation")]
        public int DesignationId { get; set; }

        [Required(ErrorMessage = "Please select aDepartment")]
        public int DepartmentId { get; set; }

        [Range(0.0, Double.MaxValue, ErrorMessage = "credit must be non negative")]
        public decimal CreditTaken { get; set; }
        public decimal RemainingCredit { get; set; }
        public decimal DefaultCredit { get; set; }
    }
}