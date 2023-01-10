using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
        public ActionResult DangNhap()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(string user, string password)
        {
            if (user.ToLower() == "admin" && password == "1")
            {
                Session["user"] = "admin";
                return RedirectToAction("Index");
            }
            else
                return View();
        }
    }
}