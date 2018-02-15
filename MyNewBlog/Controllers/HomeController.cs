using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyNewBlog.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "This is my Blog.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact me here.";

            return View();
        }
    }
}