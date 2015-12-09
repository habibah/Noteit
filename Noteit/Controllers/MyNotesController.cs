using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Noteit.Models;

namespace Noteit.Controllers
{
    public class MyNotesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /MyNotes/
        public ActionResult Index()
        {
            return View(db.MyNotes.ToList());
        }

        // GET: /MyNotes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyNotes mynotes = db.MyNotes.Find(id);
            if (mynotes == null)
            {
                return HttpNotFound();
            }
            return View(mynotes);
        }

        // GET: /MyNotes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /MyNotes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Title,Text,CreatedAt")] MyNotes mynotes)
        {
            if (ModelState.IsValid)
            {
                db.MyNotes.Add(mynotes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mynotes);
        }

        // GET: /MyNotes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyNotes mynotes = db.MyNotes.Find(id);
            if (mynotes == null)
            {
                return HttpNotFound();
            }
            return View(mynotes);
        }

        // POST: /MyNotes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Title,Text,CreatedAt")] MyNotes mynotes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mynotes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mynotes);
        }

        // GET: /MyNotes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyNotes mynotes = db.MyNotes.Find(id);
            if (mynotes == null)
            {
                return HttpNotFound();
            }
            return View(mynotes);
        }

        // POST: /MyNotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MyNotes mynotes = db.MyNotes.Find(id);
            db.MyNotes.Remove(mynotes);
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
