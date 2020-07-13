using MyBlogApp.Models;
using MyBlogApp.Areas.MyBlog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlogApp.Areas.MyBlog.Controllers
{
    public class DefaultController : Controller
    {
        MyBlogContext db = new MyBlogContext();
        public ActionResult Index()
        {
            return View(db.Blogs.ToList());
        }
        public PartialViewResult CategoryList()
        {
            var categories = db.Categories.Select(a => new CategoryViewM
            {
                BlogCount = a.Blogs.Count(),
                 CategoryName = a.CategoryName
            });
            return PartialView(categories.ToList());
        }

    }
}