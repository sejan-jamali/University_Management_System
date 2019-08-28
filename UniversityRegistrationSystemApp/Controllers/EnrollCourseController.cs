using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityRegistrationSystemApp.Manager;
using UniversityRegistrationSystemApp.Model;

namespace UniversityRegistrationSystemApp.Controllers
{
    public class EnrollCourseController : Controller
    {
        private StudentManager StudentManager { get; set; }
        private CourseManager CourseManager { get; set; }
        private EnrollManager EnrollManager { get; set; }
        //
        // GET: /EnrollCourse/
        public EnrollCourseController()
        {
            StudentManager = new StudentManager();
            CourseManager = new CourseManager();
            EnrollManager = new EnrollManager();
        }
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult EnrollSave()
        {
            ViewBag.RegList = StudentManager.GetAllStudentRegNo();
            //ViewBag.CourseList = CourseManager.GetAllcCourses();
            return View();
        }

        [HttpPost]
        public ActionResult EnrollSave(StudentEnroll studentEnroll)
        {
            ViewBag.RegList = StudentManager.GetAllStudentRegNo();
            if (ModelState.IsValid)
            {
               
            ViewBag.Message = EnrollManager.EnrollCourse(studentEnroll);
            
            }

            else
            {
                string message = "Validation error";
                ViewBag.Message = message;
                
            }
            return View();
            
        }

        public JsonResult GetCourseByStudentId(int studentId)
        {
            List<Course> courseList = CourseManager.GetAllCourseByStudentId(studentId);
            return Json(courseList);
        }

        public JsonResult GetAllInfoByStudentId(int studentId)
        {

            Student studentinfo = StudentManager.GetAllStudentInfoByStudentId(studentId);
            return Json(studentinfo);
        }
	}
}