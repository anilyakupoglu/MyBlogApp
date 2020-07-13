using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlogApp.Models
{
    public class Category
    {
        public Category()
        {
            Blogs = new HashSet<Blog>();
        }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public ICollection<Blog> Blogs { get; set; }
    }
}