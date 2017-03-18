using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFirstMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult MyHome()
        {
            ViewData["CurrentTime"] = DateTime.Now.ToString();
            return View();
        }
    }
}