using BookLibrary.Models;
using System.Web.Mvc;

namespace BookLibrary.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            if (Session["user"] != null)
                return RedirectToAction("Index", "Home");

            return View();
        }

        [HttpPost]
        public ActionResult Index(string Username_or_Email, string Password)
        {
            User user = UserModel.VerifyCredentials(Username_or_Email, Password);
            if (user == null)
            {
                ViewBag.Error = "Invalid email or password";
                return View();
            }
            Session["user"] = user;
            return RedirectToAction("Index", "Home");
        }
    }
}