using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityRegistrationSystemApp.Gateway;
using UniversityRegistrationSystemApp.Model;

namespace UniversityRegistrationSystemApp.Manager
{
    public class DesignationManager
    {
        private DesignationGateway DesignationGateway;

        public DesignationManager()
        {
            DesignationGateway = new DesignationGateway();
        }

        public List<Designation> GetAllDesignation()
        {
            return DesignationGateway.GetAllDesignations();
        }

        public List<SelectListItem> GetAllDesignationForDropdown()
        {
            List<Designation> designations = GetAllDesignation();
            List<SelectListItem> selectDesignationItemsList = new List<SelectListItem>
            {
                new SelectListItem(){ Text = "---Select---", Value = ""}
            };

            foreach (Designation designation in designations)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = designation.Name;
                selectListItem.Value = designation.Id.ToString();
                selectDesignationItemsList.Add(selectListItem);
            }

            return selectDesignationItemsList;
        }
    }
}