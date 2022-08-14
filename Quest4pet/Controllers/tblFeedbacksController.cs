using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Quest4pet.Models;

namespace Quest4pet.Controllers
{
    public class tblFeedbacksController : Controller
    {
        private Model1 db = new Model1();

        // GET: tblFeedbacks
        public ActionResult Index()
        {
            var tblFeedbacks = db.tblFeedbacks.Include(t => t.tblAccessory).Include(t => t.tblCustomer).Include(t => t.tblPet);
            return View(tblFeedbacks.ToList());
        }

        // GET: tblFeedbacks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblFeedback tblFeedback = db.tblFeedbacks.Find(id);
            if (tblFeedback == null)
            {
                return HttpNotFound();
            }
            return View(tblFeedback);
        }

        // GET: tblFeedbacks/Create
        public ActionResult Create()
        {
            ViewBag.Accessories_FID = new SelectList(db.tblAccessories, "Accessories_ID", "Accessories_Name");
            ViewBag.Customer_FID = new SelectList(db.tblCustomers, "Customer_ID", "Customer_Email");
            ViewBag.Pets_FID = new SelectList(db.tblPets, "Pets_ID", "Pets_Name");
            return View();
        }

        // POST: tblFeedbacks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Feedback_ID,Feedback_Description,Feedback_Image,Feedback_Rating,Customer_FID,Pets_FID,Accessories_FID")] tblFeedback tblFeedback)
        {
            if (ModelState.IsValid)
            {
                db.tblFeedbacks.Add(tblFeedback);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Accessories_FID = new SelectList(db.tblAccessories, "Accessories_ID", "Accessories_Name", tblFeedback.Accessories_FID);
            ViewBag.Customer_FID = new SelectList(db.tblCustomers, "Customer_ID", "Customer_Email", tblFeedback.Customer_FID);
            ViewBag.Pets_FID = new SelectList(db.tblPets, "Pets_ID", "Pets_Name", tblFeedback.Pets_FID);
            return View(tblFeedback);
        }

        // GET: tblFeedbacks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblFeedback tblFeedback = db.tblFeedbacks.Find(id);
            if (tblFeedback == null)
            {
                return HttpNotFound();
            }
            ViewBag.Accessories_FID = new SelectList(db.tblAccessories, "Accessories_ID", "Accessories_Name", tblFeedback.Accessories_FID);
            ViewBag.Customer_FID = new SelectList(db.tblCustomers, "Customer_ID", "Customer_Email", tblFeedback.Customer_FID);
            ViewBag.Pets_FID = new SelectList(db.tblPets, "Pets_ID", "Pets_Name", tblFeedback.Pets_FID);
            return View(tblFeedback);
        }

        // POST: tblFeedbacks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Feedback_ID,Feedback_Description,Feedback_Image,Feedback_Rating,Customer_FID,Pets_FID,Accessories_FID")] tblFeedback tblFeedback)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblFeedback).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Accessories_FID = new SelectList(db.tblAccessories, "Accessories_ID", "Accessories_Name", tblFeedback.Accessories_FID);
            ViewBag.Customer_FID = new SelectList(db.tblCustomers, "Customer_ID", "Customer_Email", tblFeedback.Customer_FID);
            ViewBag.Pets_FID = new SelectList(db.tblPets, "Pets_ID", "Pets_Name", tblFeedback.Pets_FID);
            return View(tblFeedback);
        }

        // GET: tblFeedbacks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblFeedback tblFeedback = db.tblFeedbacks.Find(id);
            if (tblFeedback == null)
            {
                return HttpNotFound();
            }
            return View(tblFeedback);
        }

        // POST: tblFeedbacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblFeedback tblFeedback = db.tblFeedbacks.Find(id);
            db.tblFeedbacks.Remove(tblFeedback);
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
