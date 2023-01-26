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

            User user;

            if (username.IndexOf("@") == -1)
            {
                user = db.Users
                        .Where(item => item.username == username)
                        .First();
            }
            else
            {
                user = db.Users
                        .Where(item => item.Email == username)
                        .First();
            }

            if (user == null) return null;

            if (user.password == password)
            {
                return user;
            }

            return null;
        }
    }
}