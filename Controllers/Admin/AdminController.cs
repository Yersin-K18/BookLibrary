using BookLibrary.Models;
using System.Web.Mvc;

namespace BookLibrary.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            if (Session["user"] != null && ((User)Session["user"]).id == 0) return View("Dashboard");

            return View();
        }

        [HttpPost]
        public ActionResult Index(string username, string password)
        {
            User user = UserModel.VerifyCredentials(username, password);
            if (user == null)
            {
                ViewBag.Error = "Invalid email or password";
                return View();
            }
            Session["user"] = user;
            return View("Dashboard");
        }

        public ActionResult Manage()
        {
            if (Session["user"] is null) return View("Index");

            return PartialView("Manage");
        }
        [HttpGet]
        public ActionResult Logout()
        {
            Session["user"] = null;
            return RedirectToAction("Index","Admin");
        }
    }
}