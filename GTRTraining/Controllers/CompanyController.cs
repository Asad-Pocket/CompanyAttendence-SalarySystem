using GTRTraining.Data;
using GTRTraining.DtoModel;
using GTRTraining.Models;
using GTRTraining.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.SqlClient;

namespace GTRTraining.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly ApplicationDbContext _context;
        private readonly IEmployeeRepository _employeeRepository;
        public CompanyController(ICompanyRepository companyRepository,IEmployeeRepository employeeRepository, ApplicationDbContext dbContext)
        {
            _companyRepository = companyRepository;
            _context = dbContext;
            _employeeRepository = employeeRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Company company)
        {
            _companyRepository.Insert(company);
            return RedirectToAction("Index");   
        }
        public IActionResult Delete(int id)
        {
            _companyRepository.Delete(id);
            return RedirectToAction("Index");
        }
        public IActionResult Detail(int id)
        {
            var company = _companyRepository.GetById(id);
            return View(company);
        }
        public IActionResult Edit(int id)
        {
            var company = _companyRepository.GetById(id);
            return View(company);
        }
        [HttpPost]
        public IActionResult Edit(Company company)
        {
            if (ModelState.IsValid)
            {
                _companyRepository.Update(company);
                return RedirectToAction("Index");
            }

            return View(company);
        }
        public JsonResult ShowCompanies() 
        {
            var companies = _companyRepository.GetAllItem().ToList();
            return Json(companies);
        }
        public IActionResult GetAttendenceReport()
        {
            var storedCompanyId = Request.Cookies["SelectedCompanyId"].ToString();
            int Comid = Convert.ToInt32(storedCompanyId);

            var employees = _employeeRepository.GetAllInItem(Comid);

            string connectionString = "Server=ASAD-POCKET\\SQLEXPRESS;Database=GTRTrainingFinal; Integrated Security = true; TrustServerCertificate=True;MultipleActiveResultSets=true";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand("GetAttendanceReport", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CompanyId", Comid);

                    using (var reader = command.ExecuteReader())
                    {
                        var result = new DataTable();
                        result.Load(reader);
                        result.Columns.Add("EmployeeCode", typeof(int));
                        result.Columns.Add("EmployeeName", typeof(string));
                        result.Columns.Add("Designation", typeof(string));
                        result.Columns.Add("Department", typeof(string));
                        foreach (DataRow row in result.Rows)
                        {
                            int empId = Convert.ToInt32(row["EmpId"]);
                            int employeeCode =(int) employees.FirstOrDefault(e => e.EmpId == empId)?.EmpCode;
                            row["EmployeeCode"] = employeeCode;
                            string employeeName = employees.FirstOrDefault(e => e.EmpId == empId)?.EmpName;
                            row["EmployeeName"] = employeeName;
                            string DesigName = employees.FirstOrDefault(e => e.EmpId == empId)?.DesigName;
                            row["Designation"] = DesigName;
                            string DeptName = employees.FirstOrDefault(e => e.EmpId == empId)?.DeptName;
                            row["Department"] = DeptName;
                        }
                        return View(result);
                    }
                }
            }
        }


    }
}
