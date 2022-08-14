using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quest4pet.Models;

namespace Quest4pet.Controllers
{
    public class HomeController : Controller
    {
        Model1 db=new Model1();
        public ActionResult IndexCustomer()
        {
            return View();
        }  
        public ActionResult IndexAdmin()
        {
            return View();
        }
        public ActionResult price()
        {
            return View();
        }     
        public ActionResult pet()
        {
            return View();
        }
          public ActionResult LoginAdmin()
        {
            return View();
        }
        [HttpPost]
          public ActionResult LoginAdmin(string email, string password)
        {
            int v= db.tblAdmins.Where(x=>x.Admin_Email==email && x.Admin_Password==password).Count();
            if(v>0)
            {
                return RedirectToAction("IndexAdmin");
            }
            else
            {
                ViewBag.loginerror = "Invalid Email & Password";
                return View();
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}