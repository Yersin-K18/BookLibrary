using BookLibrary.Models;
using System;
using System.Web.Mvc;

namespace BookLibrary.Controllers.Services
{
    public class RegisterController : Controller
    {
        [HttpPost]
        public JsonResult Register(String username, string password)
        {
            JsonResult response;
            bool check = UserModel.IsAvailable(username, "");
            if (check is false)
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
                UserModel.AddNewUser(username, password);
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
    }
}