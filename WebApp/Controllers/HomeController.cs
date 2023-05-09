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
    public class HomeController : Controller
    {
        HttpClient client;
        Uri baseAdress = new Uri("https://localhost:5001/api/");

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        //public PostController()
        {
            _logger = logger;
            client = new HttpClient();
            client.BaseAddress = baseAdress;
        }

        public async Task<IActionResult> Index()
        {
            var postsList = new List<PostModel>();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage getData = await client.GetAsync(client.BaseAddress + @"PostAPI");

            if (getData.IsSuccessStatusCode)
            {
                string results = await getData.Content.ReadAsStringAsync();
                postsList = JsonConvert.DeserializeObject<List<PostModel>>(results);
            }
            else
            {
                Console.WriteLine("Error calling WebAPI");
            }

            var viewModel = new HomeViewModel(postsList);
            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}