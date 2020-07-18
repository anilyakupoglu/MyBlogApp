using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;

namespace MyBlogApp.Models
{
    public class Blog
    {
        public Blog()
        {
            CreateDate = DateTime.Now;
        }
        public int BlogId { get; set; }
        public string Head { get; set; }
        public string Description { get; set; }
        [AllowHtml]
        public string Content { get; set; }
        public string Picture { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsActive { get; set; }
        public bool HomePage { get; set; }


        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}