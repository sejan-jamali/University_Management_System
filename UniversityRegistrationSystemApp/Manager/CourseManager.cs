using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityRegistrationSystemApp.Gateway;
using UniversityRegistrationSystemApp.Model;

namespace UniversityRegistrationSystemApp.Manager
{
    public class CourseManager
    {
        private CourseGateway CourseGateway;

        public CourseManager()
        {
            CourseGateway = new CourseGateway();
        }

        public string Save(Course course)
        {
            if (CourseGateway.IsExistsName(course.Name) || CourseGateway.IsExistsCode(course.Code))
            {
                return "This Course Name or Code is already Exists";
            }
            else if (CourseGateway.IsEmpty(course.Name))
            {
                return "Cant be null";
            }
            else
            {

                if (CourseGateway.Save(course) > 0)
                {
                    return "Saved";
                }
                else
                {
                    return "try again";
                }
            }
        }

        public List<Course> GetAllcCourses()
        {
            return CourseGateway.GetAllCourses();
        }

        public List<Course> GetAllCoursesByDepartmentId(int id)
        {
            return CourseGateway.GetAllCoursesByDepartmentId(id);
        }

        public Course GetCourseInfoByCourseId(int id)
        {
            return CourseGateway.GetCourseInfoByCourseId(id);
        }

        public List<SelectListItem> GetAllCourseForDropdown()
        {
            List<Course> courses = GetAllcCourses();
            List<SelectListItem> selectCourseItemsList = new List<SelectListItem>
            {
                new SelectListItem() {Text = "---Select---", Value = ""}
            };

            foreach (Course course in courses)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = course.Name;
                selectListItem.Value = course.Id.ToString();
                selectCourseItemsList.Add(selectListItem);
            }

            return selectCourseItemsList;
        }

        public List<CourseViewModel> GetAllCourseListByDepartmentId(int CLid)
        {
            return CourseGateway.GetAllCourseListByDepartmentId(CLid);
        }

        public List<Course> GetAllCourseByStudentId(int studentId)
        {
            return CourseGateway.GetAllCourseByStudentId(studentId);
        }
    }
}