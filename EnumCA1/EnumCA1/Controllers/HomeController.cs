using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EnumCA1.Models;

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
            return View(azs);
        }
    }
}