using GTRTraining.DtoModel;
using GTRTraining.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Reflection.Emit;

namespace GTRTraining.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<EmployeeAttendance> Attendence { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeAttendance>()
            .HasKey(a => new { a.ComId, a.EmpId, a.dtDate });

            

            base.OnModelCreating(modelBuilder);
        }
    }
}
