using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bussiness;
using DataModel;

namespace MVC_Online_Book_Shop.Controllers
{
    public class LoginController : Controller
    {
        AccountBUS ab = new AccountBUS();
        // GET: Login
        public ActionResult Index()
        {
            //List<Account> accounts = ab.GetAccounts();
            return View();
        }

        public JsonResult GetAccount()
        {
            List<Account> lst = ab.GetAccounts();
            return Json(lst, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CheckLogin(string us, string pw)
        {
            Account acc = ab.GetAccount(us, pw);
            return Json(acc, JsonRequestBehavior.AllowGet);
        }
    }
}