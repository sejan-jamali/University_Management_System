using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityRegistrationSystemApp.Manager;
using UniversityRegistrationSystemApp.Model;

namespace UniversityRegistrationSystemApp.Controllers
{
    public class ViewResultController : Controller
    {
        public StudentManager StudentManager { get; set; }
        public ResultManager ResultManager { get; set; }

        //
        // GET: /ViewResult/

        public ViewResultController()
        {
            StudentManager = new StudentManager();
            ResultManager = new ResultManager();
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ViewResult()
        {
            ViewBag.RegList = StudentManager.GetAllStudentRegNo();
            return View();
        }

        //[HttpPost]
        //public ActionResult ViewResult()
        //{
        //    ViewBag.RegList = StudentManager.GetAllStudentRegNo();
        //    return View();
        //}
        public JsonResult GetAllInfoByStudentId(int studentId)
        {

            Student studentinfo = StudentManager.GetAllStudentInfoByStudentId(studentId);
            return Json(studentinfo);
        }

        public JsonResult GetStudentResultById(int studentId)
        {
            List<ResultViewModel> result = ResultManager.GetStudentResultById(studentId);
            return Json(result);
        }
	}
}