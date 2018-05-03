using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class RoleController : Controller
    {

        ApplicationDbContext context;

        private ApplicationRoleManager _roleManager;

        public RoleController()
        {
            context = new ApplicationDbContext();
        }

        public RoleController(ApplicationRoleManager roleManager)
        {
            RoleManager = roleManager;

        }

       
        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }
        // GET: Role
        [Authorize(Roles ="Admin")]
        public ActionResult Index()
        {
            /* List<RoleViewModel> list = new List<RoleViewModel>();
             foreach (var role in RoleManager.Roles)
                 list.Add(new RoleViewModel(role));
             return View(list);*/
            var Roles = context.Roles.ToList();
            return View(Roles);
        }

        public ActionResult Create()
        {
            // return View();
            var Role = new IdentityRole();
            return View(Role);
        }

        /* [HttpPost]
         [Authorize(Roles ="Admin")]
         public async Task<ActionResult> Create(RoleViewModel model)
         {
             var role = new ApplicationRole() { Name = model.Name };
             await RoleManager.CreateAsync(role);
             return RedirectToAction("Index");
         }
         public async Task<ActionResult> Edit(string id)
         {
             var role = await RoleManager.FindByIdAsync(id);
             return View(new RoleViewModel(role));
         }

         [HttpPost]
         [Authorize(Roles = "Admin")]

         public async Task<ActionResult> Edit(RoleViewModel model)
         {
             var role = new ApplicationRole() { Id = model.Id, Name = model.Name };
             await RoleManager.UpdateAsync(role);
             return RedirectToAction("Index");
         }

         public async Task<ActionResult> Details(string id)
         {
             var role = await RoleManager.FindByIdAsync(id);
             return View(new RoleViewModel(role));
         }

         [Authorize(Roles = "Admin")]

         public async Task<ActionResult> Delete(string id)
         {
             var role = await RoleManager.FindByIdAsync(id);
             return View(new RoleViewModel(role));
         }


         }
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]

        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            var role = await RoleManager.FindByIdAsync(id);
            await RoleManager.DeleteAsync(role);
            return RedirectToAction("Index");
        }*/
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(IdentityRole Role)
        {
            context.Roles.Add(Role);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}