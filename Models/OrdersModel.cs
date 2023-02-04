using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookLibrary.Models
{
    public class OrdersModel
    {
        public static BookLibraryEntities db = new BookLibraryEntities();
        static public int getOderID()
        {
            return db.Orders.Count() + 1;
        }

    }
}