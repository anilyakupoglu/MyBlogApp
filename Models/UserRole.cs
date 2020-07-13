using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlogApp.Models
{
    public class UserRole
    {
        public UserRole()
        {
            Users = new HashSet<User>();
        }
        public int UserRoleID { get; set; }
        public string Role { get; set; }

        public ICollection<User> Users { get; set; }
    }
}