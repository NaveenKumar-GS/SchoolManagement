using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Schoolmanagementn;
using Schoolmanagementn.comman;

namespace Schoolmanagementn.Controllers
{
    public class UserRegistrationsController : Controller
    {
        private SchoolmanagementEntities db = new SchoolmanagementEntities();

        // GET: UserRegistrations
        public ActionResult Index()
        {
            var userRegistrations = db.UserRegistrations.Include(u => u.Role1);
            return View(userRegistrations.ToList());
        }

        // GET: UserRegistrations/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRegistration userRegistration = db.UserRegistrations.Find(id);
            
            if (userRegistration == null)
            {
                return HttpNotFound();
            }
            Password decoded = new Password();
            var decryptedPassword = decoded.Decode(userRegistration.Password);
            userRegistration.Password = decryptedPassword;
            Password decodeStrin = new Password();
            var decryptedString = decodeStrin.decodestring(userRegistration.Password);
            userRegistration.Password = decryptedString;

            return View(userRegistration);
        }
        

        // GET: UserRegistrations/Create
       
        public ActionResult Create()
        {
            ViewBag.Role = new SelectList(db.Roles, "RoleId", "RoleName");
            return View();
        }

        // POST: UserRegistrations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        // Password encryption
        
        public ActionResult Create( UserRegistration userRegistration)
        {
            
            try
            {
                if (ModelState.IsValid)
                {
                   Password encoded = new Password();
                    var encryptedPassword=encoded.Encode(userRegistration.Password);
                    userRegistration.Password = encryptedPassword;
                    db.UserRegistrations.Add(userRegistration);
                    db.SaveChanges();
                    TempData["AlertMessage"] = "Registered Successfully...!";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

                ViewBag.Role = new SelectList(db.Roles, "RoleId", "RoleName", userRegistration.Role);

                return View(userRegistration);
            
        }
        
    // GET: UserRegistrations/Edit/5
    public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRegistration userRegistration = db.UserRegistrations.Find(id);
            if (userRegistration == null)
            {
                return HttpNotFound();
            }
            ViewBag.Role = new SelectList(db.Roles, "RoleId", "RoleName", userRegistration.Role);
            Password decoded = new Password();
            var decryptedPassword = decoded.Decode(userRegistration.Password);
            userRegistration.Password = decryptedPassword;
            Password decodeStrin = new Password();
            var decryptedString = decodeStrin.decodestring(userRegistration.Password);
            userRegistration.Password = decryptedString;


            return View(userRegistration);
        }

        // POST: UserRegistrations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserRegistration userRegistration)
        {
            if (ModelState.IsValid)
            {
                Password encoded = new Password();
                var encryptedPassword = encoded.Encode(userRegistration.Password);
                userRegistration.Password = encryptedPassword;
                db.Entry(userRegistration).State = EntityState.Modified;
                db.SaveChanges();
                TempData["AlertMessage"] = "Edited Successfully...!";
                return RedirectToAction("Index");
            }
            ViewBag.Role = new SelectList(db.Roles, "RoleId", "RoleName", userRegistration.Role);
            return View(userRegistration);
        }

        // GET: UserRegistrations/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRegistration userRegistration = db.UserRegistrations.Find(id);
            if (userRegistration == null)
            {
                return HttpNotFound();
            }
            return View(userRegistration);
        }

        // POST: UserRegistrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            UserRegistration userRegistration = db.UserRegistrations.Find(id);
            db.UserRegistrations.Remove(userRegistration);
            db.SaveChanges();
            TempData["AlertMessageDelete"] = " Deleted Successfully..!";
            return RedirectToAction("Index");
        }

       
    }
}
