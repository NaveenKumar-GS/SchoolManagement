using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Schoolmanagementn.Controllers
{
    [Authorize]
   [HandleError]
    public class HomeController : Controller
    {
        private SchoolmanagementEntities db = new SchoolmanagementEntities();

        public ActionResult Index()
        {
            /* throw new Exception();*/
            return View();
        }

       


        public ActionResult LogInProcess(UserRegistration item)
        {
            var result = "";
            UserRegistration data = db.UserRegistrations.Where(a => a.EmailId == item.EmailId).FirstOrDefault();
            if (data != null)
            {
                if (item.EmailId != null && item.Password != null)
                {

                    if ((data.Password) == item.Password)
                    {
                        result = data.EmailId;
                        return Json(result, JsonRequestBehavior.AllowGet);
                    }
                }
            }

            result = "Not Able To LogIn";
            return Json(result, JsonRequestBehavior.AllowGet);


        }



        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}