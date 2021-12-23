using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bussiness;
using DataModel;

namespace MVC_Online_Book_Shop.Controllers
{
    public class BestSellerController : Controller
    {
        ProductBUS pb = new ProductBUS();
        // GET: BestSeller
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult get_5_product()
        {
            List<Product> lst = pb.get_5_product_bestseller();
            return Json(lst, JsonRequestBehavior.AllowGet);
        }

        //public JsonResult get_products()
        //{
        //    //List<Product> lst = pb.get_product_bestseller();
        //    //return Json(lst, JsonRequestBehavior.AllowGet);
        //}

        public JsonResult page(int page)
        {
            int pagesize = 10;

            List<Product> lst = pb.get_product_bestseller(page, pagesize);
            return Json(lst, JsonRequestBehavior.AllowGet);
        }
    }
}