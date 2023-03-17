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
            JsonResult response;
            if (user is null)
            {
                response = new JsonResult()
                {

                    Data = new
                    {
                        message = "Failure",
                        token = ""
                    }
                };
            }
            else
            {
                response = new JsonResult()
                {
                    Data = new
                    {
                        message = "Success",
                        token = ""
                    }
                };
            }
            return response;
        }
        // fetch("/Login/Login?username=admin&password=1", { "method": "POST"})
        // .then(res => res.json())
        // .then(res => console.log(res))
    }
}