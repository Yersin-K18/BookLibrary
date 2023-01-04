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
            BookLibraryEntities db = new BookLibraryEntities(); //khai báo sd entities
            return PartialView("_AllCategory", db.Categories); //trả về view một model
        }
        public ActionResult Index_v1()
        {
            return View();
        }
        public ActionResult Index_v2()
        {
            return View();
        }

        public ActionResult GotoIndex()
        {
            return View("Index");
        }
    }
}