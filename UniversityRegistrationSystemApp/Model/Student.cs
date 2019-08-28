using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityRegistrationSystemApp.Model
{
    public class Student
    {
        public int Id { get; set; }

        public string RegistrationId { get; set; }

        [Required(ErrorMessage = "Please Provide Student Name!")]
        public string Name { get; set; }

         [EmailAddress(ErrorMessage = "Please Provide Correct Email Formate!")]
        public string Email { get; set; }

         [Required(ErrorMessage = "Please Provide Contact Number!")]
         [RegularExpression("([0-9]*)", ErrorMessage = "Contact Number must be a natural number")]
         [StringLength(11, MinimumLength = 11, ErrorMessage = "Contact Number Must Be 11 Digit Long!")]
        public string ContactNo { get; set; }

        [Required(ErrorMessage = "Please Provide Student Address!")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please Provide date")]
        public string Date { get; set; }

         [Required(ErrorMessage = "Please Select a Department!")]
        public int DepartmentId { get; set; }
        public int Total { get; set; }

    }
}