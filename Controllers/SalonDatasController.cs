using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Salon1.Models;

namespace Salon1.Controllers
{
    public class SalonDatasController : Controller
    {
        private SalonEntities2 db = new SalonEntities2();
        private SalonOperation s = new SalonOperation();
        // GET: SalonDatas
        public ActionResult Index()
        {           
            return View(s.GetSalonData());
        }

        // GET: SalonDatas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalonData salonData = db.SalonDatas.Find(id);
            if (salonData == null)
            {
                return HttpNotFound();
            }
            return View(salonData);
        }

        // GET: SalonDatas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SalonDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SalonId,SalonName")] SalonData salonData)
        {
            if (ModelState.IsValid)
            {
                db.SalonDatas.Add(salonData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(salonData);
        }

        // GET: SalonDatas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalonData salonData = db.SalonDatas.Find(id);
            if (salonData == null)
            {
                return HttpNotFound();
            }
            return View(salonData);
        }

        // POST: SalonDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SalonId,SalonName")] SalonData salonData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salonData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(salonData);
        }

        // GET: SalonDatas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalonData salonData = db.SalonDatas.Find(id);
            if (salonData == null)
            {
                return HttpNotFound();
            }
            return View(salonData);
        }

        // POST: SalonDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SalonData salonData = db.SalonDatas.Find(id);
            db.SalonDatas.Remove(salonData);
            db.SaveChanges();
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
