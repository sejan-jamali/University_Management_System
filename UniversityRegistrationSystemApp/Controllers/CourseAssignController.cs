using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityRegistrationSystemApp.Manager;
using UniversityRegistrationSystemApp.Model;

namespace UniversityRegistrationSystemApp.Controllers
{
    public class CourseAssignController : Controller
    {
        public DepartmentManager DepartmentManager { get;private set; }
        public TeacherManager TeacherManager { get;private set; }
        public CourseManager CourseManager { get;private set; }
        //public CourseAssign CourseAssign { get;private set; }
        //
        // GET: /CourseAssign/

        public CourseAssignController()
        {
            DepartmentManager = new DepartmentManager();
            TeacherManager = new TeacherManager();
            CourseManager = new CourseManager();
            
        }
        public ActionResult Index()
        {
            
            return View();
        }
        [HttpGet]
        public ActionResult Assign()
        {
            ViewBag.DepartmentList = DepartmentManager.GetAllDepartmentForDropdown();
            //ViewBag.Message = TeacherManager.AssignSave(courseAssign);
            return View();

        }
        
        [HttpPost]
        public ActionResult Assign(CourseAssign courseAssign)
        {
            ViewBag.DepartmentList = DepartmentManager.GetAllDepartmentForDropdown();
            if (ModelState.IsValid)
            {
                
            //ViewBag.DepartmentList = DepartmentManager.GetAllDepartments();
            ViewBag.Message = TeacherManager.AssignSave(courseAssign);
           
            }

            else
            {
                string message = "Validation error";
                ViewBag.Message = message;
                
            }

            return View();
        }

        public JsonResult GetTeacherByDepartmentId(int deptId)
        {
            List<Teacher> teacherslList = TeacherManager.GetTeacherByDepartmentId(deptId);
            return Json(teacherslList);
        }


        public JsonResult GetAllCoursesByDepartmentId(int cId)
        {
            List<Course> courseslList = CourseManager.GetAllCoursesByDepartmentId(cId);
            return Json(courseslList);
        }

        public JsonResult GetCreditInfoByTeacherId(int tId)
        {
            Teacher teacherCredit = TeacherManager.CreditInfoByTeacherId(tId);
            return Json(teacherCredit);
        }

        public JsonResult GetInfoByCourseId(int id)
        {
            Course courseInfo = CourseManager.GetCourseInfoByCourseId(id);
            return Json(courseInfo);
        }

        

       
	}
}