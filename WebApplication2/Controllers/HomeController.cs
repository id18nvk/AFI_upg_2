using AnnonsSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PrenumerantSystem.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebApiApp.Helper;
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

        readonly CustomerAPI _api = new CustomerAPI();

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string typ)
        {
            if (typ == "prenumerant") {
                return RedirectToAction("GetPrenumerant");//skicka vidare

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

            return RedirectToAction("Index1");
        }

        [HttpGet]
        public IActionResult GetPrenumerant()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetPrenumerant(int p_id)
        {
            PrenumerantDetails prenumerant = new PrenumerantDetails();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/Values/" + p_id.ToString());

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                prenumerant = JsonConvert.DeserializeObject<PrenumerantDetails>(result);
            }
            return View(prenumerant);
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
