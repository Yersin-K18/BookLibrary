using BookLibrary.Models;
using System.Web.Mvc;

namespace BookLibrary.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            int? userId = (int?)Session["user_id"];
            string userName = (string)Session["user_name"];
            if (userId != null) return View("Manage");
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
            Session["user_id"] = user.id;
            Session["user_name"] = user.username;
            return View("Manage");
        }

        public ActionResult Manage()
        {
            int? userId = (int?)Session["user_id"];
            string userName = (string)Session["user_name"];
            if (userId is null || string.IsNullOrWhiteSpace(userName)) return View("Index");
            return View();
        }
    }
}