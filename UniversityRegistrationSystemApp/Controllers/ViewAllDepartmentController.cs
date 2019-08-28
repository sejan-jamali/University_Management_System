using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityRegistrationSystemApp.Manager;
using UniversityRegistrationSystemApp.Model;

namespace UniversityRegistrationSystemApp.Controllers
{
    public class ViewAllDepartmentController : Controller
    {
        public DepartmentManager DepartmentManager { get; private set; }

        public ViewAllDepartmentController()
        {
            DepartmentManager = new DepartmentManager();
        }
        //
        // GET: /ViewAllDepartments/
        public ActionResult ViewAllDepartments()
        {
            List<Department> departmentList = new List<Department>();
            departmentList = DepartmentManager.GetAllDepartments();

            return View(departmentList);
        }
	}
}