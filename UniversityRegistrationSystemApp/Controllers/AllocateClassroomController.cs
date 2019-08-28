using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityRegistrationSystemApp.Manager;
using UniversityRegistrationSystemApp.Model;

namespace UniversityRegistrationSystemApp.Controllers
{
    public class AllocateClassroomController : Controller
    {
        //
        // GET: /AllocateClassroom/
        public DepartmentManager DepartmentManager { get; set; }
        public RoomManager RoomManager { get; set; }
        public DayManager DayManager { get; set; }
        public CourseManager CourseManager { get; set; }
        public ClassRoomManager ClassRoomManager { get; set; }

        public AllocateClassroomController()
        {
            DepartmentManager = new DepartmentManager();
            RoomManager=new RoomManager();
            DayManager=new DayManager();
            CourseManager=new CourseManager();
            ClassRoomManager = new ClassRoomManager();
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Allocate()
        {
            ViewBag.departments = DepartmentManager.GetAllDepartmentForDropdown();
            ViewBag.rooms = RoomManager.GetAllRoomForDropdown();
            ViewBag.days = DayManager.GetAllDayForDropdown();
            return View();
        }
        [HttpPost]
        public ActionResult Allocate(ClassRoom cr)
        {
            ViewBag.departments = DepartmentManager.GetAllDepartmentForDropdown();
            ViewBag.rooms = RoomManager.GetAllRoomForDropdown();
            ViewBag.days = DayManager.GetAllDayForDropdown();
            if (ModelState.IsValid)
            {
                
            ViewBag.Message = ClassRoomManager.Save(cr);

            return View();
            }

            else
            {
                string message = "Validation error";
                ViewBag.Message = message;
                
            }
            return View();
        }

        [HttpGet]
        public ActionResult ViewSchedule()
        {
            ViewBag.DepartmentList = DepartmentManager.GetAllDepartments();
            return View();
        }
        [HttpPost]
        public JsonResult GetScheduleInfoByDeptmentId(int CLid)
        {
            List<Schedule> coursesList = ClassRoomManager.GetScheduleInfoByDeptmentId(CLid);
            return Json(coursesList);
        }

        public JsonResult GetAllCoursesByDepartmentId(int deptId)
        {
            List<Course> courseslList = CourseManager.GetAllCoursesByDepartmentId(deptId);
            return Json(courseslList);
        }
	}
}