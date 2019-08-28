using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityRegistrationSystemApp.Gateway;
using UniversityRegistrationSystemApp.Model;

namespace UniversityRegistrationSystemApp.Manager
{
    public class SemesterManager
    {
        private SemesterGatway SemesterGateway;

        public SemesterManager()
        {
            SemesterGateway = new SemesterGatway();
        }
        public List<Semester> GetAllSemester()
        {
            return SemesterGateway.GetAllSemester();
        }

        public List<SelectListItem> GetAllSemesterForDropdown()
        {
            List<Semester> semesters = GetAllSemester();
            List<SelectListItem> selectSemesterItemsList = new List<SelectListItem>
            {
                new SelectListItem(){ Text = "---Select---", Value = ""}
            };

            foreach (Semester semester in semesters)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = semester.Name;
                selectListItem.Value = semester.Id.ToString();
                selectSemesterItemsList.Add(selectListItem);
            }

            return selectSemesterItemsList;
        }

    }
}