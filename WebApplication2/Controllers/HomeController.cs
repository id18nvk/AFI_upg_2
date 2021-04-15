using AnnonsSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string typ)
        {
            if (typ == "prenumerant") { 
                return RedirectToAction("Index");//skicka vidarekk

            } else if (typ == "foretag")
            {
                return RedirectToAction("Index1");
            } else
            {
                return Content("fel: väljett alternativ");
            }
            
        }


        [HttpGet]
        public IActionResult Index1()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index1(AnnonsorDetails ad)
        {
            AnnonsorMethods am = new AnnonsorMethods();
            int id = am.InsertAnnosor(ad, out string errormsg);

            return View();
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
