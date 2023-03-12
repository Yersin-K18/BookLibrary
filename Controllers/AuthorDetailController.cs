using BookLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace BookLibrary.Controllers
{
    public class AuthorDetailController : Controller
    {
        BookLibraryEntities db = new BookLibraryEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult BooksAccordingAuthor(int id) 
        {

           
            var books = from s in db.Products where s.AuthorID == id select s;
            ViewBag.AuthorID = id;
            return View(books);
        }
    }
}