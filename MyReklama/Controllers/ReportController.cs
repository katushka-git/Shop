using MyReklama.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MyReklama.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report

        private MyAppContext db = new MyAppContext();
        public async Task<ActionResult> CountService() {
            var result = db.Orders.GroupBy(item1 => item1.Service).Select(item => new { Name = item.Key.Name, Count = item.Count() }).ToList();
            return View(result);
        }
        public ActionResult Index()
        {
            ViewBag.result = db.Orders.GroupBy(item1 => item1.Service).Select(item => new { Name = item.Key.Name, Count = item.Count() }).ToList();
            return View();
        }
    }
}