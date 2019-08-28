using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;
using UniversityRegistrationSystemApp.Gateway;
using UniversityRegistrationSystemApp.Model;


namespace UniversityRegistrationSystemApp.Manager
{
    public class DayManager
    {
        private DayGateway dayGateway;
        public DayManager()
        {
            dayGateway = new DayGateway();
        }

        public List<SelectListItem> GetAllDayForDropdown()
        {
            List<Day> days = dayGateway.GetAllDays();
            List<SelectListItem> selectListItemsList = new List<SelectListItem>
            {
                new SelectListItem(){ Text = "---Select---", Value = ""}
            };

            foreach (Day day in days)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = day.Name;
                selectListItem.Value = day.Id.ToString();
                selectListItemsList.Add(selectListItem);
            }

            return selectListItemsList;
        }
    }
}