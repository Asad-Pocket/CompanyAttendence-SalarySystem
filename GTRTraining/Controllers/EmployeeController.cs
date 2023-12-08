using GTRTraining.Models;
using GTRTraining.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GTRTraining.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IDesignationRepository _designationRepository;
        private readonly IShiftRepository _shiftRepository;
        private readonly ICompanyRepository _companyRepository;
        public EmployeeController(IEmployeeRepository employeeRepository, IDepartmentRepository departmentRepository,
            IDesignationRepository designationRepository, ICompanyRepository companyRepository,
            IShiftRepository shiftRepository)
        {
            _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;
            _designationRepository = designationRepository;
            _shiftRepository = shiftRepository;
            _companyRepository = companyRepository;
        }
        public IActionResult Index()
        {
            var storedCompanyId = Request.Cookies["SelectedCompanyId"].ToString();
            int C_id = Convert.ToInt32(storedCompanyId);
            var designations = _designationRepository.GetAllItem().Where(x => x.ComId == C_id).ToList();
            var departments = _departmentRepository.GetAllItem().Where(x => x.ComId == C_id).ToList();
            var shifts = _shiftRepository.GetAllItem().Where(x => x.ComId == C_id).ToList();
            ViewData["depts"] = departments;
            ViewData["desigs"] = designations;
            ViewData["shift"] = shifts;
            return View();
        }
        [HttpPost]
        public IActionResult Index(Employee employee)
        {
            var storedCompanyId = Request.Cookies["SelectedCompanyId"].ToString();
            int C_id = Convert.ToInt32(storedCompanyId);
            employee.ComId = C_id;
            var company = _companyRepository.GetById(C_id);

            // Calculate Basic based on Gross and division
            double division = ((double)company.Basic) / 100.00;
            employee.Basic = (int?)(employee.Gross * division);

            division = ((double)company.HRent) / 100.00;
            // Calculate HRent based on Gross and company.HRent
            employee.HRent = (int?)(employee.Gross * division);

            division = ((double)company.Medical) / 100.00;
            // Calculate Medical based on Gross and company.Medical
            employee.Medical = (int?)(employee.Gross * division);

            // Insert the employee into the repository
            _employeeRepository.Insert(employee);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _employeeRepository.Delete(id);
            return RedirectToAction("Index");
        }
        public IActionResult Detail(int id)
        {
            var employee = _employeeRepository.GetById(id);
            return View(employee);
        }
        public IActionResult Edit(int id)
        {
            var storedCompanyId = Request.Cookies["SelectedCompanyId"].ToString();
            int C_id = Convert.ToInt32(storedCompanyId);
            var designations = _designationRepository.GetAllItem().Where(x => x.ComId == C_id).ToList();
            var departments = _departmentRepository.GetAllItem().Where(x => x.ComId == C_id).ToList();
            var shifts = _shiftRepository.GetAllItem().Where(x => x.ComId == C_id).ToList();
            ViewData["depts"] = departments;
            ViewData["desigs"] = designations;
            ViewData["shift"] = shifts;
            var employee = _employeeRepository.GetById(id);
            return View(employee);
        }
        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            var storedCompanyId = Request.Cookies["SelectedCompanyId"].ToString();
            int ComId = Convert.ToInt32(storedCompanyId);
            employee.ComId = ComId;
            _employeeRepository.Update(employee);
            return RedirectToAction("Index");
        }
        public IActionResult ShowEmployee()
        {
            var storedCompanyId = Request.Cookies["SelectedCompanyId"].ToString();
            int C_id = Convert.ToInt32(storedCompanyId);
            var empList = _employeeRepository.GetAllInItem(C_id);
            return Json(empList);
        }
        public IActionResult ShowEmployeeByDepartment()
        {
            var storedCompanyId = Request.Cookies["SelectedCompanyId"].ToString();
            int C_id = Convert.ToInt32(storedCompanyId);
            var empList = _employeeRepository.GetAllInItem(C_id);
            var departments = _departmentRepository.GetAllItem().Where(x => x.ComId == C_id).ToList();
            ViewData["depts"] = departments;
            return View();
        }
        [HttpPost]
        public IActionResult EmployeeByDepartment(int DeptId)
        {
            var storedCompanyId = Request.Cookies["SelectedCompanyId"].ToString();
            int C_id = Convert.ToInt32(storedCompanyId);
            var employeeList = _employeeRepository.GetAllByDept(C_id,DeptId).ToList();
            return Json(employeeList);
        }

    }
}
