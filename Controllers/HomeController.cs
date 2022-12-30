using System.Web.Mvc;

namespace BookLibrary.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index_v1()
        {
            return View();
        }

    }
}