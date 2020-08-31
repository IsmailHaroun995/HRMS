using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRMS.Repo
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //public DbSet<WebApplication1.Models.Employee> Employee { get; set; }
        public DbSet<HRMS.Core.Entities.EmployeeEntity> Employees { get; set; }
        public DbSet<HRMS.Core.Entities.DepartmentEntities> Departments { get; set; }
    
    }
}
