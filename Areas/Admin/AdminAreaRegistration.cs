using System.Web.Mvc;

namespace MyBlogApp.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}",
                new { controller = "Login", action = "Login" }
            );
            context.MapRoute(
          "Admin_defaultt",
          "Admin/{controller}/{action}/{id}",
          new { controller = "Login", action = "Login", id = UrlParameter.Optional }
      );

            context.MapRoute(
             "Admin_blog",
             "Blog/{controller}/{action}",
             new { controller = "Blog", action = "Index" },
             namespaces: new string[] { "MyBlogApp.Areas.Admin.Controllers" }
         );
        }
    }
}