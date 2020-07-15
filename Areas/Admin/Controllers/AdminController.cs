using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyBlogApp.Models;

namespace MyBlogApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        MyBlogContext db = new MyBlogContext(); 
 
        public ActionResult Index()
        {
            return View(db.Blogs.ToList());
        }
    }
}