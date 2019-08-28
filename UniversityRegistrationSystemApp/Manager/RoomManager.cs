using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;
using UniversityRegistrationSystemApp.Gateway;
using UniversityRegistrationSystemApp.Model;

namespace UniversityRegistrationSystemApp.Manager
{
    public class RoomManager
    {
        private RoomGateway roomGateway;
        public RoomManager()
        {
            roomGateway = new RoomGateway();
        }

        public List<SelectListItem> GetAllRoomForDropdown()
        {
            List<Room> rooms = roomGateway.GetAllRooms();
            List<SelectListItem> selectListItemsList = new List<SelectListItem>
            {
                new SelectListItem(){ Text = "---Select---", Value = ""}
            };

            foreach (Room room in rooms)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = room.Name;
                selectListItem.Value = room.Id.ToString();
                selectListItemsList.Add(selectListItem);
            }

            return selectListItemsList;
        }
    }
}