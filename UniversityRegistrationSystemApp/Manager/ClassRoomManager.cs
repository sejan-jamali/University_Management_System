using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityRegistrationSystemApp.Gateway;
using UniversityRegistrationSystemApp.Model;

namespace UniversityRegistrationSystemApp.Manager
{
    public class ClassRoomManager
    {
        private ClassRoomGateway classRoomGateway;

        public ClassRoomManager()
        {
            classRoomGateway = new ClassRoomGateway();
        }

        public string Save(ClassRoom classRoom)
        {
            if (classRoomGateway.CheckSlot(classRoom) && classRoomGateway.CheckSlot2(classRoom))
            {
                return "Slot already Booked";
            }
            else
            {
                if (classRoomGateway.Save(classRoom) > 0)
                {
                    return "Saved";
                }
                else
                {
                    return "Not saved";
                }
            }
        }

        public string UnassignClassRoom()
        {
            if (classRoomGateway.UnassignClassRoom() > 0)
            {
                return "Updated";
            }
            else
            {
                return "Not Updated";
            }
        }

        public List<Schedule> GetScheduleInfoByDeptmentId(int CLid)
        {
            return classRoomGateway.GetScheduleInfoByDeptmentId(CLid);
        }

    }
}