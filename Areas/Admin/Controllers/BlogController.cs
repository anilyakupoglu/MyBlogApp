using MyBlogApp.Areas.Admin.ViewModel;
using MyBlogApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MyBlogApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BlogController : Controller
    {
        MyBlogContext db = new MyBlogContext();
        public ActionResult Index()
        {
            return View(db.Blogs.ToList());
        }

        [HttpGet]
        public ActionResult CreateBlog()
        {
            BindCategoryDDL();
            return View();
        }
        [HttpPost]
        public ActionResult CreateBlog(Blog blog, HttpPostedFileBase file)
        {
            Blog blogName = db.Blogs.FirstOrDefault(a => a.Head == blog.Head);

            //TODO: jpeg olan resimleri de eklet. detayda gösterirken veri tabnından sadece adını çek
            if (file != null)
            {
                string pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/images"), pic);
                file.SaveAs(path);
                blog.Picture = pic;
                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                }
            }
            try
            {
                if (blog != null && blogName == null)
                {
                    db.Blogs.Add(blog);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Admin");
                }
            }
            catch (Exception)
            {

                throw;
            }
            return View();
        }

        private void BindCategoryDDL()
        {

            List<SelectListItem> selectListItem = new List<SelectListItem>();
            foreach (Category item in db.Categories)
            {
                selectListItem.Add(new SelectListItem()
                {
                    Text = item.CategoryName,
                    Value = item.CategoryId.ToString()
                });
            }
            ViewBag.CategoryBind = selectListItem;
        }

        public PartialViewResult CategoryList()
        {
            var categories = db.Categories.Select(a => new CategoryViewM
            {
                BlogCount = a.Blogs.Count(),
                CategoryName = a.CategoryName
            });
            return PartialView(categories.ToList());
        }
    }
}