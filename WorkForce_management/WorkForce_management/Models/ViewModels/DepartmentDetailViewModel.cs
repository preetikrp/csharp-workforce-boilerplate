using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkForce_management.Models.ViewModels
{
    public class DepartmentDetailViewModel
    {
       public Department Department { get; set; }
       public List<Employee> Employees { get; set; } = new List<Employee>();
    }
}
