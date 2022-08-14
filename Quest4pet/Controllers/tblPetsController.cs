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
    public class tblPetsController : Controller
    {
        private Model1 db = new Model1();

        // GET: tblPets
        public ActionResult Index()
        {
            var tblPets = db.tblPets.Include(t => t.tblCategory);
            return View(tblPets.ToList());
        }

        // GET: tblPets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPet tblPet = db.tblPets.Find(id);
            if (tblPet == null)
            {
                return HttpNotFound();
            }
            return View(tblPet);
        }

        // GET: tblPets/Create
        public ActionResult Create()
        {
            ViewBag.Category_FID = new SelectList(db.tblCategories, "Category_ID", "Category_Name");
            return View();
        }

        // POST: tblPets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( tblPet tblPet, HttpPostedFileBase pic)
        {
            string fullpath=Server.MapPath("~/content/petpics/" +pic.FileName);
            pic.SaveAs(fullpath);
            tblPet.Pets_Image = "~/content/petpics/" + pic.FileName;

            if (ModelState.IsValid)
            {
                db.tblPets.Add(tblPet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Category_FID = new SelectList(db.tblCategories, "Category_ID", "Category_Name", tblPet.Category_FID);
            return View(tblPet);
        }

        // GET: tblPets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPet tblPet = db.tblPets.Find(id);
            if (tblPet == null)
            {
                return HttpNotFound();
            }
            ViewBag.Category_FID = new SelectList(db.tblCategories, "Category_ID", "Category_Name", tblPet.Category_FID);
            return View(tblPet);
        }

        // POST: tblPets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tblPet tblPet , HttpPostedFileBase pic)
        {
            if (pic != null)
            {
                string fullpath = Server.MapPath("~/content/petpics/" + pic.FileName);
                pic.SaveAs(fullpath);
                tblPet.Pets_Image = "~/content/petpics/" + pic.FileName;
            }
            if (ModelState.IsValid)
            {
                db.Entry(tblPet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Category_FID = new SelectList(db.tblCategories, "Category_ID", "Category_Name", tblPet.Category_FID);
            return View(tblPet);
        }

        // GET: tblPets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPet tblPet = db.tblPets.Find(id);
            if (tblPet == null)
            {
                return HttpNotFound();
            }
            return View(tblPet);
        }

        // POST: tblPets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblPet tblPet = db.tblPets.Find(id);
            db.tblPets.Remove(tblPet);
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
