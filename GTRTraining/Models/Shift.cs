using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTRTraining.Models
{
    public class Shift
    {
        [Key]
        public int ShiftId { get; set; }
        [Required]
        public string ShiftName { get; set; }
        public TimeSpan ShiftIn { get; set; }
        public TimeSpan ShiftOut { get; set; }
        public TimeSpan ShiftLateTime { get; set; }
        public int ComId { get; set; }                          // Foreign Key
        [ForeignKey(nameof(ComId))]
        public Company? Company { get; set; }                    // Navigation property
        public ICollection<Employee>? Employees { get; set; }    // Navigation property
    }
}
