using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkForce_management.Models.ViewModels
{
    public class TrainingProgramDetailViewModel
    {
        public TrainingProgram TrainingProgram { get; set; }
        public List<Employee> Employee { get; set; } = new List<Employee>();
    }
}
