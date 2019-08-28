using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityRegistrationSystemApp.Gateway;
using UniversityRegistrationSystemApp.Model;

namespace UniversityRegistrationSystemApp.Manager
{
    public class ResultManager
    {
        private ResultGateway resultsGateway;

        public ResultManager()
        {
            resultsGateway = new ResultGateway();
        }

        public string SaveStudentResult(ResultSave resultSave)
        {
            int row = resultsGateway.SaveStudentResult(resultSave);
            if (row > 0)
            {
                return "Save Successfully";
            }
            else
            {
                return "Something went wrong";
            }
        }

        public List<Grade> GetAllGradeList()
        {
            return resultsGateway.GetAllGradeList();
        }

        public List<ResultViewModel> GetStudentResultById(int studentId)
        {
            return resultsGateway.GetStudentResultById(studentId);
        }
    }
}