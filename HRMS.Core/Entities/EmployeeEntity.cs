using System;
using System.ComponentModel.DataAnnotations;

namespace HRMS.Core.Entities
{
    public class EmployeeEntity
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }

        [Required]
        public string Gender { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime OntimeCreted { get; set; }

        public string Address { get; set; }

        [Required]
        [MaxLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        public string Mobile { get; set; }
        [Required]
        [MaxLength(20)]
        [RegularExpression(@"^\S*$", ErrorMessage = "No white space allowed")]
        public string UserName { get; set; }
        [Required]
        [MaxLength(20)]
        [MinLength(7)]
        [DataType(DataType.Password)]
        virtual public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        virtual public string ConfirmPassword { get; set; }
        public bool IsDeleted { get; set; }
        virtual public DepartmentEntities Department { get; set; }

        virtual public string DirectManager { get; set; }
        virtual public string DMFirstName { get; set; }
        virtual public string DMLastName { get; set; }

    }
}
