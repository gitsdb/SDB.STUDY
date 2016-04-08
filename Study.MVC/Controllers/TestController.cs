using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Study.MVC.Controllers
{
    public class TestController : Controller
    {
        //GET: Test
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public string GetString()
        {
            return "Hello,this is test program.";
        }
        public ActionResult GetView()
        {
            return View("MyView");
        }
    }
}