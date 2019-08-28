using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Xml.Schema;
using UniversityRegistrationSystemApp.Model;

namespace UniversityRegistrationSystemApp.Gateway
{
    public class StudentGateway : BaseGateway
    {
        private DepartmentGateway DepartmentGateway;
        public StudentGateway()
        {
            DepartmentGateway = new DepartmentGateway();
        }
        public int Save(Student student)
        {
            string d = student.Date;
            string year = d.Substring(0, 4);
            //int total = FindTotal(student.DepartmentId);
            int total = FindTotalByYear(student.DepartmentId,year);
            int dpId = student.DepartmentId;
            string code = DepartmentGateway.GetDepartmentCodeById(student.DepartmentId);

            //student.Date = "2018-12-17";
            //string d = student.Date;
            //string year = d.Substring(0, 4);
            
            //total = student.Total;
            total = total + 1;
            string s = total.ToString();
            if (s.Length == 1)
            {
                s = "00" + s;
            }
            else if (s.Length == 2)
            {
                s = "0" + s;
            }
            
            //string ss = dpId.ToString();
            s = code + "-" + year + "-" + s;

            string query = "INSERT INTO Student(RegistrationId, Name,Email,ContactNo,Address,Date,DepartmentId) VALUES(@ss, @name,@email,@contactno,@address,@date,@departmentid)";
            SqlCommand command = new SqlCommand(query, SqlConnection);
            command.Parameters.AddWithValue("@ss", s);
            command.Parameters.AddWithValue("@name", student.Name);
            command.Parameters.AddWithValue("@email", student.Email);
            command.Parameters.AddWithValue("@contactno", student.ContactNo);
            command.Parameters.AddWithValue("@address", student.Address);
            command.Parameters.AddWithValue("@date", student.Date);
            command.Parameters.AddWithValue("@departmentid", student.DepartmentId);

            SqlConnection.Open();
            int rowAffect = command.ExecuteNonQuery();
            SqlConnection.Close();
            return rowAffect;
        }

        public int FindTotalByYear(int dpId,string year)
        {
            string sDate = year + "-01" + "-01";
            string lDate = year + "-12" + "-31";
            string query = "SELECT DepartmentId, COUNT(*) AS Total FROM Student WHERE Date BETWEEN @sdate AND @ldate GROUP BY DepartmentId ";
            SqlCommand = new SqlCommand(query, SqlConnection);
            SqlCommand.Parameters.AddWithValue("@sdate", sDate);
            SqlCommand.Parameters.AddWithValue("@ldate", lDate);
            SqlConnection.Open();
            SqlDataReader = SqlCommand.ExecuteReader();
            int total = 0;

            while (SqlDataReader.Read())
            {

                int id = Convert.ToInt32(SqlDataReader["DepartmentId"]);
                if (id == dpId)
                {
                    total = Convert.ToInt32(SqlDataReader["Total"]);
                }

            }
            SqlDataReader.Close();
            SqlConnection.Close();
            return total;
        }

        public int FindTotal(int dpId)
        {
            string query = "SELECT * FROM StudentTotal";
            SqlCommand = new SqlCommand(query, SqlConnection);
            SqlConnection.Open();
            SqlDataReader = SqlCommand.ExecuteReader();
            int total=0;

            while (SqlDataReader.Read())
            {
                
                int id= Convert.ToInt32(SqlDataReader["DepartmentId"]);
                if (id == dpId)
                {
                    total = Convert.ToInt32(SqlDataReader["Total"]);
                }

            }
            SqlDataReader.Close();
            SqlConnection.Close();
            return total;
        }

        public bool IsExistsEmail(string email)
        {

            string query = "SELECT * FROM Student WHERE Email=@email";
            SqlCommand = new SqlCommand(query, SqlConnection);
            SqlCommand.Parameters.AddWithValue("@email", email);
            SqlConnection.Open();
            SqlDataReader = SqlCommand.ExecuteReader();
            bool isExists = SqlDataReader.HasRows;
            SqlConnection.Close();
            return isExists;
        }

        public List<Student> GetAllStudentRegNo()
        {

            string query = "SELECT * FROM Student";
            SqlCommand = new SqlCommand(query, SqlConnection);
            SqlConnection.Open();
            SqlDataReader = SqlCommand.ExecuteReader();
            List<Student> RegNoList = new List<Student>();

            while (SqlDataReader.Read())
            {
                Student input = new Student();
                input.Id = Convert.ToInt32(SqlDataReader["Id"]);
                input.RegistrationId = SqlDataReader["RegistrationId"].ToString();
                RegNoList.Add(input);
            }
            SqlDataReader.Close();
            SqlConnection.Close();
            return RegNoList;
        }

        public Student GetAllStudentInfoByStudentId(int studentId)
        {
            string query = "SELECT Name,Email,DepartmentId FROM Student WHERE Student.Id=@StudentId";
            SqlCommand = new SqlCommand(query, SqlConnection);
            SqlCommand.Parameters.AddWithValue("@StudentId", studentId);
            SqlConnection.Open();
            SqlDataReader = SqlCommand.ExecuteReader();
            SqlDataReader.Read();
            Student aStudentInfo = new Student();
            if (SqlDataReader.HasRows)
            {


                aStudentInfo.Name = SqlDataReader["Name"].ToString();
                aStudentInfo.Email = SqlDataReader["Email"].ToString();
                aStudentInfo.DepartmentId = Convert.ToInt32(SqlDataReader["DepartmentId"]);

            }
            SqlDataReader.Close();
            SqlConnection.Close();
            return aStudentInfo;
        }
    }
}