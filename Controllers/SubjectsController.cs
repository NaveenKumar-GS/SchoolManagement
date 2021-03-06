using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Schoolmanagementn;

namespace Schoolmanagementn.Controllers
{
    public class SubjectsController : Controller
    {
        private SchoolmanagementEntities db = new SchoolmanagementEntities();

        // GET: Subjects
        public ActionResult Index()
        {
            var subjects = db.Subjects.Include(s => s.Class1);
            return View(subjects.ToList());
        }

        // GET: Subjects/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                /* return RedirectToAction("404");*/
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
        }
            Subject subject = db.Subjects.Find(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }

        // GET: Subjects/Create
        public ActionResult Create()
        {
            ViewBag.Class = new SelectList(db.Classes, "ClassId", "ClassName");
            return View();
        }

        // POST: Subjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SubjectId,SubjectName,Class")] Subject subject)
        {
            
                if (ModelState.IsValid)
                {
                    db.Subjects.Add(subject);
                    db.SaveChanges();
                    TempData["AlertMessage"] = "Subject Created Successfully...!";
                    return RedirectToAction("Details");
                }
            ViewBag.Class = new SelectList(db.Classes, "ClassId", "ClassName", subject.Class);
            return View(subject);
            }

        // GET: Subjects/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = db.Subjects.Find(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            ViewBag.Class = new SelectList(db.Classes, "ClassId", "ClassName", subject.Class);
            return View(subject);
        }

        // POST: Subjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SubjectId,SubjectName,Class")] Subject subject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subject).State = EntityState.Modified;
                db.SaveChanges();
                TempData["AlertMessage"] = "Subject Edited Successfully...!";
                return RedirectToAction("Index");
            }
            ViewBag.Class = new SelectList(db.Classes, "ClassId", "ClassName", subject.Class);
            return View(subject);
        }

        // GET: Subjects/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = db.Subjects.Find(id);
            if (subject == null)
            { 
                return HttpNotFound();
            }
            return View(subject);
           
        }

        // POST: Subjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Subject subject = db.Subjects.Find(id);

            db.Subjects.Remove(subject);

            db.SaveChanges();
            TempData["AlertMessageDelete"] = "Subject Deleted Successfully...!";
            
            return RedirectToAction("Index");
        }

        
    }
}
