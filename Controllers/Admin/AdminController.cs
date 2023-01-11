using System.Web.Mvc;

namespace BookLibrary.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                ViewBag.Message = "Must input data!";
                return View();
            }
            if (username == "admin" && password == "1")
            {
                return View("Manage");
            }
            return View();
        }

        public ActionResult Manage()
        {
            return View();
        }
    }
}