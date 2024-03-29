﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bussiness;
using DataModel;

namespace MVC_Online_Book_Shop.Controllers
{
    public class HomeController : Controller
    {
        ProductBUS pb = new ProductBUS();

        CategoryBUS cb = new CategoryBUS();

        public ActionResult Index()
        {
            //Session["giohang"] = "";
            //List<Product> products = pb.GetProducts();
            //ViewBag.SoSanPham = products.Count();
            return View();
        }

        public JsonResult GetProducts()
        {
            List<Product> lstproducts = pb.GetProducts();
            ViewBag.SoSanPham = lstproducts.Count();
            return Json(lstproducts, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Category()
        {
            return View();
        }

        [HttpGet]

        public JsonResult GetProductCategory(string CatID)
        {
            List<Product> products = pb.GetProductsCategory(CatID);

            ViewBag.SoSanPham = products.Count();

            return Json(products, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCategories()
        {
            List<Category> categories = cb.GetCategories();

            return Json(categories, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Detail(string id)
        {
            Session.Add("product_id", id);
            return View();
        }

        public JsonResult GetDetail()
        {
            if(Session["product_id"] == null)
            {
                Session["product_id"] = "";
            }
            List<Product> lst = pb.Detail(Session["product_id"].ToString());
            return Json(lst, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get_Top_Product_By_Datetime()
        {
            List<Product> lst = pb.Get_Top_Product_by_datetime();
            return Json(lst, JsonRequestBehavior.AllowGet);
        }

        //public JsonResult get_product_bestseller()
        //{
        //    //List<Product> lst = pb.get_product_bestseller();
        //    //return Json(lst, JsonRequestBehavior.AllowGet);
        //}

        public JsonResult get_5_product_bestseller()
        {
            List<Product> lst = pb.get_5_product_bestseller();
            return Json(lst, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public PartialViewResult GetHeader()
        {
            var lang = 1;
            if (lang == 1)
                return PartialView("_Header");
            else
                return PartialView("_MenuV");
        }

        public PartialViewResult GetFooter()
        {
            return PartialView("_Footer");
        }
    }
}