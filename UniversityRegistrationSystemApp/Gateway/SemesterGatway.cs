using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityRegistrationSystemApp.Model;

namespace UniversityRegistrationSystemApp.Gateway
{
    public class SemesterGatway : BaseGateway
    {
        public List<Semester> GetAllSemester()
        {

            string query = "SELECT * FROM Semester";
            SqlCommand = new SqlCommand(query, SqlConnection);
            SqlConnection.Open();
            SqlDataReader = SqlCommand.ExecuteReader();
            List<Semester> semesterList = new List<Semester>();

            while (SqlDataReader.Read())
            {
                Semester input = new Semester();
                input.Id = Convert.ToInt32(SqlDataReader["Id"]);
                input.Name = SqlDataReader["Name"].ToString();
                //input.Code = SqlDataReader["Code"].ToString();
                semesterList.Add(input);
            }
            SqlDataReader.Close();
            SqlConnection.Close();
            return semesterList;
        }
    }
}