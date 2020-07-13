using MyBlogApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlogApp.Areas.Admin.ViewModel
{
    public class UserLoginViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int UserRoleID { get; set; }
    }
}