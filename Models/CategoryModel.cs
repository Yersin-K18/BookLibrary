using System.Collections.Generic;
using System.Linq;

namespace BookLibrary.Models
{
    public class CategoryModel
    {
        static BookLibraryEntities database = new BookLibraryEntities();

        public List<Category> GetCategories()
        {
            return database.Categories.ToList();
        }
    }
}