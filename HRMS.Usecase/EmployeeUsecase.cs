using HRMS.Core.Contracts;
using HRMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Usecase
{
    public class EmployeeUsecase :IEmployeeUsecase
    {
        private readonly IEmployeeRepo _employee;
        public EmployeeUsecase(IEmployeeRepo employee)
        {
            this._employee = employee;
        }

        public async Task<List<EmployeeEntity>> GetAllEmployeeUC()
        {
            List<EmployeeEntity> emps = await _employee.GetAllEmployee();
            return emps;
        }

        public EmployeeEntity GetEmployeeByIdAsync(int id)
        {
            var e = _employee.GetEmployeeById(id);
            return e;
        }

        public void Insert(EmployeeEntity employee)
        {
           _employee.Insert(employee);

        }
        public void UpdateEmployee(EmployeeEntity employee)
        {
            _employee.UpdateEmployee(employee);

        }
        public void DeleteEmployee(int Id)
        {
            _employee.DeleteEmployee(Id);

        }

    }
}
