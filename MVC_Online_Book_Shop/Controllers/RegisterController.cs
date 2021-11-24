using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bussiness;

namespace MVC_Online_Book_Shop.Controllers
{
    public class RegisterController : Controller
    {
        AccountBUS ab = new AccountBUS();
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Register(string us, string pw)
        {
            string res = ab.Register(us, pw);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
}