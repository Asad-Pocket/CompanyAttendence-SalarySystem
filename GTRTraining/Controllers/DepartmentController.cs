using GTRTraining.Models;
using GTRTraining.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GTRTraining.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _DepartmentRepository;
        public DepartmentController(IDepartmentRepository repository)
        {
            _DepartmentRepository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Department department)
        {
            var storedCompanyId = Request.Cookies["SelectedCompanyId"].ToString();
            int ComId = Convert.ToInt32(storedCompanyId);
            department.ComId = ComId;
            _DepartmentRepository.Insert(department);
            return RedirectToAction();
        }
        public IActionResult Delete(int id)
        {
            _DepartmentRepository.Delete(id);
            return RedirectToAction("Index");
        }
        public IActionResult Detail(int id)
        {
            var department = _DepartmentRepository.GetById(id);
            return View(department);
        }
        public IActionResult Edit(int id)
        {
            var department = _DepartmentRepository.GetById(id);

            return View(department);
        }
        [HttpPost]
        public IActionResult Edit(Department depertment)
        {
            var storedCompanyId = Request.Cookies["SelectedCompanyId"].ToString();
            int ComId = Convert.ToInt32(storedCompanyId);
            depertment.ComId = ComId;
            _DepartmentRepository.Update(depertment);
            return RedirectToAction("Index");
        }
        public JsonResult ShowDepartment()
        {
            var storedCompanyId = Request.Cookies["SelectedCompanyId"].ToString();
            int C_id = Convert.ToInt32(storedCompanyId);
            var departments = _DepartmentRepository.GetAllItem().Where(x => x.ComId == C_id).ToList();
            return Json(departments);
        }

    }
}
