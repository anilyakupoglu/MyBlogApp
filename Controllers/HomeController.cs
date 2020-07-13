using MyBlogApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlogApp.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private MyBlogContext db = new MyBlogContext();
        public ActionResult Index()
        {
            return View();
        }

 
 
      
    }
}