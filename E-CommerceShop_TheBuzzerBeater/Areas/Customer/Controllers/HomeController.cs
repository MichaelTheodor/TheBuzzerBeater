using TheBuzzerBeater.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TheBuzzerBeater.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using TheBuzzerBeater.Utilities;

namespace TheBuzzerBeater.Web.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {

            var categories = _unitOfWork.Category.GetCategories().Take(4).ToList(); // Assuming GetCategories() returns a list of categories
            return View(categories);
        }
        public IActionResult Search(string searchString)
        {
            IEnumerable<Product> searchResults;

            if (!string.IsNullOrEmpty(searchString))
            {
                searchResults = _unitOfWork.Product.GetAll(
                    filter: p => p.Name.Contains(searchString),
                    includeProperties: "Category"
                );
            }
            else
            {
                searchResults = Enumerable.Empty<Product>();
            }

            return View(searchResults);
        }


        public IActionResult ProductDetails(int productId)
        {
            ShoppingCart cart = new()
            {
                Product = _unitOfWork.Product.Get(u => u.ProductId == productId, includeProperties: "Category"),
                Count = 1,
                ProductId = productId
            };
            return View(cart);
        }
        [HttpPost]
        [Authorize]
        public IActionResult ProductDetails(ShoppingCart shoppingCart)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            shoppingCart.ApplicationUserId = userId;


            ShoppingCart cartFromDb =_unitOfWork.ShoppingCart.Get(u=> u.ApplicationUserId == userId &&
            u.ProductId==shoppingCart.ProductId);

            if (cartFromDb !=null)
            {
                //cart exists
                cartFromDb.Count+= shoppingCart.Count;
                _unitOfWork.ShoppingCart.Update(cartFromDb);
                _unitOfWork.Save();
            }
            else
            {
                //add cart record
                _unitOfWork.ShoppingCart.Add(shoppingCart);
                _unitOfWork.Save();
                HttpContext.Session.SetInt32(StaticDetails.SessionCart, 
                _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == userId).Count()); 
                
            }
            TempData["success"] = "Cart updated succesfully";

            return RedirectToAction(nameof(Index));
        }

        public IActionResult ContactUs()
        {
            return View();
        }
        public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult BlogNews()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult ReturnsAndExchanges()
        {
            return View();
        }
        public IActionResult ShippingInformation()
        {
            return View();
        }
        public IActionResult SizeGuide()
        {
            return View();
        }
        
        public IActionResult TermsOfService()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
