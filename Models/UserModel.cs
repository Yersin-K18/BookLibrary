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
                        .FirstOrDefault();
            }
            else
            {
                user = db.Users
                        .Where(item => item.Email == username)
                        .FirstOrDefault();
            }

            if (user == null) return null;

            if (user.password == password)
            {
                return user;
            }

            return null;
        }
        static public int GetIDUser()
        {
            return db.Users.Count() + 1;
        }
        static public bool IsAvailable(string username, string email)
        {
            User temp = db.Users
                .Where(item => item.username == username || item.Email == email)
                .FirstOrDefault();
            if (temp is null)
            {
                return true;
            }
            return false;
        }
        static public void AddNewUser(string username, string password)
        {
            db.Users.Add(new User()
            {
                id = GetIDUser(),
                username = username,
                password = password
            });
            db.SaveChanges();
        }
    }
}