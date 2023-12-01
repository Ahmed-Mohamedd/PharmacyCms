using Microsoft.AspNetCore.Mvc;

using Pharmacy.BLL.Interfaces;

namespace Pharmacy.PL.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IUnitOfwork _unitOfwork;

        public DashboardController(IUnitOfwork unitOfwork)
        {
            _unitOfwork = unitOfwork;
        }
        public IActionResult Index()
        {
            return View();
        }


        #region Api CAll for MedicineData

        public  IActionResult GetMedicines()
        {
            var MedicineList =  _unitOfwork.Medicines.GetAll();
            return Json(new { data = MedicineList });
        }
        #endregion
    }
}
