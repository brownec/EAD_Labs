using AzureCS.Models;
using System;
using System.Web.Mvc;

namespace AzureCS.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Calculate()
        {
            return View(new AzureCloudServices() { IDS = InstanceSizeDescription.Medium, NumInstances = 2 });
        }
        [HttpPost]
        public ActionResult Calculate(AzureCloudServices acs)
        {
            ViewBag.Message = "Your application description page.";
            if (ModelState.IsValid)
            {
                return (RedirectToAction("Confirm", acs));
            }
            else
            {
                return (RedirectToAction("Calculate", acs));
            }
            // return View(); 
        }

        public ActionResult Confirm(AzureCloudServices acs)
        {
            // ViewBag.Message = "Your contact page.";
            TimeZone tz = TimeZone.CurrentTimeZone;
            String zone = tz.StandardName.ToString();
            String time = DateTime.Now.ToString();
            ViewBag.AzureCS = new String[] { zone, time };
            return View(acs);
        }
    }
}