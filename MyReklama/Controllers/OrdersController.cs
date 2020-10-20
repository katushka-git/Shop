using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyReklama.Models;

namespace MyReklama.Controllers
{
    public class OrdersController : Controller
    {
        private MyAppContext db = new MyAppContext();

        // GET: Orders
        public async Task<ActionResult> Index(int page =1)
        {
            var orders = db.Orders.Include(o => o.Client).Include(o => o.Employee).Include(o => o.Service).ToList();
            int pageSize = 5; // количество объектов на страницу
            IEnumerable<Order> orderPerPages = orders.Skip((page - 1) * pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = orders.Count };
            IndexViewModel2 ivm = new IndexViewModel2 { PageInfo = pageInfo, Orders = orderPerPages };
            return View(ivm);

                 }

        // GET: Orders/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = await db.Orders.FindAsync(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            ViewBag.ClientId = new SelectList(db.Clients, "Id", "FIO");
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "FIO");
            ViewBag.ServiceId = new SelectList(db.Services, "Id", "Name");
            return View();
        }

        // POST: Orders/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,DateOrder,ClientId,EmployeeId,ServiceId")] Order order)
        {
            if (ModelState.IsValid)
            {
                var f = new DateTime();
                order.DateOrder= DateTime.Now;
                db.Orders.Add(order);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ClientId = new SelectList(db.Clients, "Id", "FIO", order.ClientId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "FIO", order.EmployeeId);
            ViewBag.ServiceId = new SelectList(db.Services, "Id", "Name", order.ServiceId);
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = await db.Orders.FindAsync(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientId = new SelectList(db.Clients, "Id", "FIO", order.ClientId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "FIO", order.EmployeeId);
            ViewBag.ServiceId = new SelectList(db.Services, "Id", "Name", order.ServiceId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,DateOrder,ClientId,EmployeeId,ServiceId")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ClientId = new SelectList(db.Clients, "Id", "FIO", order.ClientId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "FIO", order.EmployeeId);
            ViewBag.ServiceId = new SelectList(db.Services, "Id", "Name", order.ServiceId);
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = await db.Orders.FindAsync(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Order order = await db.Orders.FindAsync(id);
            db.Orders.Remove(order);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
