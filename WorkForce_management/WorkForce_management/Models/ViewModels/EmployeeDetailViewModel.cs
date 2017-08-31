using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkForce_management.Models.ViewModels
{
    public class EmployeeDetailViewModel
    {

        
            public Employee Employee { get; set; }
            public int  Computer { get; set; }
            public int TrainingProgramEmployee { get; set; }
            public List<Computer> Computers { get; set; } = new List<Computer>();
            public List<TrainingProgram> TrainingPrograms { get; set; } = new List<TrainingProgram>();
            
        }
    }


