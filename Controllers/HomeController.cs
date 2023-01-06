using BookLibrary.Models;
using System.Web.Mvc;

namespace BookLibrary.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly] // Đánh giấu cho biết no là action con, khi chạy thì nó chỉ gọi đúng cái temple này
        public ActionResult menu_Category()
        {
            db_a92489_booklibraryEntities db = new db_a92489_booklibraryEntities(); //khai báo sd entities
            return PartialView("_AllCategory", db.Categories); //trả về view một model
        }
        [ChildActionOnly]
        public ActionResult menu_Cart()
        {
            db_a92489_booklibraryEntities db = new db_a92489_booklibraryEntities();
            return PartialView("_Cart", db.Products);
        }
        public ActionResult Index_v1()
        {
            return View();
        }
        public ActionResult Index_v2()
        {
            return View();
        }
        public ActionResult Index_v3()
        {
            return View();
        }
        public ActionResult GotoIndex()
        {
            return View("Index");
        }
    }
}