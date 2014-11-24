using EnumCA1.Models;
using System;
using System.Web.Mvc;

namespace EnumCA1.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Calculate()
        {
            return View(new AzureServices() { ISD = InstanceSizeDescription.VerySmall, NumInstances = 2});
        }

        [HttpPost]
        public ActionResult Calculate(AzureServices azs)
        {
            ViewBag.Message = "Your application description page.";
            if (ModelState.IsValid)
            {
                return (RedirectToAction("Confirm", azs));
            }
            else
            {
                return (RedirectToAction("Calculate", azs));
            }
        }

        public ActionResult Confirm(AzureServices azs)
        {
            ViewBag.Message = "Your contact page.";
            TimeZone tz = TimeZone.CurrentTimeZone;
            String zone = tz.StandardName.ToString();
            String time = DateTime.Now.ToString();
            ViewBag.EnumCA1 = new String[] {zone, time };
            return View(azs);
        }
    }
}