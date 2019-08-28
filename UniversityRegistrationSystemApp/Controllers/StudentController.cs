using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityRegistrationSystemApp.Manager;
using UniversityRegistrationSystemApp.Model;

namespace UniversityRegistrationSystemApp.Controllers
{
    public class StudentController : Controller
    {
        public StudentManager StudentManager { get; private set; }
        public DepartmentManager DepartmentManager { get; private set; }

        public StudentController()
        {
            StudentManager = new StudentManager();
            DepartmentManager = new DepartmentManager();
        }
        //
        // GET: /Student/

        [HttpGet]
        public ActionResult Save()
        {
            ViewBag.Departments = DepartmentManager.GetAllDepartments();
            return View();
        }

        [HttpPost]
        public ActionResult Save(Student student)
        {

            ViewBag.Departments = DepartmentManager.GetAllDepartments();

            if (ModelState.IsValid)
            {
                string message = StudentManager.Save(student);
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