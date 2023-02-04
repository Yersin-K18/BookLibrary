using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookLibrary.Models
{

    public class Cart 
    { 
        BookLibraryEntities db = new BookLibraryEntities();
        public int BookID { get; set; }
        public string bName { get; set; }
        public string bImage { get; set; }
        public double bPrice { get; set; }
        public int bQuantity { get; set; }
        public double bTotal { get { return bQuantity * bPrice; } }
        //Khoi tao gio hang theo BookID duoc truyen vao voi SL mac dinh la 1
        public Cart(int ID)
        {
            BookID = ID; 
            Product pr = db.Products.Single(n=> n.ID == BookID);
            bName = pr.Name;
            bImage = pr.Image;
            bPrice = double.Parse(pr.Price.ToString());
            bQuantity = 1;
        }
       
    }

    
    
}