using MyBlogApp.Areas.Admin.ViewModel;
using MyBlogApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlogApp.Areas.Admin.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
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