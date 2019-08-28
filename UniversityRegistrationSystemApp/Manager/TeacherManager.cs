using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityRegistrationSystemApp.Gateway;
using UniversityRegistrationSystemApp.Model;

namespace UniversityRegistrationSystemApp.Manager
{
    public class TeacherManager
    {
        private TeacherGateway TeacherGateway;

        public TeacherManager()
        {
            TeacherGateway = new TeacherGateway();
        }

        public string UnassignCourses()
        {
            if (TeacherGateway.UnassignCourses() > 0)
            {
                return "Updated";
            }
            else
            {
                return "Not Updated";
            }
        }
        public string Save(Teacher teacher)
        {
            if (TeacherGateway.IsExistsName(teacher.Name) || TeacherGateway.IsEmpty(teacher.Name))
            {
                return "This Teacher Name orEmpty";
            }
            
            else
            {


                if (TeacherGateway.Save(teacher) > 0)
                {
                    return "Saved";
                }
                else
                {
                    return "Not saved";
                }
            }
        }

        public List<Teacher> GetAllTeacher()
        {
            return TeacherGateway.GetAllTeacher();
        }

        public List<Teacher> GetTeacherByDepartmentId(int id)
        {
            return TeacherGateway.GetTeacherByDepartmentId(id);
        }

        public string AssignSave(CourseAssign courseAssign)
        {
            if (TeacherGateway.AssignSave(courseAssign) > 0)
            {
                return "Saved";
            }
            else
            {
                return "Not saved";
            }
        }

        public Teacher CreditInfoByTeacherId(int tId)
        {
            return TeacherGateway.CreditInfoByTeacherId(tId);
        }

        public List<SelectListItem> GetAllTeacherForDropdown()
        {
            List<Teacher> teachers = GetAllTeacher();
            List<SelectListItem> selectTeacherItemsList = new List<SelectListItem>
            {
                new SelectListItem(){ Text = "---Select---", Value = ""}
            };

            foreach (Teacher teacher in teachers)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = teacher.Name;
                selectListItem.Value = teacher.Id.ToString();
                selectTeacherItemsList.Add(selectListItem);
            }

            return selectTeacherItemsList;
        }
    }
}