using BookLibrary.Models;
using System.Web.Mvc;

namespace BookLibrary.Controllers
{
    public class HomeController : Controller
    {
        BookLibraryEntities db = new BookLibraryEntities();
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
        [ChildActionOnly]
        public ActionResult menu_Cart()
        {
            BookLibraryEntities db = new BookLibraryEntities();
            return PartialView("_Cart", db.Products);
        }
        [ChildActionOnly]
        public ActionResult get_listBestSelling()
        {

            return PartialView("_listBestSelling", db.Products);
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

        [ChildActionOnly]
        public ActionResult UserLogin()
        {
            if (Session["User"] != null)
            {
                ViewBag.UserName = ((User)Session["User"]).username;
            }

            return PartialView("_UserLogin");
        }
    }
}