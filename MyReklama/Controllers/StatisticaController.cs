using MyReklama.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyReklama.Controllers
{
    public class StatisticaController : Controller
    {
        Statistic stat;
        public StatisticaController()
        {
            stat = new Statistic();
        }
        // GET: Statistica
        public ActionResult Index()
        {
            return View(stat.getListServices());
        }
    }
}