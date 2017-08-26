using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace jqPlotTest.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BarChart()
        {
            return View();
        }

        public ActionResult MultipleSeries()
        {
            return View();
        }

    }
}