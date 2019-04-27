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
    public class PaymentTermsController : Controller
    {
        private TopPolymersDataEntities db = new TopPolymersDataEntities();

        // GET: PaymentTerms
        public ActionResult Index()
        {
            PaymentTerm paymentTerm = new PaymentTerm();
            paymentTerm.PT = db.PaymentTerms.ToList();
            return View(paymentTerm);
        }

        // GET: PaymentTerms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentTerm paymentTerm = db.PaymentTerms.Find(id);
            if (paymentTerm == null)
            {
                return HttpNotFound();
            }
            return View(paymentTerm);
        }

        // GET: PaymentTerms/Create
        public ActionResult Create()
        {
           
            return View();
        }

        // POST: PaymentTerms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PT_Id,Payment_Term")] PaymentTerm paymentTerm)
        {
            if (ModelState.IsValid)
            {
                db.PaymentTerms.Add(paymentTerm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(paymentTerm);
        }

        // GET: PaymentTerms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentTerm paymentTerm = db.PaymentTerms.Find(id);
            if (paymentTerm == null)
            {
                return HttpNotFound();
            }
            return View(paymentTerm);
        }

        // POST: PaymentTerms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PT_Id,Payment_Term")] PaymentTerm paymentTerm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paymentTerm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(paymentTerm);
        }

        // GET: PaymentTerms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentTerm paymentTerm = db.PaymentTerms.Find(id);
            if (paymentTerm == null)
            {
                return HttpNotFound();
            }
            return View(paymentTerm);
        }

        // POST: PaymentTerms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PaymentTerm paymentTerm = db.PaymentTerms.Find(id);
            db.PaymentTerms.Remove(paymentTerm);
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
