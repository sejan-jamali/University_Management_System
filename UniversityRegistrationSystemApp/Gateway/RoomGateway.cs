using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityRegistrationSystemApp.Model;

namespace UniversityRegistrationSystemApp.Gateway
{
    public class RoomGateway:BaseGateway
    {
        public List<Room> GetAllRooms()
        {

            string query = "SELECT * FROM Room";
            SqlCommand = new SqlCommand(query, SqlConnection);
            SqlConnection.Open();
            SqlDataReader = SqlCommand.ExecuteReader();
            List<Room> roomList = new List<Room>();

            while (SqlDataReader.Read())
            {
                Room input = new Room();
                input.Id = Convert.ToInt32(SqlDataReader["Id"]);
                input.Name = SqlDataReader["Name"].ToString();
                roomList.Add(input);
            }
            SqlDataReader.Close();
            SqlConnection.Close();
            return roomList;
        }
    }
}