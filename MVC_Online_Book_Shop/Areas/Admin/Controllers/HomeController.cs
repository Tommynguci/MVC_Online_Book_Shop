using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataModel;
using Bussiness;

namespace MVC_Online_Book_Shop.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        ProductBUS pb = new ProductBUS();
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetProductsP(/*int pageIndex, int pageSize, string productName*/)
        {
            //if(Session["Product_title"] ==  null)
            //{
            //    Session.Add("Product_title", "Dr.Stone");
            //}

            ListProduct spl = pb.GetProductsP(1, 3, "abc" /*Session["Product_title"].ToString()*/);
            return Json(spl, JsonRequestBehavior.AllowGet);
        }
    }
}