using BookLibrary.Models;
using System;
using System.Web.Mvc;

namespace BookLibrary.Controllers.Services
{
    public class LoginController : Controller
    {
        [HttpPost]
        public JsonResult Login(String username, string password)
        {
            User user = UserModel.VerifyCredentials(username, password);
            if (user is null)
            {
                return Json(new
                {
                    message = "Failure",
                    token = ""
                });
            }
            else
            {
                return Json(new
                {
                    message = "Success",
                    token = ""
                });
            }

        }
        // fetch("/Login/Login?username=admin&password=1", { "method": "POST"})
        // .then(res => res.json())
        // .then(res => console.log(res))
    }
}