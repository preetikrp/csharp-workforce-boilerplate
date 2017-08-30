using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkForce_management.Models.ViewModels
{
    public class EmployeeEditViewModel
    {
        public Employee employee { get; set; }
        public List<int> TrainingProgramEmployee { get; set; } = new List<int>();

       
        public List<int> Computer { get; set; } = new List<int>();

    }

}
