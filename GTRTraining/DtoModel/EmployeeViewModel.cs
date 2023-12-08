using System.ComponentModel.DataAnnotations;

namespace GTRTraining.DtoModel
{
    public class EmployeeViewModel
    {
        [Key]
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public int ComId { get; set; }
        public int DeptId { get; set; }
        public int EmpCode { get; set; }
        public string DeptName { get; set; }
        public string DesigName { get; set; }
        public string ShiftName { get; set; }
        public TimeSpan? ShiftLateTime { get; set; }
        public string Gender { get; set; }
        public int Gross { get; set; }
        public int? Basic { get; set; }
        public int? HRent { get; set; }
        public int? Medical { get; set; }
        public int? Others { get; set; } = 0;
        public DateTime? DtJoin { get; set; }

    }
}
