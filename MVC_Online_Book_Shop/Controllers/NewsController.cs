﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Online_Book_Shop.Controllers
{
    public class NewsController : Controller
    {
        // GET: New
        public ActionResult Index()
        {
            return View("News");
        }
    }
}