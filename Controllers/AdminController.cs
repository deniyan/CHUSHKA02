using CHUSHKA02.Data.Models;
using CHUSHKA02.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CHUSHKA02.Controllers
{
    public class AdminController : Controller
    {
        private readonly RoleManager<AppUser> roleManager;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleModel model)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(model);
            //}
            //RoleManager<IdentityRole> role = 
            //    new RoleManager<IdentityRole> { Name = model.RoleName, };
            //var result = await roleManager.CreateAsync(role);//Add DataBase
            //if (result.Succeeded)
            //{
            //    return Redirect("/");
            //}
            //else
            //{
            //    foreach (var error in result.Errors)
            //    {
            //        ModelState.AddModelError("", error.ToString());
            //    }
            //}
            return View();
        }
    }
}
