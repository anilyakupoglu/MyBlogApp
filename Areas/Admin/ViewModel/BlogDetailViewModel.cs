using MyBlogApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlogApp.Areas.Admin.ViewModel
{
    public class BlogDetailViewModel
    {
        public List<Blog> Blogs { get; set; }
        public List<Category> Categories { get; set; }

    }
}