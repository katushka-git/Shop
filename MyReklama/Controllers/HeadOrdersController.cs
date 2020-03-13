﻿using System;
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
    public class HeadOrdersController : Controller
    {
        private MyAppContext db = new MyAppContext();

        // GET: HeadOrders
        public async Task<ActionResult> Index()
        {
            return View(await db.HeadOrders.ToListAsync());
        }

        // GET: HeadOrders/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HeadOrder headOrder = await db.HeadOrders.FindAsync(id);
           
            if (headOrder == null)
            {
                return HttpNotFound();
            }
            return View(headOrder);
        }

        // GET: HeadOrders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HeadOrders/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Date,EmployeeId,ClientId,Sum")] HeadOrder headOrder)
        {
            if (ModelState.IsValid)
            {
                db.HeadOrders.Add(headOrder);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(headOrder);
        }

        // GET: HeadOrders/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HeadOrder headOrder = await db.HeadOrders.FindAsync(id);
            if (headOrder == null)
            {
                return HttpNotFound();
            }
            return View(headOrder);
        }

        // POST: HeadOrders/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Date,EmployeeId,ClientId,Sum")] HeadOrder headOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(headOrder).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(headOrder);
        }

        // GET: HeadOrders/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HeadOrder headOrder = await db.HeadOrders.FindAsync(id);
            if (headOrder == null)
            {
                return HttpNotFound();
            }
            return View(headOrder);
        }

        // POST: HeadOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            HeadOrder headOrder = await db.HeadOrders.FindAsync(id);
            db.HeadOrders.Remove(headOrder);
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
