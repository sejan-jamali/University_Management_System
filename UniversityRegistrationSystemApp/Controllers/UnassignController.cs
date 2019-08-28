using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityRegistrationSystemApp.Manager;
using UniversityRegistrationSystemApp.Model;

namespace UniversityRegistrationSystemApp.Controllers
{
    public class UnassignController : Controller
    {
        public TeacherManager TeacherManager { get; set; }
        public ClassRoomManager ClassRoomManager { get; set; }
        //
        // GET: /Unassign/

        public UnassignController()
        {
            TeacherManager = new TeacherManager();
            ClassRoomManager = new ClassRoomManager();
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Unassing()
        {
            return View();
        }
        [HttpPost]
        //public ActionResult Unassing(Teacher c)
        //{
        //    ViewBag.Message = TeacherManager.UnassignCourses();
        //    return View();
        //}

        public ActionResult Unassing(bool? confirm)
        {
            ViewBag.Message = TeacherManager.UnassignCourses();
            return View();
        }

        [HttpGet]
        public ActionResult UnassignClassRoom()
        {

            return View();
        }

        [HttpPost]
        public ActionResult UnassignClassRoom(bool? confirm)
        {
            ViewBag.Message = ClassRoomManager.UnassignClassRoom();
            return View();
        }
	}
}