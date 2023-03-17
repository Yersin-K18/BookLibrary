using BookLibrary.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace BookLibrary.Controllers
{
    public class ProductController : Controller
    {
        BookLibraryEntities db = new BookLibraryEntities();
        private int pageSize = 8;

        // GET: Product
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            int skip = (pageNumber - 1) * pageSize;

            var products = db.Products.OrderBy(p => p.ID).Skip(skip).Take(pageSize).ToList();
            ViewBag.PageNumber = pageNumber;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalPages = Math.Ceiling((double)db.Products.Count() / pageSize);

            return View(products);
        }
        [ChildActionOnly]
        public ActionResult AllCategory()
        {
            return PartialView("_getAllCategory", db.Categories);
        }
        [ChildActionOnly]
        public void SetPageSize(int _pageSize)
        {
            pageSize = _pageSize;
            return;
        }
        public ActionResult ListProductFromCategory(int id)
        {
            var proCategory = ProductsModel.list_ProductFormCategory(id);
            return View(proCategory);
        }
    }
}