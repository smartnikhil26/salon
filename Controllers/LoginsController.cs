﻿using System;
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
    public class LoginsController : Controller
    {
        private SalonEntities2 db = new SalonEntities2();

        // GET: Logins
        public ActionResult Index()
        {
            var logins = db.Logins.Include(l => l.SalonData).Include(l => l.User);
            return View(logins.ToList());
        }

        // GET: Logins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Login login = db.Logins.Find(id);
            if (login == null)
            {
                return HttpNotFound();
            }
            return View(login);
        }
        // GET: Logins/Create
        public ActionResult Login()
        {
            ViewBag.SalonId = new SelectList(db.SalonDatas, "SalonId", "SalonName");
            ViewBag.User = new SelectList(db.Users, "Id", "UserType");
            return View();
        }
        // POST: Logins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Salon1.Models.LoginViewModel login)
        {
            LoginOperations loginoperation = new LoginOperations();
            var isvalid = loginoperation.Login(login);
            
            if (!isvalid)
            {
                ModelState.AddModelError("fgfg","Invalid username or password");
              
                return View("Index", login);
            }
            else
            {
                Session["UserName"] = login.LoginName;
                var user = loginoperation.GetUserByName(login.LoginName);
                Session["UserType"] = user.User.UserType;
                return RedirectToAction("Index", "Home");

            }
        }
        // GET: Logins/Create
        public ActionResult Create()
        {
            ViewBag.SalonId = new SelectList(db.SalonDatas, "SalonId", "SalonName");
            ViewBag.User = new SelectList(db.UserTypes, "Id", "UserType");
            return View();
        }

        // POST: Logins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Salon1.Models.Login login)
        {
            var user = db.Logins.Where(i => i.LoginName == login.LoginName && i.Password == login.Password).FirstOrDefault();
            if (user == null)
            {
                login.ErrorMessage = "Wrong UserName or Password";
                return View("Index", login);
            }
            else
            {
                Session["userId"] = user.UserId;
                Session["UserName"] = user.LoginName;
                Session["UserType"] = user.User.UserType;
                return RedirectToAction("Index", "Home");

            }
        }

            // GET: Logins/Edit/5
            public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Login login = db.Logins.Find(id);
            if (login == null)
            {
                return HttpNotFound();
            }
            ViewBag.SalonId = new SelectList(db.SalonDatas, "SalonId", "SalonName", login.SalonId);
            ViewBag.User = new SelectList(db.Users, "Id", "UserType", login.User);
            return View(login);
        }

        // POST: Logins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,UserName,Password,User,SalonId")] Login login)
        {
            if (ModelState.IsValid)
            {
                db.Entry(login).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SalonId = new SelectList(db.SalonDatas, "SalonId", "SalonName", login.SalonId);
            ViewBag.User = new SelectList(db.Users, "Id", "UserType", login.User);
            return View(login);
        }

        // GET: Logins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Login login = db.Logins.Find(id);
            if (login == null)
            {
                return HttpNotFound();
            }
            return View(login);
        }

        // POST: Logins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Login login = db.Logins.Find(id);
            db.Logins.Remove(login);
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
