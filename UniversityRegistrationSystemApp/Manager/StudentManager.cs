using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityRegistrationSystemApp.Gateway;
using UniversityRegistrationSystemApp.Model;

namespace UniversityRegistrationSystemApp.Manager
{
    public class StudentManager
    {
        private StudentGateway studentGateway;

        public StudentManager()
        {
            studentGateway = new StudentGateway();
        }

        public string Save(Student student)
        {
            if (studentGateway.IsExistsEmail(student.Email))
            {
                return "The email is already exists";
            }

            else
            {
                if (studentGateway.Save(student) > 0)
                {
                    return "Save Successful";
                }
                else
                {
                    return "Save Failed";
                }
            }
        }

        public List<Student> GetAllStudentRegNo()
        {
            return studentGateway.GetAllStudentRegNo();
        }

        public Student GetAllStudentInfoByStudentId(int studentId)
        {
            return studentGateway.GetAllStudentInfoByStudentId(studentId);
        }
    }
}