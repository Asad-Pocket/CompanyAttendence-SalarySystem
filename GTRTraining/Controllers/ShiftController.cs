using GTRTraining.Models;
using GTRTraining.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GTRTraining.Controllers
{
    public class ShiftController : Controller
    {
        private readonly IShiftRepository _shiftRepository;
        public ShiftController(IShiftRepository shiftRepository)
        {
            _shiftRepository = shiftRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Index(Shift shift)
        {
            var storedCompanyId = Request.Cookies["SelectedCompanyId"].ToString();
            int ComId = Convert.ToInt32(storedCompanyId);
            shift.ComId = ComId;
            _shiftRepository.Insert(shift);
            return RedirectToAction();
        }
        public IActionResult Delete(int id)
        {
            _shiftRepository.Delete(id);
            return RedirectToAction("Index");
        }
        public IActionResult Detail(int id)
        {
            var shift = _shiftRepository.GetById(id);
            return View(shift);
        }
        public IActionResult Edit(int id)
        {
            var shift = _shiftRepository.GetById(id);

            return View(shift);
        }
        [HttpPost]
        public IActionResult Edit(Shift shift)
        {
            var storedCompanyId = Request.Cookies["SelectedCompanyId"].ToString();
            int ComId = Convert.ToInt32(storedCompanyId);
            shift.ComId = ComId;
            _shiftRepository.Update(shift);
            return RedirectToAction("Index");
        }
        public JsonResult ShowShift()
        {
            var storedCompanyId = Request.Cookies["SelectedCompanyId"].ToString();
            int C_id = Convert.ToInt32(storedCompanyId);
            var shift = _shiftRepository.GetAllItem().Where(x => x.ComId == C_id).ToList();
            return Json(shift);
        }
    }
}
