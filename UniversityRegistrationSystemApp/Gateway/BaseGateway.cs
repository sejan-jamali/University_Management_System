using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace UniversityRegistrationSystemApp.Gateway
{
    public class BaseGateway
    {
        public SqlConnection SqlConnection { get; set; }
        public SqlCommand SqlCommand { get; set; }
        public SqlDataReader SqlDataReader { get; set; }

        public BaseGateway()
        {
            string connection = WebConfigurationManager.ConnectionStrings["UniversityManagementConDB"].ConnectionString;
            SqlConnection = new SqlConnection(connection);
        }
    }
}