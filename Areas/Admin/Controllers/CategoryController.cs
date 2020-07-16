using MyBlogApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlogApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        MyBlogContext db = new MyBlogContext();
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
                db.Categories.Add(category);
                db.SaveChanges();
       
                return Json(data:new {success=true},JsonRequestBehavior.AllowGet);
            }

            return View();
        }
    }
}