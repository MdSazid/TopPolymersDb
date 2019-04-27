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
    public class ProformaInvoicesController : Controller
    {
        private TopPolymersDataEntities db = new TopPolymersDataEntities();

        // GET: ProformaInvoices
        public ActionResult Index()
        {
            var proformaInvoices = db.ProformaInvoices.Include(p => p.Currency).Include(p => p.CustomerInfo).Include(p => p.LCNo).Include(p => p.PaymentTerm).Include(p => p.Unite);
            return View(proformaInvoices.ToList());
        }

        // GET: ProformaInvoices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProformaInvoice proformaInvoice = db.ProformaInvoices.Find(id);
            if (proformaInvoice == null)
            {
                return HttpNotFound();
            }
            return View(proformaInvoice);
        }

        // GET: ProformaInvoices/Create
        public ActionResult Create()
        {
            ViewBag.CurrencyId = new SelectList(db.Currencies, "CurrencyId", "Currency1");
            ViewBag.CustomerId = new SelectList(db.CustomerInfoes, "CustomerId", "Customer_Name");
            ViewBag.LC_Id = new SelectList(db.LCNoes, "LC_Id", "LC_No");
            ViewBag.PT_Id = new SelectList(db.PaymentTerms, "PT_Id", "Payment_Term");
            ViewBag.UnitId = new SelectList(db.Unites, "UnitId", "Unit");
            return View();
        }

        // POST: ProformaInvoices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SL_No,PI_No,PI_Date,CustomerId,PI_Value,LC_Id,Price,CurrencyId,Quantity,UnitId,ETD,ETA,PT_Id,Remarks")] ProformaInvoice proformaInvoice)
        {
            if (ModelState.IsValid)
            {
                db.ProformaInvoices.Add(proformaInvoice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CurrencyId = new SelectList(db.Currencies, "CurrencyId", "Currency1", proformaInvoice.CurrencyId);
            ViewBag.CustomerId = new SelectList(db.CustomerInfoes, "CustomerId", "Customer_Name", proformaInvoice.CustomerId);
            ViewBag.LC_Id = new SelectList(db.LCNoes, "LC_Id", "LC_No", proformaInvoice.LC_Id);
            ViewBag.PT_Id = new SelectList(db.PaymentTerms, "PT_Id", "Payment_Term", proformaInvoice.PT_Id);
            ViewBag.UnitId = new SelectList(db.Unites, "UnitId", "Unit", proformaInvoice.UnitId);
            return View(proformaInvoice);
        }

        // GET: ProformaInvoices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProformaInvoice proformaInvoice = db.ProformaInvoices.Find(id);
            if (proformaInvoice == null)
            {
                return HttpNotFound();
            }
            ViewBag.CurrencyId = new SelectList(db.Currencies, "CurrencyId", "Currency1", proformaInvoice.CurrencyId);
            ViewBag.CustomerId = new SelectList(db.CustomerInfoes, "CustomerId", "Customer_Name", proformaInvoice.CustomerId);
            ViewBag.LC_Id = new SelectList(db.LCNoes, "LC_Id", "LC_No", proformaInvoice.LC_Id);
            ViewBag.PT_Id = new SelectList(db.PaymentTerms, "PT_Id", "Payment_Term", proformaInvoice.PT_Id);
            ViewBag.UnitId = new SelectList(db.Unites, "UnitId", "Unit", proformaInvoice.UnitId);
            return View(proformaInvoice);
        }

        // POST: ProformaInvoices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SL_No,PI_No,PI_Date,CustomerId,PI_Value,LC_Id,Price,CurrencyId,Quantity,UnitId,ETD,ETA,PT_Id,Remarks")] ProformaInvoice proformaInvoice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proformaInvoice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CurrencyId = new SelectList(db.Currencies, "CurrencyId", "Currency1", proformaInvoice.CurrencyId);
            ViewBag.CustomerId = new SelectList(db.CustomerInfoes, "CustomerId", "Customer_Name", proformaInvoice.CustomerId);
            ViewBag.LC_Id = new SelectList(db.LCNoes, "LC_Id", "LC_No", proformaInvoice.LC_Id);
            ViewBag.PT_Id = new SelectList(db.PaymentTerms, "PT_Id", "Payment_Term", proformaInvoice.PT_Id);
            ViewBag.UnitId = new SelectList(db.Unites, "UnitId", "Unit", proformaInvoice.UnitId);
            return View(proformaInvoice);
        }

        // GET: ProformaInvoices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProformaInvoice proformaInvoice = db.ProformaInvoices.Find(id);
            if (proformaInvoice == null)
            {
                return HttpNotFound();
            }
            return View(proformaInvoice);
        }

        // POST: ProformaInvoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProformaInvoice proformaInvoice = db.ProformaInvoices.Find(id);
            db.ProformaInvoices.Remove(proformaInvoice);
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
