using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bussiness;
using DataModel;

namespace MVC_Online_Book_Shop.Controllers
{
    public class NewestController : Controller
    {
        ProductBUS pb = new ProductBUS();
        // GET: Newest
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult get_product_by_datetime()
        {
            List<Product> lst = pb.get_product_by_datetime();
            return Json(lst, JsonRequestBehavior.AllowGet);
        }

        public JsonResult get_10_product()
        {
            List<Product> lst = pb.Get_10_Product_by_datetime();
            return Json(lst, JsonRequestBehavior.AllowGet);
        }

        public JsonResult page(int page/*, int pagesize*/)
        {
            //if (pageindex == null)
            //{
            //    pageindex = 1;
            //}
            int pagesize = 10;
            //int pageindex = 1;

            List<Product> lst = pb.GetProductsP(page, pagesize);
            return Json(lst, JsonRequestBehavior.AllowGet);
        }
    }
}