using E_CommerceShop_TheBuzzerBeater.Data;
using E_CommerceShop_TheBuzzerBeater.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceShop_TheBuzzerBeater.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList= _db.Categories.ToList();
            return View(objCategoryList);
        }
    }
}
