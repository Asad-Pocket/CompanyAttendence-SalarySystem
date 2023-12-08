using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTRTraining.Models
{
    public class Department
    {
        [Key]
        public int DeptId { get; set; }
        public string DeptName { get; set; }
        public int ComId { get; set; }                          // Foreign Key
        [ForeignKey(nameof(ComId))]
        public Company? Company { get; set; }                    // Navigation property
        public ICollection<Employee>? Employees { get; set; }    // Navigation property
    }
}
