using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityRegistrationSystemApp.Model
{
    public class ClassRoom
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Select Department Name")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Please Select Course Name")]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Please Select Room Name")]
        public int RoomId { get; set; }

        [Required(ErrorMessage = "Please Select A Day")]
        public int DayId { get; set; }

        [Required(ErrorMessage = "Please Provide From Time")]
        public string TimeFrom { get; set; }

        [Required(ErrorMessage = "Please Provide To Time")]
        public string TimeTo { get; set; }
        public int Flag { get; set; }
    }
}