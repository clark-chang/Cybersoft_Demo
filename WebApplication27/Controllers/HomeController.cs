using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication27.Models;
using System.Web.Security;

namespace WebApplication27.Controllers
{
    
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
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
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string demodname, string demopassword)
        {

            if (demodname == "demo" && demopassword == "9999")
            {
                FormsAuthentication.RedirectFromLoginPage(demodname, true);
                return RedirectToAction("Index", "Pay");

            }
            ViewBag.message = "帳戶有誤";
            return View();
        }
    }
}