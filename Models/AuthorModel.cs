using System.Collections.Generic;
using System.Linq;

namespace BookLibrary.Models
{
    public class AuthorModel
    {
        static BookLibraryEntities db = new BookLibraryEntities();

        static public List<Author> TopAuthors(int Number)
        {
            return db.Authors.OrderByDescending(i => i.BooksPublished)
                             .Take(Number)
                             .ToList();
        }
        static public Author getAuthor(int? id)
        {
            
            return db.Authors.Find(id);
        }
    }
}