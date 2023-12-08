using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTRTraining.Models
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public int EmpCode { get; set; }
        public string Gender { get; set; }
        public int Gross { get; set; }
        public int? Basic { get; set; }
        public int? HRent { get; set; }
        public int? Medical { get; set; }
        public int? Others { get; set; } = 5;
        public DateTime? DtJoin { get; set; } = DateTime.Now;

        // Foreign Keys
        public int ComId { get; set; }
        public int ShiftId { get; set; }
        public int DeptId { get; set; }
        public int DesigId { get; set; }

        // Navigation properties
        [ForeignKey(nameof(ComId))]
        public Company? Company { get; set; }
        [ForeignKey(nameof(ShiftId))]
        public Shift? Shift { get; set; }
        [ForeignKey(nameof(DeptId))]
        public Department? Department { get; set; }
        [ForeignKey(nameof(DesigId))]
        public Designation? Designation { get; set; }
    }
}
