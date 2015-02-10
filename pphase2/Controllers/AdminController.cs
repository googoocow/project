using PhaseTwo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhaseTwo.Controllers
{
    public class AdminController : Controller
    {
        

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult List()
        {
            return PartialView(DatabaseHelper.GetAll<Admin>().OrderBy(a => a.id));
        }

        // GET: Admin/Details/5
        public ActionResult Details(string id)
        {

            return View(new PhaseTwoDBEntities().Admins.Where(a=> a.username == id).FirstOrDefault());
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
				AdminRepo.AddAdmin(new Admin(collection["username"], collection["password"], collection["email"]));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(string id)
        {
            PhaseTwoDBEntities ctx = new PhaseTwoDBEntities();

            return View(ctx.Admins.Where(a => a.username == id).FirstOrDefault());
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            PhaseTwoDBEntities ctx = new PhaseTwoDBEntities();
            try
            {
                var admin = ctx.Admins.Where(a => a.username == id).FirstOrDefault();

                admin.username = collection["username"];
                admin.password = collection["password"];

                ctx.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(string id)
        {
            PhaseTwoDBEntities ctx = new PhaseTwoDBEntities();

            ctx.Admins.Remove(ctx.Admins.Where(a => a.username == id).FirstOrDefault());
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult CrudUI()
        {
            return View();
        }
    }
}
