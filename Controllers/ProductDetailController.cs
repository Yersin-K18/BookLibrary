using BookLibrary.Models;
using System.Web.Mvc;

namespace BookLibrary.Controllers
{
    public class ProductDetailController : Controller
    {
        // GET: ProductDetail
        public ActionResult Index(int id)
        {
            return View(ProductsModel.FindById(id));
        }
    }
}