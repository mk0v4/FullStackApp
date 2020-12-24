using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tasker.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult index()
        {
            return View();
        }
    }
}