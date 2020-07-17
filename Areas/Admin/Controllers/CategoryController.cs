using MyBlogApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Management;
using System.Web.Mvc;

namespace MyBlogApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly MyBlogContext db = new MyBlogContext();
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }
        public ActionResult CategoryDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }



        [HttpGet]
        public ActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCategory(Category category)
        {
            Category cat = db.Categories.FirstOrDefault(a => a.CategoryName == category.CategoryName);

            if (ModelState.IsValid && cat == null)
            {
                db.Entry(category).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();

                return Json(data: new { success = true }, JsonRequestBehavior.AllowGet);
            }

            return View();
        }

        [HttpPost]
        public ActionResult DeleteCategory(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            db.Entry(category).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();

            return Json(data: new { success = true }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult UpdateCategory(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            try
            {
                if (category != null)
                {
                    db.Entry(category).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return Json(data: new { success = true }, JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception)
            {

                throw new Exception("Güncelleme başarısız");
            }
            return View();
        }
    }
}