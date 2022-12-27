using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookLibrary.Controllers
{
    public class Index_v1Controller : Controller
    {
        // GET: Index_v1
        public ActionResult Index()
        {
            return View();
        }
    }
}