using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookLibrary.Models
{
    public class OrderDetalModel
    {
        public static BookLibraryEntities db = new BookLibraryEntities();
        static public int getOderDetailID()
        {
            return db.OrderDetails.Count() + 1;
        }
    }
}