using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bussiness;
using DataModel;

namespace MVC_Online_Book_Shop.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        CategoryBUS cb = new CategoryBUS();
        // GET: Admin/Category
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetCategories()
        {
            List<Category> categories = cb.GetCategories();
            return Json(categories, JsonRequestBehavior.AllowGet);
        }
    }
}