using BookLibrary.Models;
using System.Web.Mvc;

namespace BookLibrary.Controllers
{

    public class LoginAndRegisterController : Controller
    {
        BookLibraryEntities db = new BookLibraryEntities();
        // GET: LoginAndRegister

        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(FormCollection collection)
        {
            var username = collection["username"];
            var fullname = collection["fullname"];
            var phonenumber = collection["phonenumber"];
            var address = collection["address"];
            var tenDN = collection["email"];
            var matKhau = collection["password"];
            var retypeMatKhau = collection["retypeMatKhau"];
            User KH = new User();
            // kiểm tra xem mật khẩu nhập lại có khớp với mật khẩu không

            if (matKhau != retypeMatKhau)
            {
                ViewBag.ThongBao = "Mật khẩu nhập lại không khớp";
            }

            // kiểm tra các ràng buộc của User
            else
            {
                // lưu thông tin User vào CSDL
                // ...
                if (UserModel.GetIDUser() == 0)
                {
                    KH.id = 1;
                }
                else
                {
                    KH.id = UserModel.GetIDUser() - 1;
                }
                KH.username = username;
                KH.FullName = fullname;
                KH.Sdt = phonenumber;
                KH.DiaChi = address;
                KH.Email = tenDN;
                KH.password = matKhau;


                db.Users.Add(KH);
                db.SaveChanges();
                // chuyển hướng đến trang đăng nhập
                return RedirectToAction("DangNhap");
            }


            return this.DangKy();
        }
        [HttpGet]
        public ActionResult DangNhap()
        {
            if (Session["user"] != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection collection)
        {
            var tenDN = collection["TenDN"];
            var matKhau = collection["MatKhau"];
            User kh = UserModel.VerifyCredentials(tenDN, matKhau);
            if (kh != null)
            {
                Session["user"] = kh;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ThongBao = "Tên đăng nhập hoặc mật khẩu không đúng";
                return View();
            }
        }
    }
}