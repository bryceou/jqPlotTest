using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace jqPlotTest.Controllers
{
    public class PieChartController : Controller
    {
        // GET: PieChart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Donut()
        {
            return View();
        }
    }
}