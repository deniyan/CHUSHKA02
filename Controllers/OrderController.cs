using CHUSHKA02.Data;
using CHUSHKA02.Data.Models;
using CHUSHKA02.Models;
using Microsoft.AspNetCore.Mvc;

namespace CHUSHKA02.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext db;
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add(InputOrderModel model)
        {
            var order = new Order
            {
                ClientId = model.AppUserId,

            };

            var product = db.Products.FirstOrDefault(x => model.ProductId == x.Id);



            db.Orders.Add(order);
            db.SaveChanges();

            return RedirectToAction("All");
        }
    }
}
