using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityRegistrationSystemApp.Manager;
using UniversityRegistrationSystemApp.Model;

namespace UniversityRegistrationSystemApp.Controllers
{
    public class ResultController : Controller
    {
        public ResultManager ResultManager { get; set; }
        public StudentManager StudentManager { get; set; }
        public CourseManager CourseManager { get; set; }

        //
        // GET: /Result/

        public ResultController()
        {
            ResultManager = new ResultManager();
            StudentManager = new StudentManager();
            CourseManager = new CourseManager();
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SaveResult()
        {
            ViewBag.RegList = StudentManager.GetAllStudentRegNo();
            ViewBag.allGradelist = ResultManager.GetAllGradeList();
            return View();
        }

        [HttpPost]
        public ActionResult SaveResult(ResultSave resultSave)
        {

            ViewBag.RegList = StudentManager.GetAllStudentRegNo();
            ViewBag.allGradelist = ResultManager.GetAllGradeList();


            if (ModelState.IsValid)
            {
                
            ViewBag.Message = ResultManager.SaveStudentResult(resultSave);
      
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