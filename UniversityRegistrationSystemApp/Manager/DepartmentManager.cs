using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityRegistrationSystemApp.Gateway;
using UniversityRegistrationSystemApp.Model;
using SelectListItem = System.Web.WebPages.Html.SelectListItem;

namespace UniversityRegistrationSystemApp.Manager
{
    public class DepartmentManager
    {
        private DepartmentGateway DepartmentGateway;
        public DepartmentManager()
        {
            DepartmentGateway = new DepartmentGateway();


        }

        public string Save(Department department)
        {
            if (DepartmentGateway.IsExistsName(department.Name) || DepartmentGateway.IsExistsCode(department.Code))
            {
                return "This Department Name or Code is already Exists";
            }
            else if (DepartmentGateway.IsEmpty(department.Name))
            {
                return "Cant be null";
            }
            else
            {
                if (DepartmentGateway.Save(department) > 0)
                {
                    return "Save Successful";
                }
                else
                {
                    return "Save Failed";
                }
            }
        }

        public List<Department> GetAllDepartments()
        {
            return DepartmentGateway.GetAllDepartments();
        }

        public List<SelectListItem> GetAllDepartmentForDropdown()
        {
            List<Department> departments = GetAllDepartments();
            List<SelectListItem> selectListItemsList = new List<SelectListItem>
            {
                new SelectListItem(){ Text = "---Select---", Value = ""}
            };

            foreach (Department department in departments)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = department.Name;
                selectListItem.Value = department.Id.ToString();
                selectListItemsList.Add(selectListItem);
            }

            return selectListItemsList;
        }
    }
}