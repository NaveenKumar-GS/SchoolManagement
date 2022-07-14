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
    public class StudentInformationsController : Controller
    {
        private SchoolmanagementEntities db = new SchoolmanagementEntities();

        // GET: StudentInformations
        public ActionResult Index()
        {
            var studentInformations = db.StudentInformations.Include(s => s.Class);
            return View(studentInformations.ToList());
        }

        // GET: StudentInformations/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentInformation studentInformation = db.StudentInformations.Find(id);
            if (studentInformation == null)
            {
                return HttpNotFound();
            }
            return View(studentInformation);
        }

        // GET: StudentInformations/Create
        public ActionResult Create()
        {
            ViewBag.ClassName = new SelectList(db.Classes, "ClassId", "ClassName");
            return View();
        }

        // POST: StudentInformations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentId,FullName,FatherName,MotherName,DateOfBirth,Age,Gender,PhoneNumber,Address,DateOfAdmission,ClassName,Religion,Nationality,State")] StudentInformation studentInformation)
        {
            if (ModelState.IsValid)
            {
                db.StudentInformations.Add(studentInformation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassName = new SelectList(db.Classes, "ClassId", "ClassName", studentInformation.ClassName);
            return View(studentInformation);
        }

        // GET: StudentInformations/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentInformation studentInformation = db.StudentInformations.Find(id);
            if (studentInformation == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassName = new SelectList(db.Classes, "ClassId", "ClassName", studentInformation.ClassName);
            return View(studentInformation);
        }

        // POST: StudentInformations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentId,FullName,FatherName,MotherName,DateOfBirth,Age,Gender,PhoneNumber,Address,DateOfAdmission,ClassName,Religion,Nationality,State")] StudentInformation studentInformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentInformation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassName = new SelectList(db.Classes, "ClassId", "ClassName", studentInformation.ClassName);
            return View(studentInformation);
        }

        // GET: StudentInformations/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentInformation studentInformation = db.StudentInformations.Find(id);
            if (studentInformation == null)
            {
                return HttpNotFound();
            }
            return View(studentInformation);
        }

        // POST: StudentInformations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            StudentInformation studentInformation = db.StudentInformations.Find(id);
            db.StudentInformations.Remove(studentInformation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

      
    }
}
