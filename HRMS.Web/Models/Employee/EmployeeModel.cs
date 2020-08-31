using System;

namespace HRMS.Web.Models.Employee
{
    public class EmployeeModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public DateTime OntimeCreted { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }
        public string Mobile { get; set; }
        public string UserName { get; set; }

        virtual public string Password { get; set; }

        public string ConfirmPassword { get; set; }
        public Boolean IsDeleted { get; set; }

        virtual public string DirectManager { get; set; }
        virtual public string DMFirstName { get; set; }
        virtual public string DMLastName { get; set; }
    }
}
