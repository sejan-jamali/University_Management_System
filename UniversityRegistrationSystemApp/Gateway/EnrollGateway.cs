using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityRegistrationSystemApp.Model;

namespace UniversityRegistrationSystemApp.Gateway
{
    public class EnrollGateway : BaseGateway
    {
        public int EnrollCourse(StudentEnroll enroll)
        {
            string query =
                "INSERT INTO StudentEnroll(StudentId,CourseId,Date) VALUES(@StudentId , @CourseId, @Date)";
            SqlCommand = new SqlCommand(query, SqlConnection);
            SqlCommand.Parameters.AddWithValue("@StudentId", enroll.StudentId);
            SqlCommand.Parameters.AddWithValue("@CourseId", enroll.CourseId);
            SqlCommand.Parameters.AddWithValue("@Date", enroll.Date);
            // Command.Parameters.AddWithValue("@GradeId", enroll.GradeId);
            //SqlCommand.Parameters.AddWithValue("@Action", enroll.Action);

            SqlConnection.Open();
            int rowAffected = SqlCommand.ExecuteNonQuery();
            SqlConnection.Close();
            return rowAffected;
        }

        public bool IsEnrollExixts(StudentEnroll enroll)
        {
            string query = "SELECT * FROM StudentEnroll WHERE StudentId = @StudentId AND CourseId = @CourseId";
            SqlCommand = new SqlCommand(query, SqlConnection);
            SqlCommand.Parameters.AddWithValue("@StudentId", enroll.StudentId);
            SqlCommand.Parameters.AddWithValue("@CourseId", enroll.CourseId);
            if (SqlConnection.State != ConnectionState.Open)
                SqlConnection.Open();
            SqlDataReader = SqlCommand.ExecuteReader();
            if (SqlDataReader.HasRows)
            {
                SqlDataReader.Close();
                SqlConnection.Close();
                return true;
            }
            SqlDataReader.Close();
            SqlConnection.Close();
            return false;
        }


    }
}