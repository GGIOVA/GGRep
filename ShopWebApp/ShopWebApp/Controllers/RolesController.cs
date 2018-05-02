using Microsoft.AspNet.Identity.EntityFramework;
using ShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ShopWebApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        private ApplicationDbContext applicationDbContext;

        public RolesController()
        {
            applicationDbContext = new ApplicationDbContext();
        }

        // GET: Roles
        public ActionResult Index()
        {
            var Roles = applicationDbContext.Roles.ToList();
            return View(Roles);
        }

        
        public ActionResult Create()
        {
            var Role = new IdentityRole();
            return View(Role);
        }

        [HttpPost]
        public ActionResult Create(IdentityRole Role)
        {
            applicationDbContext.Roles.Add(Role);
            applicationDbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                applicationDbContext.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}