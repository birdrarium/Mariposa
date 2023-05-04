using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ButterflyController : Controller
    {
        HttpClient client;
        Uri baseAdress = new Uri("https://localhost:5001/api/");

        private readonly ILogger<ButterflyController> _logger;

        public ButterflyController(ILogger<ButterflyController> logger)
        {
            _logger = logger;
            client = new HttpClient();
            client.BaseAddress = baseAdress;
        }

        public async Task<IActionResult> Index()
        {
            List<ButterflyViewModel> butterfliesList = new List<ButterflyViewModel>();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage getData = await client.GetAsync(client.BaseAddress + @"ButterflyAPI");

            if (getData.IsSuccessStatusCode)
            {
                string results = await getData.Content.ReadAsStringAsync();
                butterfliesList = JsonConvert.DeserializeObject<List<ButterflyViewModel>>(results);
            }
            else
            {
                Console.WriteLine("Error calling WebAPI");
            }

            return View(butterfliesList);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}
