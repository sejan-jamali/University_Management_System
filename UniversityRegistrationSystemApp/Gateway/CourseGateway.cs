using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityRegistrationSystemApp.Model;

namespace UniversityRegistrationSystemApp.Gateway
{
    public class CourseGateway : BaseGateway
    {
        public int Save(Course course)
        {
            string query =
                "INSERT INTO Course(Code, Name, Credit, Description, DepartmentID, SemesterId) VALUES(@code, @name, @credit,@description, @departmentId, @semesterId)";
            SqlCommand = new SqlCommand(query,SqlConnection);
            SqlCommand.Parameters.AddWithValue("@code", course.Code);
            SqlCommand.Parameters.AddWithValue("@Name", course.Name);
            SqlCommand.Parameters.AddWithValue("@Credit", course.Credit);
            SqlCommand.Parameters.AddWithValue("@Description", course.Description);
            SqlCommand.Parameters.AddWithValue("@DepartmentID", course.DepartmentId);
            SqlCommand.Parameters.AddWithValue("@SemesterId", course.SemesterId);
            //SqlCommand.Parameters.AddWithValue("@code", course.Code);
            SqlConnection.Open();
            int rowEffect = SqlCommand.ExecuteNonQuery();
            SqlConnection.Close();
            return rowEffect;
        }

        public bool IsExistsName(string courseName)
        {

            string query = "SELECT * FROM Course WHERE Name=@courseName";
            SqlCommand = new SqlCommand(query, SqlConnection);
            SqlCommand.Parameters.AddWithValue("@courseName", courseName);
            SqlConnection.Open();
            SqlDataReader = SqlCommand.ExecuteReader();
            bool isExists = SqlDataReader.HasRows;
            SqlConnection.Close();
            return isExists;
        }

        public bool IsEmpty(string courseName)
        {
            bool isEmpty = string.IsNullOrEmpty(courseName);
            return isEmpty;
        }

        public bool IsExistsCode(string courseCode)
        {

            string query = "SELECT * FROM Course WHERE Code=@courseCode";
            SqlCommand = new SqlCommand(query, SqlConnection);
            SqlCommand.Parameters.AddWithValue("@courseCode", courseCode);
            SqlConnection.Open();
            SqlDataReader = SqlCommand.ExecuteReader();
            bool isExists = SqlDataReader.HasRows;
            SqlConnection.Close();
            return isExists;
        }

        public List<Course> GetAllCourses()
        {

            string query = "SELECT * FROM Teacher";
            SqlCommand = new SqlCommand(query, SqlConnection);
            SqlConnection.Open();
            SqlDataReader = SqlCommand.ExecuteReader();
            List<Course> coursesList = new List<Course>();

            while (SqlDataReader.Read())
            {
                Course input = new Course();
                input.Code = SqlDataReader["Code"].ToString();
                coursesList.Add(input);
            }
            SqlDataReader.Close();
            SqlConnection.Close();
            return coursesList;
        }

        public List<Course> GetAllCoursesByDepartmentId(int id)
        {
            string query = "SELECT Id, Code, Name FROM Course WHERE DepartmentId = @departmentId";
            SqlCommand = new SqlCommand(query, SqlConnection);
            SqlCommand.Parameters.AddWithValue("@departmentId", id);
            SqlConnection.Open();
            SqlDataReader = SqlCommand.ExecuteReader();
            List<Course> courses = new List<Course>();

            while (SqlDataReader.Read())
            {
                Course aCourse = new Course();
                aCourse.Id = Convert.ToInt32(SqlDataReader["Id"]);
                aCourse.Code = SqlDataReader["Code"].ToString();
                aCourse.Name = SqlDataReader["Name"].ToString();
                courses.Add(aCourse);
            }
            SqlDataReader.Close();
            SqlConnection.Close();
            return courses;
        }

        public Course GetCourseInfoByCourseId(int id)
        {
            string query = "SELECT Id, Code, Name, Credit FROM Course WHERE Id=@id";
            SqlCommand = new SqlCommand(query, SqlConnection);
            SqlCommand.Parameters.AddWithValue("@id", id);
            SqlConnection.Open();
            SqlDataReader = SqlCommand.ExecuteReader();
            //List<Teacher> teacherList = new List<Teacher>();
            Course input = null;
            if (SqlDataReader.HasRows)
            {
                SqlDataReader.Read();
                input = new Course();
                input.Id = Convert.ToInt32(SqlDataReader["Id"]);
                input.Code = SqlDataReader["Code"].ToString();
                input.Name = SqlDataReader["Name"].ToString();
                input.Credit = Convert.ToDecimal(SqlDataReader["Credit"]);
                
            }

            SqlDataReader.Close();
            SqlConnection.Close();
            return input;
        }


        public List<CourseViewModel> GetAllCourseListByDepartmentId(int CLid)
        {

            string query =
                "SELECT Course.Code AS CourseCode, Course.Name AS CourseName, Semester.Name AS Semester, Teacher.Name AS AssignTeache From Course LEFT JOIN Department ON  Course.DepartmentId = Department.Id LEFT JOIN Semester on Semester.Id = Course.SemesterId LEFT JOIN CourseAssign on Course.Id = CourseAssign.CourseId LEFT JOIN Teacher on Teacher.Id = CourseAssign.TeacherId AND CourseAssign.Flag=1 WHERE Department.Id = @CLid";

            SqlCommand = new SqlCommand(query, SqlConnection);
            SqlCommand.Parameters.AddWithValue("@CLid", CLid);
            SqlConnection.Open();
            SqlDataReader = SqlCommand.ExecuteReader();
            List<CourseViewModel> courseList = new List<CourseViewModel>();

            while (SqlDataReader.Read())
            {
                CourseViewModel courseViewModel = new CourseViewModel();
                courseViewModel.Code = SqlDataReader["CourseCode"].ToString();
                courseViewModel.Name = SqlDataReader["CourseName"].ToString();
                courseViewModel.Semester = SqlDataReader["Semester"].ToString();
                courseViewModel.AssignTeacher = SqlDataReader["AssignTeache"].ToString();
                string flag = courseViewModel.AssignTeacher;
                if (string.IsNullOrEmpty(flag))
                {
                    courseViewModel.AssignTeacher = "Not Assign Yet";
                }
                courseList.Add(courseViewModel);
            }
            SqlDataReader.Close();
            SqlConnection.Close();
            return courseList;

        }

        public List<Course> GetAllCourseByStudentId(int studentId)
        {
            string query = "SELECT Course.Id,Course.Code FROM Course INNER JOIN Student ON Course.DepartmentId=Student.DepartmentId AND Student.Id=@StudentId";
            SqlCommand = new SqlCommand(query, SqlConnection);
            SqlCommand.Parameters.AddWithValue("@StudentId", studentId);
            SqlConnection.Open();
            List<Course> allCourseList = new List<Course>();
            SqlDataReader = SqlCommand.ExecuteReader();
            while (SqlDataReader.Read())
            {
                Course aCourse = new Course();
                aCourse.Id = Convert.ToInt32(SqlDataReader["Id"]);
                aCourse.Code = SqlDataReader["Code"].ToString();
                allCourseList.Add(aCourse);
            }
            SqlDataReader.Close();
            SqlConnection.Close();
            return allCourseList;
        }
    }

}