using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityRegistrationSystemApp.Model;

namespace UniversityRegistrationSystemApp.Gateway
{
    public class ClassRoomGateway
    {
        public int Save(ClassRoom classRoom)
        {
            string connection = WebConfigurationManager.ConnectionStrings["UniversityManagementConDB"].ConnectionString;
            SqlConnection SqlConnection1 = new SqlConnection(connection);
            SqlCommand SqlCommand1;


            string query = "INSERT INTO ClassRoom(DepartmentId, CourseId, RoomId, DayId, TimeFrom, TimeTo, Flag) VALUES(@departmentid, @courseid, @roomid, @dayid, @timefrom, @timeto, @flag)";
            SqlCommand1 = new SqlCommand(query, SqlConnection1);
            SqlCommand1.Parameters.AddWithValue("@departmentid", classRoom.DepartmentId);
            SqlCommand1.Parameters.AddWithValue("@courseid", classRoom.CourseId);
            SqlCommand1.Parameters.AddWithValue("@roomid", classRoom.RoomId);
            SqlCommand1.Parameters.AddWithValue("@dayid", classRoom.DayId);
            SqlCommand1.Parameters.AddWithValue("@timefrom", classRoom.TimeFrom);
            SqlCommand1.Parameters.AddWithValue("@timeto", classRoom.TimeTo);
            SqlCommand1.Parameters.AddWithValue("@flag", 1);
            SqlConnection1.Open();
            int rowEffect = SqlCommand1.ExecuteNonQuery();
            SqlConnection1.Close();
            return rowEffect;
        }
        public bool CheckSlot(ClassRoom classRoom)
        {
            string connection = WebConfigurationManager.ConnectionStrings["UniversityManagementConDB"].ConnectionString;
            SqlConnection SqlConnection1 = new SqlConnection(connection);
            SqlCommand SqlCommand1;
            SqlDataReader SqlDataReader1;

            string query = "SELECT * FROM ClassRoom WHERE (TimeFrom BETWEEN @start AND @to) AND DayId=@dayid AND RoomId=@rid";
            SqlCommand1 = new SqlCommand(query, SqlConnection1);
            SqlCommand1.Parameters.AddWithValue("@start", classRoom.TimeFrom);
            SqlCommand1.Parameters.AddWithValue("@to", classRoom.TimeTo);
            SqlCommand1.Parameters.AddWithValue("@dayid", classRoom.DayId);
            SqlCommand1.Parameters.AddWithValue("@rid", classRoom.RoomId);
            SqlConnection1.Open();
            SqlDataReader1 = SqlCommand1.ExecuteReader();
            bool isExist = SqlDataReader1.HasRows;
            SqlConnection1.Close();
            return isExist;

        }
        public bool CheckSlot2(ClassRoom classRoom)
        {
            string connection = WebConfigurationManager.ConnectionStrings["UniversityManagementConDB"].ConnectionString;
            SqlConnection SqlConnection1 = new SqlConnection(connection);
            SqlCommand SqlCommand1;
            SqlDataReader SqlDataReader1;

            string query = "SELECT * FROM ClassRoom WHERE (TimeTo BETWEEN @start AND @to) AND DayId=@dayid AND RoomId=@rid";
            SqlCommand1 = new SqlCommand(query, SqlConnection1);
            SqlCommand1.Parameters.AddWithValue("@start", classRoom.TimeFrom);
            SqlCommand1.Parameters.AddWithValue("@to", classRoom.TimeTo);
            SqlCommand1.Parameters.AddWithValue("@dayid", classRoom.DayId);
            SqlCommand1.Parameters.AddWithValue("@rid", classRoom.RoomId);
            SqlConnection1.Open();
            SqlDataReader1 = SqlCommand1.ExecuteReader();
            bool isExist = SqlDataReader1.HasRows;
            SqlConnection1.Close();
            return isExist;

        }

        public int UnassignClassRoom()
        {
            string connection = WebConfigurationManager.ConnectionStrings["UniversityManagementConDB"].ConnectionString;
            SqlConnection SqlConnection1 = new SqlConnection(connection);
            SqlCommand SqlCommand1;
            
            string query =
                "UPDATE ClassRoom SET Flag=0";
            SqlCommand1 = new SqlCommand(query, SqlConnection1);
            SqlConnection1.Open();
            int rowEffect = SqlCommand1.ExecuteNonQuery();
            SqlConnection1.Close();
            return rowEffect;
        }

        public List<Schedule> GetScheduleInfoByDeptmentId(int CLid)
        {
            string connection = WebConfigurationManager.ConnectionStrings["UniversityManagementConDB"].ConnectionString;
            SqlConnection SqlConnection1 = new SqlConnection(connection);
            SqlCommand SqlCommand1;
            SqlDataReader SqlDataReader1;


            string query =
                "SELECT * FROM Course WHERE DepartmentId=@did";

            SqlCommand1 = new SqlCommand(query, SqlConnection1);
            SqlCommand1.Parameters.AddWithValue("@did", CLid);
            SqlConnection1.Open();
            SqlDataReader1 = SqlCommand1.ExecuteReader();

            List<Schedule> scheduleList=new List<Schedule>();
            while (SqlDataReader1.Read())
            {
                Schedule schedule = new Schedule();
                Course courseViewModel=new Course();
                courseViewModel.Code = SqlDataReader1["Code"].ToString();
                courseViewModel.Name = SqlDataReader1["Name"].ToString();
                courseViewModel.Id =Convert.ToInt32(SqlDataReader1["Id"]);

                int id = courseViewModel.Id;
                //string code = courseViewModel.Code;
                string s = FindInfo(id, CLid);

                schedule.CoureCode = courseViewModel.Code;
                schedule.Name = courseViewModel.Name;
                schedule.ScheduleInfo = s;
                if (s !="")
                {
                    scheduleList.Add(schedule);
                }
            }
            SqlDataReader1.Close();
            SqlConnection1.Close();
            return scheduleList;

        }

        private string FindInfo(int id, int cLid)
        {

            string connection = WebConfigurationManager.ConnectionStrings["UniversityManagementConDB"].ConnectionString;
            SqlConnection SqlConnection1 = new SqlConnection(connection);
            SqlCommand SqlCommand1;
            SqlDataReader SqlDataReader1;

            //"SELECT * FROM ClassRoom WHERE CourseId=@code AND DepartmentId=@did
            string query =
                "SELECT * FROM ClassRoom WHERE CourseId=@code AND DepartmentId=@did AND Flag=1";

            SqlCommand1 = new SqlCommand(query, SqlConnection1);
            SqlCommand1.Parameters.AddWithValue("@did", cLid);
            SqlCommand1.Parameters.AddWithValue("@code", id);
            SqlConnection1.Open();
            SqlDataReader1 = SqlCommand1.ExecuteReader();

            List<Schedule> scheduleList = new List<Schedule>();

            string info = "";

            while (SqlDataReader1.Read())
            {
                ClassRoom cr=new ClassRoom();
                cr.RoomId=Convert.ToInt32(SqlDataReader1["RoomId"]);
                cr.DayId = Convert.ToInt32(SqlDataReader1["DayId"]);
                cr.TimeFrom=SqlDataReader1["TimeFrom"].ToString();
                cr.TimeTo=SqlDataReader1["TimeTo"].ToString();
                
                string rn = FindRoomName(cr.RoomId);
                string day = FindDayName(cr.DayId);

                info += "R. No: " + rn + ", " + day + ", " + cr.TimeFrom + " - " + cr.TimeTo+"@";


            }
            info = info.Replace("@", Environment.NewLine);
            SqlDataReader1.Close();
            SqlConnection1.Close();
            return info;
        }

        private string FindDayName(int dayId)
        {

            string connection = WebConfigurationManager.ConnectionStrings["UniversityManagementConDB"].ConnectionString;
            SqlConnection SqlConnection1 = new SqlConnection(connection);
            SqlCommand SqlCommand1;
            SqlDataReader SqlDataReader1;


            string query = "SELECT * FROM Day WHERE Id=@id";
            SqlCommand1 = new SqlCommand(query, SqlConnection1);
            SqlCommand1.Parameters.AddWithValue("@id", dayId);

            SqlConnection1.Open();
            SqlDataReader1 = SqlCommand1.ExecuteReader();

            SqlDataReader1.Read();
            string name = SqlDataReader1["Name"].ToString();
            SqlDataReader1.Close();
            SqlConnection1.Close();
            return name;
        }

        private string FindRoomName(int roomId)
        {

            string connection = WebConfigurationManager.ConnectionStrings["UniversityManagementConDB"].ConnectionString;
            SqlConnection SqlConnection1 = new SqlConnection(connection);
            SqlCommand SqlCommand1;
            SqlDataReader SqlDataReader1;


            string query = "SELECT * FROM Room WHERE Id=@id";
            SqlCommand1 = new SqlCommand(query, SqlConnection1);
            SqlCommand1.Parameters.AddWithValue("@id", roomId);

            SqlConnection1.Open();
            SqlDataReader1 = SqlCommand1.ExecuteReader();

            SqlDataReader1.Read();
            string name = SqlDataReader1["Name"].ToString();
            SqlDataReader1.Close();
            SqlConnection1.Close();
            return name;
        }

        
    }
}