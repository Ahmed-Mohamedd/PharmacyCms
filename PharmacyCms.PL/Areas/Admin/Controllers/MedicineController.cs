using Microsoft.AspNetCore.Mvc;
using Pharmacy.BLL.Interfaces;

namespace Pharmacy.PL.Areas.Admin.Controllers
{
    public class MedicineController : Controller
    {
        private readonly IUnitOfwork _unitOfwork;

        public MedicineController(IUnitOfwork unitOfwork)
        {
           _unitOfwork=unitOfwork;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
