using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityRegistrationSystemApp.Manager;
using UniversityRegistrationSystemApp.Model;

namespace UniversityRegistrationSystemApp.Controllers
{
    public class DepartmentController : Controller
    {
        public DepartmentManager DepartmentManager { get; private set; }
        public DepartmentController()
        {
            DepartmentManager = new DepartmentManager();
            
        }
        //
        // GET: /Department/

        [HttpGet]
        public ActionResult Save()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(Department department)
        {



            if (ModelState.IsValid)
            {
                string message = DepartmentManager.Save(department);
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