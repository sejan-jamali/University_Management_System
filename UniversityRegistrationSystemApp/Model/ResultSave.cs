using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityRegistrationSystemApp.Model
{
    public class ResultSave
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Provide Student Id")]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Please Provide Course Id")]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Please Provide Grade Id")]
        public int GradeId { get; set; }

    }
}