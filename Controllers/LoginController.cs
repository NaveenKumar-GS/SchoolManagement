using Schoolmanagementn.comman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Schoolmanagementn.Controllers
{
    public class LoginController : Controller
    {
        private const string ActionName = "home";
        SchoolmanagementEntities db = new SchoolmanagementEntities();
        [OutputCache(Duration = 20)]
        // GET: Login
        public ActionResult Create()
        {
            ViewBag.Role = new SelectList(db.Roles, "RoleId", "RoleName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        // Password encryption
        public ActionResult Create(UserRegistration userRegistration)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    Password encoded = new Password();
                    var encryptedPassword = encoded.Encode(userRegistration.Password);
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
        public ActionResult Index()
        {
            
            ViewBag.Time = DateTime.Now.ToLongTimeString();
            return View("Index");
        }

        [HttpPost]
        public ActionResult Index(UserRegistration u, string ReturnUrl)
        {
           

            if (IsValid(u) == true)
            {
                // sets a browser cookie to initiate the user's session.
                // keeps the user logged in each time
                FormsAuthentication.SetAuthCookie(u.PhoneNumber, false);
                Session["username"] = u.PhoneNumber.ToString();

                if (ReturnUrl != null)
                {
                    return Redirect(ReturnUrl);
                }
                else
                {
                    return View("~/Views/Home/Index.cshtml");
                }
            }
            else
            {
                return View();

            }
        }
        public bool IsValid(UserRegistration u)
        {

            if (u != null)
            {
                Password encoded = new Password();
                var encryptedPassword = encoded.Encode(u.Password);
                u.Password = encryptedPassword;

            }
            var credentials = db.UserRegistrations.Where(Model => Model.PhoneNumber == u.PhoneNumber && Model.Password == u.Password).FirstOrDefault();
                //Returns the first element of a default value if the sequence contains no elements.
            
                try
                {
                    if (credentials != null)
                    {

                        return (u.PhoneNumber == credentials.PhoneNumber && u.Password == credentials.Password);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return false;

            }
          
        }
}


