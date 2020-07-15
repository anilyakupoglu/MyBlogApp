namespace MyBlogApp.Migrations
{
    using MyBlogApp.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MyBlogApp.Models.MyBlogContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MyBlogApp.Models.MyBlogContext context)
        {
            List<Category> categories = new List<Category>()
            {
                new Category(){CategoryName="C#"},
                 new Category(){CategoryName="ASP.NET"},
                  new Category(){CategoryName="ASP.NET Core"},
                   new Category(){CategoryName="Flutter Mobil Programlama"},
                    new Category(){CategoryName="Xamarin Mobil Programlama"},
            };

            foreach (Category item in categories)
            {
                context.Categories.Add(item);
            }
            context.SaveChanges();

            List<Blog> blogs = new List<Blog>()
            {
                new Blog(){ Head="C# Delegates",Description="Delegate hakkında bilgi", CreateDate=DateTime.Now.AddDays(-10), IsActive=true,HomePage=true,CategoryId=1, Content="Delege hakkında birçok bilgi bu blog altında yazıyı okumaya devam edin", Picture="image_2.jpg"},
                  new Blog(){ Head="ASP.NET Blog Yapımı",Description="ASP.NET Blog Yapımı hakkında bilgi", CreateDate=DateTime.Now.AddDays(-7), IsActive=true,HomePage=true,CategoryId=2, Content="ASP.NET Blog Yapımı hakkında birçok bilgi bu blog altında yazıyı okumaya devam edin", Picture="image_3.jpg"},
                    new Blog(){ Head="Flutter ile mobil programlama",Description="Flutter ile mobil programlama hakkında bilgi", CreateDate=DateTime.Now.AddDays(-2), IsActive=true,HomePage=true,CategoryId=4, Content="Flutter ile mobil programlama hakkında birçok bilgi bu blog altında yazıyı okumaya devam edin", Picture="image_4.jpg"},
                    new Blog(){ Head="Xamarin ile mobil programlama",Description="Xamarin ile mobil programlama hakkında bilgi", CreateDate=DateTime.Now.AddDays(-2), IsActive=false,HomePage=false,CategoryId=5, Content="Xamarin ile mobil programlama hakkında birçok bilgi bu blog altında yazıyı okumaya devam edin", Picture="image_4.jpg"},
                      new Blog(){ Head="ASP.NET Core Yenilikleri",Description="ASP.NET Core Yenilikleri hakkında bilgi", CreateDate=DateTime.Now.AddDays(-2), IsActive=true,HomePage=false,CategoryId=3, Content="ASP.NET Core Yenilikleri hakkında birçok bilgi bu blog altında yazıyı okumaya devam edin", Picture="image_3.jpg"},
            };

            foreach (Blog item in blogs)
            {
                context.Blogs.Add(item);
            }
            context.SaveChanges();

        }
    }
}
