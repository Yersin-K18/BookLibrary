using System.Linq;

namespace BookLibrary.Models
{
    public class UserModel
    {
        static BookLibraryEntities db = new BookLibraryEntities();
        static public User VerifyCredentials(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return null;
            }

            var user = db.Users
                         .Where(item => item.username == username)
                         .First();

            if (user == null) return null;

            if (user.username == username && user.password == password)
            {
                return user;
            }

            return null;
        }
    }
}