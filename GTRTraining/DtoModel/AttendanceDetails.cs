namespace GTRTraining.DtoModel
{
    public class AttendanceDetails
    {
        public int MonthNumber { get; set; }
        public string MonthName { get; set; }
        public int PresentDays { get; set; }
        public int AbsentDays { get; set; }
        public int LateDays { get; set; }
    }
}
