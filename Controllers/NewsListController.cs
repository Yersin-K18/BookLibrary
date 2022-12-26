using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookLibrary.Controllers
{
    public class NewsListController : Controller
    {
        // GET: NewList
        public ActionResult Index()
        {
            return View();
        }
    }
}