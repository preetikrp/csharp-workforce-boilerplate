using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WorkForce_management.Models
{
    public class Employee
    { 
        [Key]
        public int Id { get; set; }
        [Required]

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public ICollection<EmployeeComputer>EmployeeComputers { get; set; }
        public ICollection<TrainingProgramEmployee> TrainingProgramEmployee { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }

        public DateTime StartDate { get; set; }
    }
}
