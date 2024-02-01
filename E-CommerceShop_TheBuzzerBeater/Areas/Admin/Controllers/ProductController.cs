
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TheBuzzerBeater.DataAccess.Data;
using TheBuzzerBeater.DataAccess.Repository;
using TheBuzzerBeater.DataAccess.Repository.IRepository;
using TheBuzzerBeater.Models;
using TheBuzzerBeater.Models.ViewModels;
using TheBuzzerBeater.Utilities;

namespace TheBuzzerBeater.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = StaticDetails.Role_Admin)]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Product> objProductList = _unitOfWork.Product.GetAll(includeProperties:"Category").ToList();
            
                return View(objProductList);
        }

        public IActionResult Upsert(int? productId)
        {
            ProductVM productVM = new()
            {
                CategoryList = _unitOfWork.Category
                .GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.CategoryId.ToString()
                }),
                Product = new Product()
            };
            
            if (productId == null || productId == 0) //create
            {
                return View(productVM);
            }
            else //update
            {
                productVM.Product = _unitOfWork.Product.Get(u=>u.ProductId == productId);
                return View(productVM);
            }
        }

        [HttpPost]
        public IActionResult Upsert(ProductVM productVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"images\products");

                    if (!string.IsNullOrEmpty(productVM.Product.ImageUrl))
                    {
                        //delete the old image
                        var oldImagePath = Path.Combine(wwwRootPath, productVM.Product.ImageUrl.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    productVM.Product.ImageUrl = @"\images\products\" + fileName;
                }
                
                if (productVM.Product.ProductId == 0) 
                {
                    _unitOfWork.Product.Add(productVM.Product); //create
                }
                else
                {
                    _unitOfWork.Product.Update(productVM.Product); //update
                }

                
                _unitOfWork.Save();
                TempData["success"] = "Product created succesfully";
                return RedirectToAction("Index");
            }
            else
            {
                productVM.CategoryList = _unitOfWork.Category
                .GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.CategoryId.ToString()
                });
                return View(productVM);
            }
        }




        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _unitOfWork.Product.GetAll(includeProperties: "Category")
                .Select(p => new
                {
                    p.ProductId,
                    p.Name,
                    p.Description,
                    p.Price,
                    CategoryName = p.Category.Name // Access the Category property to get the Name
                })
                .ToList();

            return Json(new { data = products });
        }



        //List<Product> objProductList = _unitOfWork.Product.GetAll(includeProperties: "Category").ToList();

        //return Json(new { data = objProductList });


        [HttpDelete]
        public IActionResult Delete(int? productId)
        {
            
            var productToBeDeleted = _unitOfWork.Product.Get(u => u.ProductId == productId);
            if(productToBeDeleted == null) 
            {
                return Json(new { success = false,message = "Error while deleting"});
            }

            var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath,
                                productToBeDeleted.ImageUrl.TrimStart('\\'));

            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }

            _unitOfWork.Product.Remove(productToBeDeleted); 
            _unitOfWork.Save();

            return Json(new { success = true, message = "Deleted Succesfully" });
        }

        #endregion
    }
}


    