using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Bussiness;
using DataModel;
using System.IO;

namespace MVC_Online_Book_Shop.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        ProductBUS pb = new ProductBUS();
        // GET: Admin/Product
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public JsonResult Delete(string id)
        {
            string res = pb.DeleteProduct(id);
            return Json(res , JsonRequestBehavior.AllowGet);
        }

        public JsonResult Add(Product p)
        {
            string res = pb.AddProduct(p);
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Update(Product p)
        {
            string res = pb.UpdateProduct(p);
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Upload(string category_id)
        {
            List<string> lst = new List<string>();
            string path = Server.MapPath("~/Public/img/"+ category_id +"/");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            foreach (string key in Request.Files)
            {
                HttpPostedFileBase pf = Request.Files[key];
                pf.SaveAs(path + pf.FileName);
                lst.Add(pf.FileName);
            }
            return Json(lst, JsonRequestBehavior.AllowGet);
        }
    }
}