using Microsoft.AspNetCore.Mvc;
using TheBuzzerBeater.DataAccess.Repository.IRepository;

namespace TheBuzzerBeater.Web.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult JerseysAndApparel()
        {
            var category = _unitOfWork.Category.GetCategoryByName("Jerseys & Apparel", includeProducts: true, includeSubcategories: true);

            if (category == null)
            {
                return NotFound(); 
            }

            return View(category); 
        }

        public IActionResult Footwear()
        {
            var category = _unitOfWork.Category.GetCategoryByName("Footwear", includeProducts: true, includeSubcategories: true);

            if (category == null)
            {
                return NotFound(); 
            }

            return View(category); 
        }

        public IActionResult BasketballEquipment()
        {
            var category = _unitOfWork.Category.GetCategoryByName("Basketball Equipment", includeProducts: true, includeSubcategories: true);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }
        public IActionResult Accessories()
        {
            var category = _unitOfWork.Category.GetCategoryByName("Accessories", includeProducts: true, includeSubcategories: true);

            if (category == null)
            {
                return NotFound(); 
            }

            return View(category); 
        }

        public IActionResult SalesAndClearance()
        {
            var category = _unitOfWork.Category.GetCategoryByName("Sales/Clearance", includeProducts: true, includeSubcategories: true);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpGet]
        public IActionResult CategoryDetails(string categoryName)
        {
            var category = _unitOfWork.Category.GetCategoryByName(categoryName, includeProducts: true, includeSubcategories: true);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

    }
}
