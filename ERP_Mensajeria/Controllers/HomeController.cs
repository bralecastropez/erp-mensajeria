using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP_Mensajeria.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "ERP Mensajeria, en desarrollo";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "bralecastropez@gmail.com";

            return View();
        }
    }
}