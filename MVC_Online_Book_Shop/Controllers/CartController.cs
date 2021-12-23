using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataModel;

namespace MVC_Online_Book_Shop.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult AddCart(Product p) 
        {
            //Order_Detail order_detail = new Order_Detail(o.order_detail_id, o.order_id, o.product_id, 1, o.price);
            Product product = new Product(p.Product_id, p.Product_title, 1, p.Price, p.Image_url, p.Big_image_url);

            //Add vào giỏ hàng
            if (Session["giohang"] == null)
            {
                List<Product> listcart = new List<Product>();
                listcart.Add(product);
                Session["giohang"] = listcart;
                return Json(listcart, JsonRequestBehavior.AllowGet);
            }
            else
            {
                List<Product> listcart = (List<Product>)Session["giohang"];
                //Kiem tra gio hang co san pham do hay chua
                if(listcart.Find(m => m.Product_id == p.Product_id) == null)
                {
                    listcart.Add(product);
                    Session["giohang"] = listcart;
                }
                else
                {
                    listcart.Find(m => m.Product_id == p.Product_id).Quantity =
                        listcart.Find(m => m.Product_id == p.Product_id).Quantity + 1;
                }
                return Json(listcart, JsonRequestBehavior.AllowGet);

            }

            //if(Session["giohang"] == null)
            //{
            //    Session["giohang"] = new List<Order_Detail>();
            //}
            //List<Order_Detail> giohang = Session["giohang"] as List<Order_Detail>;

            //Order_Detail d = null;

            ////Kiểm tra sản phẩm khách hàng chọn có trong giỏ hàng chưa
            //if(giohang.Find(m => m.product_id == o.product_id) == null)
            //{
            //    d = new Order_Detail();
            //    d.product_id = o.product_id;
            //    d.price = o.price;
            //    d.quantity = 1;
            //    giohang.Add(d);
            //}
            //else
            //{
            //    giohang.Find(m => m.product_id == o.product_id).quantity =
            //        giohang.Find(m => m.product_id == o.product_id).quantity + 1;
            //}
            //int Quantity = 0;
            //foreach(Order_Detail c in giohang)
            //{
            //    Quantity = Quantity + c.quantity;
            //}
            //return Json(new { ctd=d, sl=Quantity}, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCart()
        {
            if (Session["giohang"] == null)
            {
                List<Product> listcart = new List<Product>();
                Session["giohang"] = listcart;
                return Json(listcart, JsonRequestBehavior.AllowGet);
            }
            else
            {
                List<Product> listcart = (List<Product>)Session["giohang"];
                Session["giohang"] = listcart;
                return Json(listcart, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult DeleteCart(string product_id)
        {
            if (Session["giohang"] != null)
            {
                List<Product> listcart = (List<Product>)Session["giohang"];
                int index = 0;
                foreach(var item in listcart)
                {
                    if(item.Product_id == product_id)
                    {
                        listcart.RemoveAt(index);
                        break;
                    }
                    index++;
                }
                Session["giohang"] = listcart;
                return Json(listcart, JsonRequestBehavior.AllowGet);
            }
            return null;
        }
    }
}