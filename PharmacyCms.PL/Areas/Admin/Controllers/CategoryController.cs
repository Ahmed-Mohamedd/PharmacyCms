using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.BLL.Interfaces;
using Pharmacy.BLL.Repositories;
using Pharmacy.DAL.Entities;
using Pharmacy.PL.Models;

namespace Pharmacy.PL.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfwork _unitOfwork;
        private readonly IMapper _mapper;

        public CategoryController(IUnitOfwork unitOfwork , IMapper mapper)
        {
            _unitOfwork=unitOfwork;
            _mapper=mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Create(CategoryViewModel category)
        {
            if(ModelState.IsValid)
            {
                var MappedCategory = _mapper.Map<CategoryViewModel , Category>(category);
                _unitOfwork.Categories.Add(MappedCategory);
                TempData["Success"] = "Category Added Succcessfully";
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var category = _unitOfwork.Categories.GetById(id);
            if (category == null)
                return NotFound();

            var CategoryToUpdate = _mapper.Map<Category, CategoryViewModel>(category);

            return View(CategoryToUpdate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id , CategoryViewModel categoryViewModel)
        {
            if (categoryViewModel.Id !=id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                var UpdatedCategory = _mapper.Map<CategoryViewModel, Category>(categoryViewModel);
                _unitOfwork.Categories.Update(UpdatedCategory);
                TempData["Success"] = "Category Updated Successfully";
                return RedirectToAction(nameof(Index));
            }

            return View(categoryViewModel);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            var category = _unitOfwork.Categories.GetById(id);
            if (category == null)
                return NotFound();

            var CategoryToDelete = _mapper.Map<Category, CategoryViewModel>(category);

            return View(CategoryToDelete);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete( int? id, CategoryViewModel categoryViewModel)
        {
            if (id!= categoryViewModel.Id)
                return BadRequest();
            var CategoryToDelete = _mapper.Map<CategoryViewModel ,Category>(categoryViewModel);

            _unitOfwork.Categories.Delete(CategoryToDelete);
            TempData["Success"]="Category Deleted Successfully";
            return RedirectToAction(nameof(Index));
        }




        #region Api CAll for CategoryData

        public IActionResult GetCategories()
        {
            var CategoriesList =  _unitOfwork.Categories.GetAll();
            return Json(new { data = CategoriesList });
        }
        #endregion
    }
}
