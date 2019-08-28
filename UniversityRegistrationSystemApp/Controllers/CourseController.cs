using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityRegistrationSystemApp.Manager;
using UniversityRegistrationSystemApp.Model;

namespace UniversityRegistrationSystemApp.Controllers
{
    public class CourseController : Controller
    {
        public CourseManager CourseManager { get; set; }
        public DepartmentManager DepartmentManager { get; set; }
        public SemesterManager SemesterManager { get; set; }

        public CourseController()
        {
            CourseManager = new CourseManager();
            DepartmentManager = new DepartmentManager();
            SemesterManager = new SemesterManager();

        }
        //
        // GET: /Course/
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Save()
        {
            
                ViewBag.DepartmentList = DepartmentManager.GetAllDepartments();
            ViewBag.SemesterList = SemesterManager.GetAllSemester();
            return View();
           
            
        }
        [HttpPost]
        public ActionResult Save(Course course)
        {
            ViewBag.DepartmentList = DepartmentManager.GetAllDepartments();
            ViewBag.SemesterList = SemesterManager.GetAllSemester();

            if (ModelState.IsValid)
            {
                string message = CourseManager.Save(course);
            ViewBag.Message = message;
           

            
            }

            else
            {
                string message = "Validation error";
                ViewBag.Message = message;
                
            }
            return View();
            
        }

        [HttpGet]
        public ActionResult CourseStatics()
        {
            ViewBag.DepartmentList = DepartmentManager.GetAllDepartments();
            return View();
        }

        [HttpPost]
        public JsonResult GetAllCourseListByDepartmentId(int CLid)
        {
            List<CourseViewModel> coursesList = CourseManager.GetAllCourseListByDepartmentId(CLid);
            return Json(coursesList);
        }
	}
}