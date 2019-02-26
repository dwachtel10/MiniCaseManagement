using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CaseManagementv4Code.Models;

namespace CaseManagementv4Code.Controllers
{
    public class CaseDetailsController : Controller
    {
        private CaseManagementv4Entities db = new CaseManagementv4Entities();

        // GET: CaseDetails
        public ActionResult Index()
        {
            var caseDetails = db.CaseDetails.Include(c => c.CaseMaster);
            return View(caseDetails.ToList());
        }

        // GET: CaseDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaseDetail caseDetail = db.CaseDetails.Find(id);
            if (caseDetail == null)
            {
                return HttpNotFound();
            }
            return View(caseDetail);
        }

        // GET: CaseDetails/Create
        public ActionResult Create()
        {
            ViewBag.CaseID = new SelectList(db.CaseMasters, "CaseID", "CaseNumber");
            return View();
        }

        // POST: CaseDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DetailsID,CaseID,DefendantLastName,DefendantFirstName,DefendantAddress,DefendantCity,DefendantState")] CaseDetail caseDetail)
        {
            if (ModelState.IsValid)
            {
                db.CaseDetails.Add(caseDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CaseID = new SelectList(db.CaseMasters, "CaseID", "CaseNumber", caseDetail.CaseID);
            return View(caseDetail);
        }

        // GET: CaseDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaseDetail caseDetail = db.CaseDetails.Find(id);
            if (caseDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.CaseID = new SelectList(db.CaseMasters, "CaseID", "CaseNumber", caseDetail.CaseID);
            return View(caseDetail);
        }

        // POST: CaseDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DetailsID,CaseID,DefendantLastName,DefendantFirstName,DefendantAddress,DefendantCity,DefendantState")] CaseDetail caseDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(caseDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CaseID = new SelectList(db.CaseMasters, "CaseID", "CaseNumber", caseDetail.CaseID);
            return View(caseDetail);
        }

        // GET: CaseDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaseDetail caseDetail = db.CaseDetails.Find(id);
            if (caseDetail == null)
            {
                return HttpNotFound();
            }
            return View(caseDetail);
        }

        // POST: CaseDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CaseDetail caseDetail = db.CaseDetails.Find(id);
            foreach (Charge c in caseDetail.Charges)
            { db.Charges.Remove(c); }
            db.CaseDetails.Remove(caseDetail);
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
