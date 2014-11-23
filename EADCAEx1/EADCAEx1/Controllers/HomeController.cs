using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EADCAEx1.Models;

namespace EADCAEx1.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Calculate()
        {
            ViewBag.InstanceSize = new SelectList(AzureCloudServices.InstanceSizeDescription);
            return View(new AzureCloudServices() { NumInstances = 2});
        }

        [HttpPost]
        public ActionResult Calculate(AzureCloudServices acs)
        {
            ViewBag.Message = "Your application description page.";
            if (ModelState.IsValid)
            {
                return RedirectToAction("Confirm", acs);
            }
            else
            {
                ViewBag.InstanceSize = new SelectList(AzureCloudServices.InstanceSizeDescription);
                return View(acs);
            }
        }    
 
        public ActionResult Confirm(AzureCloudServices acs)
        {
            TimeZone tz = TimeZone.CurrentTimeZone;
            String zone = tz.StandardName.ToString();
            String time = DateTime.Now.ToString();
            ViewBag.EADCAEx1 = new String[] { zone, time };
            ViewBag.Message = "Your contact page.";
            return View(acs);
        }
    }
}