using MyDailyDairy.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Uow.Package.Data;

namespace MyDailyDairy.UI.Controllers
{
    public class HomeController : Controller
    {
        private IUnitOfWork _unit;

        public HomeController()
        {
            _unit = new UnitOfWork();            
        }       

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}