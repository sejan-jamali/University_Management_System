using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityRegistrationSystemApp.Model;

namespace UniversityRegistrationSystemApp.Gateway
{
    public class DepartmentGateway : BaseGateway
    {
        public int Save(Department department)
        {
            
            string query = "INSERT INTO Department(Name,Code) VALUES(@name,@code)";
            SqlCommand = new SqlCommand(query, SqlConnection);
            SqlCommand.Parameters.AddWithValue("@name", department.Name);
            SqlCommand.Parameters.AddWithValue("@code", department.Code);
            SqlConnection.Open();
            int rowAffect = SqlCommand.ExecuteNonQuery();
            SqlConnection.Close();

            return rowAffect;
        }

        public bool IsExistsName(string departmentName)
        {
           
            string query = "SELECT * FROM Department WHERE Name=@departmentName";
            SqlCommand = new SqlCommand(query, SqlConnection);
            SqlCommand.Parameters.AddWithValue("@departmentName", departmentName);
            SqlConnection.Open();
            SqlDataReader = SqlCommand.ExecuteReader();
            bool isExists = SqlDataReader.HasRows;
            SqlConnection.Close();
            return isExists;
        }

        public bool IsEmpty(string departmentName)
        {
            bool isEmpty = string.IsNullOrEmpty(departmentName);
            return isEmpty;
        }

        public bool IsExistsCode(string departmentCode)
        {
           
            string query = "SELECT * FROM Department WHERE Code=@departmentCode";
            SqlCommand = new SqlCommand(query, SqlConnection);
            SqlCommand.Parameters.AddWithValue("@departmentCode", departmentCode);
            SqlConnection.Open();
            SqlDataReader = SqlCommand.ExecuteReader();
            bool isExists = SqlDataReader.HasRows;
            SqlConnection.Close();
            return isExists;
        }
        public List<Department> GetAllDepartments()
        {
            
            string query = "SELECT * FROM Department";
            SqlCommand = new SqlCommand(query, SqlConnection);
            SqlConnection.Open();
            SqlDataReader = SqlCommand.ExecuteReader();
            List<Department> departmentList = new List<Department>();

            while (SqlDataReader.Read())
            {
                Department input = new Department();
                input.Id = Convert.ToInt32(SqlDataReader["Id"]);
                input.Name = SqlDataReader["Name"].ToString();
                input.Code = SqlDataReader["Code"].ToString();
                departmentList.Add(input);
            }
            SqlDataReader.Close();
            SqlConnection.Close();
            return departmentList;
        }
        public string GetDepartmentCodeById(int id)
        {

            string query = "SELECT * FROM Department WHERE Id=@id";
            SqlCommand = new SqlCommand(query, SqlConnection);
            SqlCommand.Parameters.AddWithValue("@id", id);
            SqlConnection.Open();
            SqlDataReader = SqlCommand.ExecuteReader();
            string code = "";
            while (SqlDataReader.Read())
            {
                code = SqlDataReader["Code"].ToString();
                
            }
            SqlDataReader.Close();
            SqlConnection.Close();
            return code;
        }
    }
}