using GTRTraining.Models;
using GTRTraining.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GTRTraining.Controllers
{
    public class DesignationController : Controller
    {
        private readonly IDesignationRepository _designationRepository;
        public DesignationController(IDesignationRepository designationRepository)
        {
            _designationRepository = designationRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Designation designation)
        {
            var storedCompanyId = Request.Cookies["SelectedCompanyId"].ToString();
            int ComId = Convert.ToInt32(storedCompanyId);
            designation.ComId = ComId;
            _designationRepository.Insert(designation);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _designationRepository.Delete(id);
            return RedirectToAction("Index");
        }
        public IActionResult Detail(int id)
        {
            var designation = _designationRepository.GetById(id);
            return View(designation);
        }
        public IActionResult Edit(int id)
        {
            var designation = _designationRepository.GetById(id);
            return View(designation);
        }
        [HttpPost]
        public IActionResult Edit(Designation designation)
        {
            var storedCompanyId = Request.Cookies["SelectedCompanyId"].ToString();
            int ComId = Convert.ToInt32(storedCompanyId);
            designation.ComId = ComId;
            _designationRepository.Update(designation);
            return RedirectToAction("Index");
        }
        public IActionResult ShowDesignation()
        {
            var storedCompanyId = Request.Cookies["SelectedCompanyId"].ToString();
            int C_id = Convert.ToInt32(storedCompanyId);
            var designations = _designationRepository.GetAllItem().Where(x => x.ComId == C_id).ToList();
            return Json(designations);
        }
    }
}
