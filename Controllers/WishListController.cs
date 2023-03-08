using BookLibrary.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BookLibrary.Controllers
{
    public class WishListController : Controller
    {
        [HttpPost]
        public ActionResult Index()
        {
            return PartialView("_WishList");
        }
        public ActionResult AddWishList(int id)
        {
            if (Session["WishList"] is null)
            {
                Session["WishList"] = new HashSet<Product>();
            }
            var temp = (HashSet<Product>)Session["WishList"];
            temp.Add(ProductsModel.FindById(id));
            return Index();
        }
        public void RemoveWishList(int id)
        {
            throw new NotImplementedException();
        }
        public int NumberBookInWishList()
        {
            return ((HashSet<Product>)Session["WishList"]).Count;
        }
    }
}