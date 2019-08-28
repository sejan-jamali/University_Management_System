using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityRegistrationSystemApp.Model;

namespace UniversityRegistrationSystemApp.Gateway
{
    public class ResultGateway : BaseGateway
    {
        public List<Student> GetAllStudentRegNo()
        {
            string query = "SELECT StudentId,RegistrationNo FROM Student";
            SqlCommand = new SqlCommand(query, SqlConnection);
            SqlConnection.Open();
            List<Student> studentList = new List<Student>();
            SqlDataReader = SqlCommand.ExecuteReader();
            while (SqlDataReader.Read())
            {
                Student aStudent = new Student();
                aStudent.Id = Convert.ToInt32(SqlDataReader["Id"]);
                aStudent.RegistrationId = SqlDataReader["RegistrationId"].ToString();
                studentList.Add(aStudent);
            }
            SqlDataReader.Close();
            SqlConnection.Close();
            return studentList;
        }

        public List<Grade> GetAllGradeList()
        {
            string query = "SELECT * FROM Grade";
            SqlCommand = new SqlCommand(query, SqlConnection);
            SqlConnection.Open();
            List<Grade> allGradeList = new List<Grade>();
            SqlDataReader = SqlCommand.ExecuteReader();
            while (SqlDataReader.Read())
            {
                Grade aGrade = new Grade();
                aGrade.Id = Convert.ToInt32(SqlDataReader["Id"]);
                aGrade.Name = SqlDataReader["Name"].ToString();
                allGradeList.Add(aGrade);
            }
            SqlDataReader.Close();
            SqlConnection.Close();
            return allGradeList;
        }

        

        public int SaveStudentResult(ResultSave resultSave)
        {
            string query = "INSERT INTO ResultSave(StudentID, CourseId, GradeId) VALUES(@studentid, @courseid, @gradeid)";
            SqlCommand = new SqlCommand(query, SqlConnection);
            SqlCommand.Parameters.AddWithValue("@studentid", resultSave.StudentId);
            SqlCommand.Parameters.AddWithValue("@courseid", resultSave.CourseId);
            SqlCommand.Parameters.AddWithValue("@gradeid", resultSave.GradeId);
            //SqlCommand.Parameters.AddWithValue("@action", "insert");

            SqlConnection.Open();
            int rowAffected = SqlCommand.ExecuteNonQuery();
            SqlConnection.Close();
            return rowAffected;
        }

        public List<ResultViewModel> GetStudentResultById(int studentId)
        {
            string query =
                "SELECT Course.Code AS CourseCode,Course.Name AS CourseName,Grade.Name AS Grade FROM Course INNER JOIN ResultSave ON Course.Id = ResultSave.CourseId LEFT JOIN Grade ON Grade.Id = ResultSave.GradeId WHERE  ResultSave.StudentId = @studentId";
            SqlCommand = new SqlCommand(query, SqlConnection);
            SqlCommand.Parameters.AddWithValue("@studentId", studentId);
            SqlConnection.Open();
            SqlDataReader = SqlCommand.ExecuteReader();

            List<ResultViewModel> results = new List<ResultViewModel>();
            while (SqlDataReader.Read())
            {
                ResultViewModel result = new ResultViewModel();
                result.CourseCode = SqlDataReader["CourseCode"].ToString();
                result.CourseName = SqlDataReader["CourseName"].ToString();
                string grade = SqlDataReader["Grade"].ToString();

                if (string.IsNullOrEmpty(grade))
                {
                    result.Grade = "Not Graded Yet!";
                }

                else
                {
                    result.Grade = SqlDataReader["Grade"].ToString();
                }
                results.Add(result);
            }
            return results;
        }
    }
}