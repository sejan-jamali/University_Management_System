using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityRegistrationSystemApp.Model;

namespace UniversityRegistrationSystemApp.Gateway
{
    public class DayGateway:BaseGateway
    {
        public List<Day> GetAllDays()
        {

            string query = "SELECT * FROM Day";
            SqlCommand = new SqlCommand(query, SqlConnection);
            SqlConnection.Open();
            SqlDataReader = SqlCommand.ExecuteReader();
            List<Day> DayList = new List<Day>();

            while (SqlDataReader.Read())
            {
                Day input = new Day();
                input.Id = Convert.ToInt32(SqlDataReader["Id"]);
                input.Name = SqlDataReader["Name"].ToString();
                DayList.Add(input);
            }
            SqlDataReader.Close();
            SqlConnection.Close();
            return DayList;
        }
    }
}