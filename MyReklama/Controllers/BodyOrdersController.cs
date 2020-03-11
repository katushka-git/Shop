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
    public class BodyOrdersController : Controller
    {
        private MyAppContext db = new MyAppContext();

        // GET: BodyOrders
        public async Task<ActionResult> Index()
        {
            return View(await db.BodyOrders.ToListAsync());
        }

        // GET: BodyOrders/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BodyOrder bodyOrder = await db.BodyOrders.FindAsync(id);
            if (bodyOrder == null)
            {
                return HttpNotFound();
            }
            return View(bodyOrder);
        }

        // GET: BodyOrders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BodyOrders/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,OrderId,ServiceId,Price,Count,Sum")] BodyOrder bodyOrder)
        {
            if (ModelState.IsValid)
            {
                db.BodyOrders.Add(bodyOrder);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(bodyOrder);
        }

        // GET: BodyOrders/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BodyOrder bodyOrder = await db.BodyOrders.FindAsync(id);
            if (bodyOrder == null)
            {
                return HttpNotFound();
            }
            return View(bodyOrder);
        }

        // POST: BodyOrders/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,OrderId,ServiceId,Price,Count,Sum")] BodyOrder bodyOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bodyOrder).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(bodyOrder);
        }

        // GET: BodyOrders/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BodyOrder bodyOrder = await db.BodyOrders.FindAsync(id);
            if (bodyOrder == null)
            {
                return HttpNotFound();
            }
            return View(bodyOrder);
        }

        // POST: BodyOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            BodyOrder bodyOrder = await db.BodyOrders.FindAsync(id);
            db.BodyOrders.Remove(bodyOrder);
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
