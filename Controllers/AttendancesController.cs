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
    public class AttendancesController : Controller
    {
        private SchoolmanagementEntities db = new SchoolmanagementEntities();

        // GET: Attendances12
        public ActionResult Index()
        {
            var attendances = db.Attendances.Include(a => a.UserRegistration);
            /*throw  new  Exception();*/
            return View(attendances.ToList());
        }

        // GET: Attendances/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendance attendance = db.Attendances.Find(id);
            if (attendance == null)
            {
                return RedirectToAction("404");
            }
            return View(attendance);
        }

        // GET: Attendances/Create
        public ActionResult Create()
        {
            ViewBag.FullName = new SelectList(db.UserRegistrations, "UserId", "FullName");
            return View();
        }

        // POST: Attendances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // Whether the Form values are bound to the Model.All the validations specified inside Model class using Data annotations have been passed.
        [HttpPost]
        public ActionResult Create([Bind(Include = "AttendenceId,FullName,DateTime,Attendance1")] Attendance attendance)
        {
            
                if (ModelState.IsValid)
                {
                    db.Attendances.Add(attendance);
                    db.SaveChanges();
                    TempData["AlertMessage"] = "Attendance Done...!";
                    return RedirectToAction("Index");
                }
            
            
                ViewBag.FullName = new SelectList(db.UserRegistrations, "UserId", "FullName", attendance.FullName);
                return View(attendance);
            } 

        // GET: Attendances/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendance attendance = db.Attendances.Find(id);
            if (attendance == null)
            {
                return RedirectToAction("404");
            }
            ViewBag.FullName = new SelectList(db.UserRegistrations, "UserId", "FullName", attendance.FullName);
            return View(attendance);
        }

        // POST: Attendances/Edit/5
        
        [HttpPost]
        public ActionResult Edit([Bind(Include = "AttendenceId,FullName,DateTime,Attendance1")] Attendance attendance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(attendance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FullName = new SelectList(db.UserRegistrations, "UserId", "FullName", attendance.FullName);
            return View(attendance);
        }

        // GET: Attendances/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendance attendance = db.Attendances.Find(id);
            if (attendance == null)
            {
                
                return RedirectToAction("404");
            }
            return View(attendance);
        }

        // POST: Attendances/Delete/5
        [HttpPost, ActionName("Delete")]
        
        public ActionResult DeleteConfirmed(string id)
        {
            Attendance attendance = db.Attendances.Find(id);
            db.Attendances.Remove(attendance);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

       
    }
}
