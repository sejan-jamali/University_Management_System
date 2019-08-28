using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityRegistrationSystemApp.Gateway;
using UniversityRegistrationSystemApp.Model;

namespace UniversityRegistrationSystemApp.Manager
{
    public class EnrollManager
    {
        private EnrollGateway enrollGateway;

        public EnrollManager()
        {
            enrollGateway = new EnrollGateway();
        }
        public string EnrollCourse(StudentEnroll enroll)
        {
            if (!enrollGateway.IsEnrollExixts(enroll))
            {
                int rowAffect = enrollGateway.EnrollCourse(enroll);
                if (rowAffect > 0)
                {
                    return "Save Successful";
                }
                else
                {
                    return "Save Failed";
                }
            }
            else
            {
                return "A student can enroll in a course once only!!!";
            }
        }
    }
}