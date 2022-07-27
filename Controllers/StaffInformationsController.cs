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
    
    public class StaffInformationsController : Controller
    {
        private SchoolmanagementEntities db = new SchoolmanagementEntities();

        // GET: StaffInformations
        public ActionResult Index()
        {
            var staffInformations = db.StaffInformations.Include(s => s.Department1).Include(s => s.Role1);
            return View(staffInformations.ToList());
        }

        // GET: StaffInformations/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StaffInformation staffInformation = db.StaffInformations.Find(id);
            if (staffInformation == null)
            {
                return HttpNotFound();
            }
            return View(staffInformation);
        }

        // GET: StaffInformations/Create
        public ActionResult Create()
        {
            ViewBag.Department = new SelectList(db.Departments, "DeptId", "DepartmentName");
            ViewBag.Role = new SelectList(db.Roles, "RoleId", "RoleName");
            return View();
        }

        // POST: StaffInformations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Department,Role,StaffId,FullName,FatherName,MotherName,DateOfBirth,Age,Gender,DateOfJoin,Address,PhoneNumber,Nationality,State")] StaffInformation staffInformation)
        {
            if (ModelState.IsValid)
            {
                db.StaffInformations.Add(staffInformation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Department = new SelectList(db.Departments, "DeptId", "DepartmentName", staffInformation.Department);
            ViewBag.Role = new SelectList(db.Roles, "RoleId", "RoleName", staffInformation.Role);
            return View(staffInformation);
        }

        // GET: StaffInformations/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StaffInformation staffInformation = db.StaffInformations.Find(id);
            if (staffInformation == null)
            {
                return HttpNotFound();
            }
            ViewBag.Department = new SelectList(db.Departments, "DeptId", "DepartmentName", staffInformation.Department);
            ViewBag.Role = new SelectList(db.Roles, "RoleId", "RoleName", staffInformation.Role);
            return View(staffInformation);
        }

        // POST: StaffInformations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Department,Role,StaffId,FullName,FatherName,MotherName,DateOfBirth,Age,Gender,DateOfJoin,Address,PhoneNumber,Nationality,State")] StaffInformation staffInformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(staffInformation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Department = new SelectList(db.Departments, "DeptId", "DepartmentName", staffInformation.Department);
            ViewBag.Role = new SelectList(db.Roles, "RoleId", "RoleName", staffInformation.Role);
            return View(staffInformation);
        }

        // GET: StaffInformations/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StaffInformation staffInformation = db.StaffInformations.Find(id);
            if (staffInformation == null)
            {
                return HttpNotFound();
            }
            return View(staffInformation);
        }

        // POST: StaffInformations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            StaffInformation staffInformation = db.StaffInformations.Find(id);
            db.StaffInformations.Remove(staffInformation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

       
    }
}
