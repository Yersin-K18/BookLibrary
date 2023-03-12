using System.Collections.Generic;
using System.Linq;

namespace BookLibrary.Models
{
    public class ProductsModel
    {

        static BookLibraryEntities db = new BookLibraryEntities();
        static public List<Product> list_BestSellingProducts(int count)
        {
            return db.Products.OrderByDescending(a => a.Name).Take(count).ToList();
        }
        static public List<Product> list_pickedByAuthor()
        {
            return db.Products.OrderByDescending(a => a.Name).Take(5).ToList();
        }
        static public int NumberBook()
        {
            return db.Products.Count();
        }
        static public Product FindById(int id)
        {
            return db.Products.Find(id);
        }
        static public List<Product> FindByName(string Query)
        {
            List<Product> result = new List<Product>();
            result = db.Products
                    .Where(p => p.Name.Contains(Query))
                    .ToList();
            return result;
        }
        public static List<Product> list_ProductFormCategory(int id)
        {
            var query = from pro in db.Products
                        where pro.CategorieID == id
                        select pro;
            return query.ToList();
        }
    }
}