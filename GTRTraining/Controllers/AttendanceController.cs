using GTRTraining.DtoModel;
using GTRTraining.Models;
using GTRTraining.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace GTRTraining.Controllers
{
    public class AttendanceController : Controller
    {
        private readonly IEmployeeAttendenceRepository _AttendenceRepository;
        private readonly IEmployeeRepository _employeeRepository;
        public AttendanceController(IEmployeeAttendenceRepository employeeAttendenceRepository, IEmployeeRepository employeeRepository)
        {
            _AttendenceRepository = employeeAttendenceRepository;
            _employeeRepository = employeeRepository;
        }
  
        public IActionResult Entry(int EmpId)
        {
            ViewBag.EmpId = EmpId;
            return View();
        }

        [HttpPost]
        public IActionResult Entry(EmployeeAttendance attendance)
        {
            var storedCompanyId = Request.Cookies["SelectedCompanyId"].ToString();
            int C_id = Convert.ToInt32(storedCompanyId);

            attendance.ComId = C_id;
            
            var employee = _employeeRepository.Get(attendance.EmpId);
            
            if(attendance.InTime > employee.ShiftLateTime)
            {
                attendance.AttStatus = "Late";
            }
            else
            {
                attendance.AttStatus = "Present";
            }
            if(attendance.InTime == null)
            {
                attendance.AttStatus = "Absent";
            }
            if(attendance.dtDate.DayOfWeek.ToString() == "Friday")
            {
                attendance.AttStatus = "Weekday";
                attendance.InTime = null;
                attendance.OutTime = null;
            }
            _AttendenceRepository.Insert(attendance);
            return RedirectToAction("Index","Employee");
        }
        public IActionResult Delete(int Id)
        {
            _AttendenceRepository.Delete(Id);
            return RedirectToAction("Entry");
        }

        public IActionResult ShowReport(int EmpId)
        {
            var Allattendance = _AttendenceRepository.GetAllItem().ToList().Where(x => x.EmpId == EmpId).ToList();
            return View(Allattendance);
        }
        public IActionResult Edit(int Id)
        {
            var entry = _AttendenceRepository.GetById(Id);
            return View(entry);
        }
        [HttpPost]
        public IActionResult Edit(EmployeeAttendance attendance)
        {
            _AttendenceRepository.Update(attendance);
            return RedirectToAction("Entry");
        }

        public IActionResult GenerateReport(int empId)
        {
            var storedCompanyId = Request.Cookies["SelectedCompanyId"].ToString();
            int companyId = Convert.ToInt32(storedCompanyId);

            List<AttendanceDetails> attendanceDetails = new List<AttendanceDetails>();
            
            string connectionString = "Server=ASAD-POCKET\\SQLEXPRESS;Database=GTRTrainingFinal; Integrated Security = true; TrustServerCertificate=True;MultipleActiveResultSets=true";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("GetEmployeeAttendanceDetails", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ComId", companyId);
                    cmd.Parameters.AddWithValue("@EmpId", empId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AttendanceDetails details = new AttendanceDetails
                            {
                                MonthNumber = Convert.ToInt32(reader["MonthNumber"]),
                                MonthName = reader["MonthName"].ToString(),
                                PresentDays = Convert.ToInt32(reader["PresentDays"]),
                                AbsentDays = Convert.ToInt32(reader["AbsentDays"]),
                                LateDays = Convert.ToInt32(reader["LateDays"])
                            };

                            attendanceDetails.Add(details);
                        }
                    }
                }
            }

            return View(attendanceDetails);
        }
    }
}
