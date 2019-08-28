using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityRegistrationSystemApp.Manager;
using UniversityRegistrationSystemApp.Model;

namespace UniversityRegistrationSystemApp.Controllers
{
    public class TeacherController : Controller
    {

        public TeacherManager TeacherManager { get; set; }
        public DepartmentManager DepartmentManager { get; set; }
        public DesignationManager DesignationManager { get; private set; }

        public TeacherController()
        {
            TeacherManager = new TeacherManager();
            DepartmentManager = new DepartmentManager();
            DesignationManager = new DesignationManager();

        }
        //
        // GET: /Teacher/
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Save()
        {
            ViewBag.DepartmentList = DepartmentManager.GetAllDepartments();
            ViewBag.DesignationList = DesignationManager.GetAllDesignation();
            return View();
        }

        [HttpPost]
        public ActionResult Save(Teacher teacher)
        {

            ViewBag.DepartmentList = DepartmentManager.GetAllDepartments();
            ViewBag.DesignationList = DesignationManager.GetAllDesignation();

            if (ModelState.IsValid)
            {
                string message = TeacherManager.Save(teacher);
           
            ViewBag.Message = message;
            
            }

            else
            {
                string message = "Validation error";
                ViewBag.Message = message;
                
            }

            return View();
            
        }
	}
}