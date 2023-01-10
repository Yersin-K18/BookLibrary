using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Management;
using System.Web.Mvc;

namespace BookLibrary.Models
{
    public class ProductsModel
    {

        static BookLibraryEntities db = new BookLibraryEntities();
        static public List<Product> list_BestSellingProducts(int count)
        {
            
            return db.Products.OrderByDescending(a => a.Name).Take(count).ToList();
        }
    }
}