using HRMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Core.Contracts
{
    public interface IEmployeeRepo
    {
         Task<List<EmployeeEntity>> GetAllEmployee();
        void Insert(EmployeeEntity employee);
         EmployeeEntity GetEmployeeById(int id);
        void UpdateEmployee(EmployeeEntity employee);

        void DeleteEmployee(int id);

    }
}
