using HRMS.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRMS.Core.Contracts
{
    public interface IEmployeeUsecase
    {
         Task<List<EmployeeEntity>> GetAllEmployeeUC();
        void Insert(EmployeeEntity employee);
        EmployeeEntity GetEmployeeByIdAsync(int id);

        void UpdateEmployee(EmployeeEntity employee);

        void DeleteEmployee(int Id);

    }
}
