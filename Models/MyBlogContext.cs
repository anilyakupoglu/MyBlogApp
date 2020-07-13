using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyBlogApp.Models
{
    public class MyBlogContext : DbContext
    {
        public MyBlogContext() : base("Server =.; Database=MyBlogAppDB;Trusted_Connection=True")
        {

        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

    }
}