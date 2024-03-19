using CHUSHKA02.Data;
using CHUSHKA02.Data.Models;
using CHUSHKA02.Models;
using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;

namespace CHUSHKA02.Controllers
{
    public class ProductController : Controller
    {
        
        private readonly ApplicationDbContext db;
        private readonly UserManager<AppUser> userManager;
        public ProductController(ApplicationDbContext db, UserManager<AppUser> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(string id)
        {
            var product = db.Products.Where(x => x.Id == id).Select(x => new InputProductModel
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                Description = x.Description,
                ProductType = x.Type

            }).FirstOrDefault();


            return View(product);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AllOrders(string id)
        {
            if (ModelState.IsValid)
            {
                var currentUser = await userManager.GetUserAsync(User);
                var currentUserId = currentUser.Id;

                var product = db.Products.FirstOrDefault(x => x.Id == id);

                if (product != null)
                {
                    var order = new Order
                    {
                        ProductId = id,
                        ClientId = currentUserId,
                        OrderedOn = DateTime.Now
                    };

                    db.Orders.Add(order);
                    await db.SaveChangesAsync();

                    return Redirect("/");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Product not found.");
                }
            }

            return Redirect("/");
        }


        public IActionResult AllOrders()
        {
            var orders = db.Orders
                .Include(o => o.Product)
                .Include(o => o.Client)
                .Select(order => new InputOrderModel
                {
                    Id = order.Id,
                    ProductId = order.Product.Name,
                    AppUserId = order.Client.UserNamee,
                    OrderedOn = order.OrderedOn
                })
                .ToList();

            return View(orders);
        }


        [HttpPost]
        public IActionResult Create(InputProductModel input)
        {
            var prdouct = new Product
            {
                Name = input.Name,
                Price = input.Price,
                Description = input.Description,
                Type = input.ProductType,
            };
            db.Products.Add(prdouct);
            db.SaveChanges();
            return Redirect("/");
        }

        public ActionResult Edit(string id)
        {
            var product = db.Products.Where(x => x.Id == id).Select(x => new InputProductModel
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                Description = x.Description,
                ProductType = x.Type

            }).FirstOrDefault();

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(InputProductModel model, IFormCollection collection)
        {
            Product product = db.Products.First(x => x.Id == model.Id);
            product.Name = model.Name;
            product.Price = model.Price;
            product.Description = model.Description;
            product.Type = model.ProductType;
            db.SaveChanges();
            return RedirectToAction("Details", new { id = model.Id });
        }

        public ActionResult Delete(string id)
        {
            var product = db.Products.Where(s => s.Id == id).Select(x => new InputProductModel
            {
                Id= x.Id,
                Name = x.Name,
                Price = x.Price,
                Description = x.Description,
                ProductType = x.Type
            }).FirstOrDefault();
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
        {
            var product = db.Products.Where(s => s.Id == id).FirstOrDefault();
            db.Products.Remove(product);
            db.SaveChanges();
            return Redirect("/");
        }
    }
}
