using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using UniversityRegistrationSystemApp.Model;

namespace UniversityRegistrationSystemApp.Gateway
{
    public class TeacherGateway : BaseGateway
    {

        public int Save(Teacher teacher)
        {
            string query =
                "INSERT INTO Teacher(Name, Address, Email, ContactNo, DesignationId, DepartmentID, CreditTaken) VALUES(@name, @address,@email, @contactno, @designationid, @departmentId, @credittaken)";
            SqlCommand = new SqlCommand(query, SqlConnection);
            SqlCommand.Parameters.AddWithValue("@name", teacher.Name);
            SqlCommand.Parameters.AddWithValue("@address", teacher.Address);
            SqlCommand.Parameters.AddWithValue("@email", teacher.Email);
            SqlCommand.Parameters.AddWithValue("@contactno", teacher.ContactNo);
            SqlCommand.Parameters.AddWithValue("@designationid", teacher.DesignationId);
            SqlCommand.Parameters.AddWithValue("@departmentId", teacher.DepartmentId);
            SqlCommand.Parameters.AddWithValue("@credittaken", teacher.CreditTaken);
            SqlConnection.Open();
            int rowEffect = SqlCommand.ExecuteNonQuery();
            SqlConnection.Close();
            return rowEffect;
        }

        public bool IsExistsName(string teachertName)
        {

            string query = "SELECT * FROM Teacher WHERE Name=@teachertName";
            SqlCommand = new SqlCommand(query, SqlConnection);
            SqlCommand.Parameters.AddWithValue("@teachertName", teachertName);
            SqlConnection.Open();
            SqlDataReader = SqlCommand.ExecuteReader();
            bool isExists = SqlDataReader.HasRows;
            SqlConnection.Close();
            return isExists;
        }

        public bool IsEmpty(string teachertName)
        {
            bool isEmpty = string.IsNullOrEmpty(teachertName);
            return isEmpty;
        }

        public List<Teacher> GetAllTeacher()
        {

            string query = "SELECT * FROM Teacher";
            SqlCommand = new SqlCommand(query, SqlConnection);
            SqlConnection.Open();
            SqlDataReader = SqlCommand.ExecuteReader();
            List<Teacher> teacherList = new List<Teacher>();

            while (SqlDataReader.Read())
            {
                Teacher input = new Teacher();
                input.Name = SqlDataReader["Name"].ToString();
                teacherList.Add(input);
            }
            SqlDataReader.Close();
            SqlConnection.Close();
            return teacherList;
        }

        public List<Teacher> GetTeacherByDepartmentId(int id)
        {
            string query = "SELECT Id, Name,CreditTaken,RemainingCredit FROM Teacher WHERE DepartmentId = @departmentId";
            SqlCommand = new SqlCommand(query, SqlConnection);
            SqlCommand.Parameters.AddWithValue("@departmentId", id);
            SqlConnection.Open();
            SqlDataReader = SqlCommand.ExecuteReader();
            List<Teacher> teachers = new List<Teacher>();

            while (SqlDataReader.Read())
            {
                Teacher aTeacher = new Teacher();
                aTeacher.Id = Convert.ToInt32(SqlDataReader["Id"]);
                aTeacher.Name = SqlDataReader["Name"].ToString();
//---
                aTeacher.CreditTaken = Convert.ToDecimal(SqlDataReader["CreditTaken"]);
                aTeacher.RemainingCredit = Convert.ToDecimal(SqlDataReader["RemainingCredit"]);
                
                teachers.Add(aTeacher);
            }
            SqlDataReader.Close();
            SqlConnection.Close();
            return teachers;
        }

        public Teacher CreditInfoByTeacherId(int tId)
        {
            string query = "SELECT Id,CreditTaken,RemainingCredit FROM Teacher WHERE ID=@tId";
            SqlCommand = new SqlCommand(query, SqlConnection);
            SqlCommand.Parameters.AddWithValue("@tId", tId);
            SqlConnection.Open();
            SqlDataReader = SqlCommand.ExecuteReader();
            Teacher input = null;
            if (SqlDataReader.HasRows)
            {
                SqlDataReader.Read();
                input = new Teacher();
                input.Id = Convert.ToInt32(SqlDataReader["Id"]);
                input.CreditTaken = Convert.ToDecimal(SqlDataReader["CreditTaken"]);
                input.RemainingCredit = Convert.ToDecimal(SqlDataReader["RemainingCredit"]);
            }
            
            SqlDataReader.Close();
            SqlConnection.Close();
            return input;
        }

        public int AssignSave(CourseAssign courseAssign)
        {
            int rCredit = UpdateCredit(courseAssign.TeacherId,courseAssign.Credit);
            
            string query =
                "INSERT INTO CourseAssign(DepartmentId, TeacherId, CourseId,CreditTaken, Flag) VALUES(@DepartmentId, @TeacherId,@CourseId,@CreditTaken, @flag)";
            SqlCommand = new SqlCommand(query, SqlConnection);
            SqlCommand.Parameters.AddWithValue("@DepartmentId", courseAssign.DepartmentId);
            SqlCommand.Parameters.AddWithValue("@TeacherId", courseAssign.TeacherId);
            SqlCommand.Parameters.AddWithValue("@CourseId", courseAssign.CourseId);
            SqlCommand.Parameters.AddWithValue("@CreditTaken", courseAssign.Credit);
            SqlCommand.Parameters.AddWithValue("@flag", 1);
            //SqlCommand.Parameters.AddWithValue("@CreditTaken", courseAssign.);
            //SqlCommand.Parameters.AddWithValue("@RemainingCredit", courseAssign.RemainingCredit);
            //SqlCommand.Parameters.AddWithValue("1", courseAssign.Flag);
            //SqlCommand.Parameters.AddWithValue("@credittaken", courseAssign.);
            SqlConnection.Open();
            int rowEffect = SqlCommand.ExecuteNonQuery();
            SqlConnection.Close();
            return rowEffect;
        }

        private int UpdateCredit(int id,int credit)
        {
            string query =
                "UPDATE Teacher SET RemainingCredit+=@credit WHERE Id=@id";
            SqlCommand = new SqlCommand(query, SqlConnection);
            SqlCommand.Parameters.AddWithValue("@id", id);
            SqlCommand.Parameters.AddWithValue("@credit", credit);
            
            SqlConnection.Open();
            int rowEffect = SqlCommand.ExecuteNonQuery();
            SqlConnection.Close();
            return rowEffect;
        }

        public int UnassignCourses()
        {
            string query =
                "UPDATE CourseAssign SET Flag=0";
            SqlCommand = new SqlCommand(query, SqlConnection);
            SqlConnection.Open();
          
            int rowEffect = SqlCommand.ExecuteNonQuery();
            SqlConnection.Close();
            return rowEffect;
        } 
    }
}