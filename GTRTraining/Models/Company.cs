using System.ComponentModel.DataAnnotations;

namespace GTRTraining.Models
{
    public class Company
    {
        [Key]
        [Required]
        public int ComId { get; set; }
        [Required]
        public string ComName { get; set; }
        [Required]
        public int Basic { get; set; } = 50;
        [Required]
        public int HRent { get; set; } = 25;
        [Required]
        public int Medical { get; set; } = 10;
        [Required]
        public bool IsInactive { get; set; } = false;

        // Navigation property (for relationships)
        public ICollection<Department>? Departments { get; set; }
        public ICollection<Employee>? Employees { get; set; }
        public ICollection<Designation>? Designations { get; set; }
        public ICollection<Shift>? Shifts { get; set; }
    }
}
