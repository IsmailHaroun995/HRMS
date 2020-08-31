using System;
using System.Collections.Generic;

namespace HRMS.Web.Models.Employee
{
    public class EmployeeListModel
    {
        public EmployeeListModel()
        {
            EmployeeList = new List<EmployeeModel>();
        }
        public List<EmployeeModel> EmployeeList { get; set; }
        public DateTime NowDate { get; set; }
        public int NumberOfPages { get; set; }
        public int NumberOfRows { get; set; }
    }
}
