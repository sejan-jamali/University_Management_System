using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityRegistrationSystemApp.Model
{
    public class CourseViewModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Semester { get; set; }
        public string AssignTeacher { get; set; }
    }
}