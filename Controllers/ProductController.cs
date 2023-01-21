using BookLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookLibrary.Controllers
{
    public class ProductController : Controller
    {
        BookLibraryEntities db = new BookLibraryEntities();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public ActionResult AllCategory()
        {
            return PartialView("_getAllCategory", db.Categories);
        }

        public ActionResult sachgiaokhoa() => PartialView("_SachGiaoKhoa", db.Products);
    }
}