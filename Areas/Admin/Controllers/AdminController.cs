using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyBlogApp.Areas.Admin.ViewModel;
using MyBlogApp.Models;

namespace MyBlogApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        MyBlogContext db = new MyBlogContext();

        public ActionResult Index()
        {
            ViewBag.BlogCount = BlogCount();
            ViewBag.ActiveBlog = IsActiveCount();
            ViewBag.ActiveHome = ActiveHomepageCount();
            ViewBag.PasiveBlog = DeActiveHomepageCount();

    

            BlogDetailViewModel blogDetailView = new BlogDetailViewModel();
            List<Blog> blogs = db.Blogs.ToList();
            List<Category> categories = db.Categories.ToList();
            blogDetailView.Blogs = blogs;
            blogDetailView.Categories = categories;

            return View(blogDetailView);
        }

       
        public int DeActiveHomepageCount()
        {
            return db.Blogs.Where(a => a.HomePage == false).Count();
        }
        public int ActiveHomepageCount()
        {
            return db.Blogs.Where(a => a.HomePage).Count();
        }
        public int BlogCount()
        {
            return db.Blogs.Count();
        }
        public int IsActiveCount()
        {
            return db.Blogs.Where(a => a.IsActive).Count();
        }
    }
}