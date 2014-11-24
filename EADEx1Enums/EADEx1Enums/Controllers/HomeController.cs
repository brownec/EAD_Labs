using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EADEx1Enums.Models;

namespace EADEx1Enums.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Calculate()
        {
            return View(new AzureCloudServices() { InstanceSizeDescription = InstanceSizeDescription.Medium, NumInstances = 2 });
        }

        [HttpPost]
        public ActionResult Calculate(AzureCloudServices acs)
        {
            if(ModelState.IsValid)
            {
                return RedirectToAction("Confirm", acs);
            }
            return View("Calculate");
        }

        public ActionResult Confirm(AzureCloudServices acs)
        {
            ViewBag.Message = "Your contact page.";
            TimeZone tz = TimeZone.CurrentTimeZone;
            String zone = tz.StandardName.ToString();
            String time = DateTime.Now.ToString();
            ViewBag.EADEx1Enums = new String[] { zone, time };
            return View(acs);
        }
    }
}