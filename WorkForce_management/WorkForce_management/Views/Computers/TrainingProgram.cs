using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WorkForce_management.Models
{
    public class TrainingProgram
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string TraingingProgramName { get; set; }
        public DateTime StrateDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<TrainingProgramEmployee>TrainingProgramEmployee { get; set; }
    }
}
