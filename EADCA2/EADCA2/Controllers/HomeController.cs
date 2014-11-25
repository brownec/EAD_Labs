using EADCA2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EADCA2.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Calculate()
        {
            return View(new M50() { VehicleCategory = VehicleCategory.Car, Tag = false});
        }
        [HttpPost]
        public ActionResult Calculate(M50 m)
        {
            // ViewBag.Message = "Your application description page.";
            if(ModelState.IsValid)
            {
                return View(m);
                // return RedirectToAction("Calculate", m);
            }
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}