using MyBlogApp.Areas.Admin.ViewModel;
using MyBlogApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyBlogApp.Areas.Admin.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        MyBlogContext db = new MyBlogContext();

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(string userName, string password)
        {

            User ur = db.Users.FirstOrDefault(a => a.UserName == userName && a.Password == password);
           

            if (ur != null)
            {
                string userRole = FindUserRole(ur.UserRoleID);
                FormsAuthentication.SetAuthCookie(ur.UserName, true);
               
                if (userRole == "Admin")
                {
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    ViewBag.Mesaj ="Yetkisiz erişim";
                    return View();
                }

            }
            else
            {
                ViewBag.Mesaj = "Geçersiz kullanıcı adı veya şifre";
                return View();
            }

        }

       
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login","Login");
        }
        public string FindUserRole(int userRoleID)
        {
            UserRole userRole = db.UserRoles.FirstOrDefault(a => a.UserRoleID == userRoleID);
            return userRole.Role;
        }

    }
}