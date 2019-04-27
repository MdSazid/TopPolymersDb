using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TopPolymersDb.Models;

namespace TopPolymersDb.Controllers
{
    public class LCNoesController : Controller
    {
        private TopPolymersDataEntities db = new TopPolymersDataEntities();

        // GET: LCNoes
        public ActionResult Index()
        {
            LCNo lcNO = new LCNo();
            lcNO.LCNO = db.LCNoes.ToList();
            return View(lcNO);
        }

        // GET: LCNoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LCNo lCNo = db.LCNoes.Find(id);
            if (lCNo == null)
            {
                return HttpNotFound();
            }
            return View(lCNo);
        }

        // GET: LCNoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LCNoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LC_Id,LC_No,LC_Date")] LCNo lCNo)
        {
            if (ModelState.IsValid)
            {
                db.LCNoes.Add(lCNo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lCNo);
        }

        // GET: LCNoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LCNo lCNo = db.LCNoes.Find(id);
            if (lCNo == null)
            {
                return HttpNotFound();
            }
            return View(lCNo);
        }

        // POST: LCNoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LC_Id,LC_No,LC_Date")] LCNo lCNo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lCNo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lCNo);
        }

        // GET: LCNoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LCNo lCNo = db.LCNoes.Find(id);
            if (lCNo == null)
            {
                return HttpNotFound();
            }
            return View(lCNo);
        }

        // POST: LCNoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LCNo lCNo = db.LCNoes.Find(id);
            db.LCNoes.Remove(lCNo);
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
