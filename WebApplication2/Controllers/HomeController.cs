using AnnonsSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PrenumerantSystem.Models;
using System.Collections.Generic;
using System.Diagnostics;
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
                return RedirectToAction("ForetagsFormular");
            } else
            {
                return Content("fel: väljett alternativ");
            }
            
        }


        //[HttpGet]
        //public IActionResult Index1()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Index1(AnnonsorDetails ad)
        //{
        //    AnnonsorMethods am = new AnnonsorMethods();
        //    int id = am.InsertAnnosor(ad, out string errormsg);

        //    return RedirectToAction("Index1");
        //}

        [HttpGet]
        public IActionResult ForetagsFormular()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ForetagsFormular(AnnonsorDetails ad)
        {
            AnnonsorMethods am = new AnnonsorMethods();
            int id = am.InsertAnnosor(ad, out string errormsg);
            
            TempData["f_id"] = id;


            return RedirectToAction("SkapaAnnons");
        }

        [HttpGet]
        public IActionResult GetPrenumerant()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PrenumerantFormular(int p_id)
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

        [HttpPost]
        public async Task<IActionResult> PrenumerantFormular2(PrenumerantDetails pd)
        {
            //PrenumerantDetails prenumerant = new PrenumerantDetails();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.PutAsJsonAsync<PrenumerantDetails>("api/Values", pd);

            if (res.IsSuccessStatusCode)
            {
                TempData["p_id"] = pd.pr_Id;
                return RedirectToAction("SkapaAnnons");
            }

            return Content("sämst");
        }


        [HttpGet]
        public IActionResult SkapaAnnons()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult SkapaAnnons(AdDetails ad)
        {
            AdMethods am = new AdMethods();

            if (TempData["f_id"] != null)
            {
                ad.ad_F_Annonsor = (int)TempData["f_id"];
                ad.ad_AdPrice = 40;
                am.CreateAd(ad, out string errormsg);
                //lägg till i databas
                TempData["f_id"] = null;



            } else if (TempData["p_id"] != null)
            {
                ad.ad_P_Annonsor = (int)TempData["p_id"];
                ad.ad_AdPrice = 0;
                am.CreateAd(ad, out string errormsg);
                //lägg till i databas
                TempData["p_id"] = null;


            }
            return RedirectToAction("Annonser");
        }


        public IActionResult Annonser()
        {
            List<AdDetails> adl = new List<AdDetails>();
            AdMethods am = new AdMethods();
            adl = am.GetAdList(out string errormsg);

            return View(adl);
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
