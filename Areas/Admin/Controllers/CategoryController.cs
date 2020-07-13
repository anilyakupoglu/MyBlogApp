using MyBlogApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlogApp.Controllers
{
    public class CategoryController : Controller
    {
        private MyBlogContext db = new MyBlogContext();
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

        public ActionResult CreateCategory(Category category)
        {
            db.Categories.Add(category);
            return View();
        }
    }
}