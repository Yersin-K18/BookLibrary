using System.Collections.Generic;
using System.Linq;

namespace BookLibrary.Models
{
    public class CategoryModel
    {
        static db_a92489_booklibraryEntities database = new db_a92489_booklibraryEntities();

        public static List<Category> GetCategories()
        {
            return database.Categories.ToList();
        }
    }
}