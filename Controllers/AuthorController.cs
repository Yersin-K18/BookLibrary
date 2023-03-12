using BookLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookLibrary.Controllers
{
    public class AuthorController : Controller
    {
        BookLibraryEntities db = new BookLibraryEntities();
        // GET: Author
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult get_listAuthors()
        {

            return PartialView("_listAuthors", db.Authors);
        }

    }
}