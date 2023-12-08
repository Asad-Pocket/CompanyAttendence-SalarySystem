namespace GTRTraining.DtoModel
{
    public class EmployeeAttendanceDetails
    {
        public int EmpId { get; set; }
        public string? EmpName { get; set; }
        public int PresentDays { get; set; }
        public int AbsentDays { get; set; }
        public int LateDays { get; set; }
    }
}
