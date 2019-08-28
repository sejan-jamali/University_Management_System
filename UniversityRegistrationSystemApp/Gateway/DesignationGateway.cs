using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityRegistrationSystemApp.Model;

namespace UniversityRegistrationSystemApp.Gateway
{
    public class DesignationGateway : BaseGateway
    {
        public List<Designation> GetAllDesignations()
        {

            string query = "SELECT * FROM Designation";
            SqlCommand = new SqlCommand(query, SqlConnection);
            SqlConnection.Open();
            SqlDataReader = SqlCommand.ExecuteReader();
            List<Designation> designationList = new List<Designation>();

            while (SqlDataReader.Read())
            {
                Designation input = new Designation();
                input.Id = Convert.ToInt32(SqlDataReader["Id"]);
                input.Name = SqlDataReader["Name"].ToString();
                designationList.Add(input);
            }
            SqlDataReader.Close();
            SqlConnection.Close();
            return designationList;
        }
    }
}