using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Bussiness;
using DataModel;

namespace MVC_Online_Book_Shop.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        AccountBUS ab = new AccountBUS();
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult CheckLogin(string us, string pw)
        {
            Account acc = ab.GetAccount(us, pw);
            if(acc == null)
            {
                return Json(acc, JsonRequestBehavior.AllowGet);

            }
            else
            {
                FormsAuthentication.SetAuthCookie(us, false);
                return Json(acc, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}