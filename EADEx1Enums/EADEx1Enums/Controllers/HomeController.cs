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
            ViewBag.InstanceSize = new SelectList(AzureCloudServices.InstancePriceDescription);
            return View(new AzureCloudServices() { NumInstances = 2});
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

            return View(acs);
        }
    }
}