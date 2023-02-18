using BookLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Management;
using System.Web.Mvc;

namespace BookLibrary.Controllers
{
    public class ShoppingCartController : Controller
    {
        BookLibraryEntities _db = new BookLibraryEntities();
        public List<Cart> GetCarts()
        {
            List<Cart> listCart = Session["Cart"] as List<Cart>;
            if (listCart == null)
            {
                //Neu gio hang chua ton tai thi khoi tao listGioHang
                listCart = new List<Cart>();
                Session["Cart"] = listCart;
            }
            return listCart;
        }
        //Them hang vao gio
        public ActionResult AddCart(int BookID, string strURL)
        {
            //Lay ra Session gio hang
            List<Cart> listCart = GetCarts();
            //Kiem tra sach nay ton tai trong Session["Cart"] chua?
            Cart product = listCart.Find(n => n.BookID == BookID);
            if (product == null)
            {
                product = new Cart(BookID);
                listCart.Add(product);
                return Redirect(strURL);
            }
            else
            {
                product.bQuantity++;
                return Redirect(strURL);
            }
        }
        //Tong SoLuong
        private int TotalQuantity()
        {
            int bTotalQuantity = 0;
            List<Cart> listCart = Session["Cart"] as List<Cart>;
            if (listCart != null)
            {
                bTotalQuantity = listCart.Sum(n => n.bQuantity);
            }
            return bTotalQuantity;
        }
        //Tinh TongTien
        public double TotalPrice()
        {
            double bTotalPrice = 0;
            List<Cart> listCart = Session["Cart"] as List<Cart>;
            if (listCart != null)
            {
                bTotalPrice = listCart.Sum(n => n.bTotal);
            }
            return bTotalPrice;
        }
        //Xay dung trang Cart
        public ActionResult Cart()
        {
            List<Cart> listCart = GetCarts();
            if (listCart.Count == 0)
            {
                Session["Cart"] = null;
                listCart.Clear();
                return RedirectToAction("Index", "Home");
            }
            ViewBag.TotalQuantity = TotalQuantity();
            ViewBag.TotalPrice = TotalPrice();
            return View(listCart);
        }
        //Tạo partial View để hiện thị thông tin giỏ hàng
        public ActionResult _CartPartial()
        {
            ViewBag.TotalQuantity = TotalQuantity();
            ViewBag.TotalPrice = TotalPrice();
            return PartialView("_Cart");
        }
        //xoá sản phẩm khỏi giỏ hàng
        public ActionResult DeleteCart(int bIdPR)
        {
            //Lay gio hang tu session
            List<Cart> listCart = GetCarts();
            Cart product = listCart.SingleOrDefault(n => n.BookID == bIdPR);
            //Neu ton tai thi cho sua SL
            if(product != null)
            {
                listCart.RemoveAll(n => n.BookID == bIdPR);
                return RedirectToAction("Cart");
            }
            
            return RedirectToAction("Cart");
        }
        //CapNhat giỏ hàng
        public ActionResult UpdateCart(int bIdPR, FormCollection f)
        {
            //Lấy giỏ hàng ra từ Session
            List<Cart> listCart = GetCarts();
            Cart product = listCart.SingleOrDefault(n => n.BookID == bIdPR);
            if (product != null)
            {
                product.bQuantity = int.Parse(f["txtQuantity"].ToString());
            }
            return RedirectToAction("Cart");

        }
        //Xoá hết giỏ hàng
        public ActionResult ClearCart()
        {
            //Lấy giỏ hàng từ Session
            
            List<Cart> listCart = GetCarts();
            Session["Cart"] = null;
            listCart.Clear();
            return RedirectToAction("Index", "Home");
        }
        //Hiện thị View Đặt Hàng để cập nhật các thông tin cho Don Hang
        [HttpGet]
        public ActionResult Order()
        {
            //Kiểm tra đăng nhập
            if (Session["user"] == null || Session["user"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "LoginAndRegister");
            }
            if (Session["Cart"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<Cart> listCart = GetCarts();
            ViewBag.TotalQuantity = TotalQuantity();
            ViewBag.TotalPrice = TotalPrice();
            return View(listCart);
            
        }
        public ActionResult Order(FormCollection collection)
        {
            //Them don hang
            Order ddh = new Order();
            User kh = (User)Session["user"];
            List<Cart> gh = GetCarts();
            if(OrdersModel.getOderID() == 0)
            {
                ddh.id = 0;
            }
            else
            {
                ddh.id = OrdersModel.getOderID();
            }

            ddh.DateOrder = DateTime.Now;
            ddh.Address = kh.DiaChi;
            ddh.Total = (decimal)TotalPrice();
            _db.Orders.Add(ddh);
            _db.SaveChanges();
            foreach (var item in gh)
            {
                
                OrderDetail ctdh = new OrderDetail();
                if(OrderDetalModel.getOderDetailID() == 0)
                {
                    ctdh.id = 1;
                }
                else
                {
                    ctdh.id = OrderDetalModel.getOderDetailID();
                }
                ctdh.OrderId = ddh.id;
                ctdh.ProductId = item.BookID;
                ctdh.Quantity = item.bQuantity;
                ctdh.UnitPrice = item.bPrice;
                _db.OrderDetails.Add(ctdh);
                _db.SaveChanges();

            }
            _db.SaveChanges();
            Session["Cart"] = null;
            return RedirectToAction("SubmitOrder","ShoppingCart");


        }
        public ActionResult SubmitOrder()
        {
            return View();
        }
    }
}