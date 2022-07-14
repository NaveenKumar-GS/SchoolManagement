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
   
    public class ResultsController : Controller
    {
        private SchoolmanagementEntities db = new SchoolmanagementEntities();

        // GET: Results
        
        public ActionResult Index()
        {
            var results = db.Results.Include(r => r.StudentInformation).Include(r => r.Subject);
            return View(results.ToList());
        }

        // GET: Results/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Result result = db.Results.Find(id);
            if (result == null)
            {
                return HttpNotFound();
            }
            return View(result);
        }

        // GET: Results/Create
        public ActionResult Create()
        {
            ViewBag.StudentName = new SelectList(db.StudentInformations, "StudentId", "FullName");
            ViewBag.SubjectName = new SelectList(db.Subjects, "SubjectId", "SubjectName");
            return View();
        }

        // POST: Results/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ResultId,StudentName,SubjectName,TotalMarks,Result1")] Result result)
        {
            if (ModelState.IsValid)
            {
                db.Results.Add(result);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentName = new SelectList(db.StudentInformations, "StudentId", "FullName", result.StudentName);
            ViewBag.SubjectName = new SelectList(db.Subjects, "SubjectId", "SubjectName", result.SubjectName);
            return View(result);
        }

        // GET: Results/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Result result = db.Results.Find(id);
            if (result == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentName = new SelectList(db.StudentInformations, "StudentId", "FullName", result.StudentName);
            ViewBag.SubjectName = new SelectList(db.Subjects, "SubjectId", "SubjectName", result.SubjectName);
            return View(result);
        }

        // POST: Results/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ResultId,StudentName,SubjectName,TotalMarks,Result1")] Result result)
        {
            if (ModelState.IsValid)
            {
                db.Entry(result).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentName = new SelectList(db.StudentInformations, "StudentId", "FullName", result.StudentName);
            ViewBag.SubjectName = new SelectList(db.Subjects, "SubjectId", "SubjectName", result.SubjectName);
            return View(result);
        }

        // GET: Results/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Result result = db.Results.Find(id);
            if (result == null)
            {
                return HttpNotFound();
            }
            return View(result);
        }

        // POST: Results/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Result result = db.Results.Find(id);
            db.Results.Remove(result);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

       
    }
}
