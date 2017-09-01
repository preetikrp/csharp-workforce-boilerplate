using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WorkForce_management.Models;

namespace WorkForce_management.Models
{
    public class WorkForce_managementContext : DbContext
    {
        public WorkForce_managementContext (DbContextOptions<WorkForce_managementContext> options)
            : base(options)
        {
        }

        public DbSet<WorkForce_management.Models.Employee> Employee { get; set; }

        public DbSet<WorkForce_management.Models.Department> Department { get; set; }

        public DbSet<WorkForce_management.Models.Computer> Computer { get; set; }

        public DbSet<WorkForce_management.Models.TrainingProgram> TrainingProgram { get; set; }

        public DbSet<WorkForce_management.Models.TrainingProgramEmployee> TrainingProgramEmployee { get; set; }

        public DbSet<WorkForce_management.Models.EmployeeComputer> EmployeeComputer { get; set; }

    }
}
