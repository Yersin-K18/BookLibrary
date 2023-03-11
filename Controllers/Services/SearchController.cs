using System.Web.Mvc;

namespace BookLibrary.Controllers.Services
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PreSearch(string query)
        {
            ViewBag.Query = query;
            return PartialView("_PreView");
        }
    }
}