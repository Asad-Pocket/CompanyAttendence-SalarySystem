using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTRTraining.Models
{
    public class Designation
    {
        [Key]
        public int DesigId { get; set; }
        public string DesigName { get; set; }
        public int ComId { get; set; }                          // Foreign Key
        [ForeignKey(nameof(ComId))]
        public Company? Company { get; set; }                    // Navigation property
        public ICollection<Employee>? Employees { get; set; }    // Navigation property
    }
}
