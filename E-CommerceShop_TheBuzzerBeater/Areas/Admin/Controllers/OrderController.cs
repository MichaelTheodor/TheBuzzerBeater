using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using TheBuzzerBeater.DataAccess.Repository.IRepository;
using TheBuzzerBeater.Models;

namespace TheBuzzerBeater.Web.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            List<OrderHeader> objOrderHeaders = _unitOfWork.OrderHeader.GetAll(includeProperties: "ApplicationUser").ToList();

            return Json(new { data = objOrderHeaders });
        }

    

        #endregion
    }
}
