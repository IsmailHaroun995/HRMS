using HRMS.Core.Contracts;
using HRMS.Core.Entities;
using HRMS.Repo;
using HRMS.Usecase;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRMS.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeUsecase _EmployeeUseCase;
        private readonly ApplicationDbContext _context;
        public EmployeeController(IEmployeeUsecase employeeUsecase)
        {
            this._EmployeeUseCase = employeeUsecase;
        }
        public async Task<IActionResult> Index()
        {
            List < EmployeeEntity> empList = new List<EmployeeEntity>();
            var emps = await _EmployeeUseCase.GetAllEmployeeUC();
            if (emps.Count > 0)
            {
                foreach (var emp in emps)
                {
                    if (emp.IsDeleted == false)
                    {
                        EmployeeEntity em = new EmployeeEntity
                        {
                            Id = emp.Id,
                            FirstName = emp.FirstName,
                            LastName = emp.LastName,
                            Gender = emp.Gender,
                            OntimeCreted = emp.OntimeCreted,
                            Address = emp.Address,
                            Email = emp.Email,
                            Mobile = emp.Mobile,
                            UserName = emp.UserName,
                            //Password = emp.Password,
                            //ConfirmPassword = emp.ConfirmPassword,
                            DMFirstName = emp.DMFirstName,
                            DMLastName = emp.LastName
                        };

                        empList.Add(em);
                    }

                }

            }
            return View(empList);
        }
        public IActionResult Create()
        {

            return View(/*model*/);
        }

        // POST: Emps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeEntity Employees)
        {
            if (ModelState.IsValid)
            {
                _EmployeeUseCase.Insert(Employees);
                return RedirectToAction("Index", "Employee");
            }
            return View();

        }
        public IActionResult Edit(int id)
        {
            var e = _EmployeeUseCase.GetEmployeeByIdAsync(id);
            return View(e);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EmployeeEntity emps)
        {
            try
            {
                _EmployeeUseCase.UpdateEmployee( emps);
                return RedirectToAction("Index", "Employee");

            }
            catch
            {
                return Content("error");

            }
        }
        public IActionResult Details(int id)
        {
            var e = _EmployeeUseCase.GetEmployeeByIdAsync(id);
            return View(e);

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeeEntity employee = _EmployeeUseCase.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _EmployeeUseCase.DeleteEmployee(id);
            return RedirectToAction("Index");
        }

    }
}
