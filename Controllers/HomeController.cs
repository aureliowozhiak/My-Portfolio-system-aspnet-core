using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using My_Portfolio_system.Models;
using RestSharp;

namespace My_Portfolio_system.Controllers
{
    public class HomeController : Controller
    {

        private RestClient client = new RestClient("https://portfolio-aureliowozhiak.firebaseio.com/portfolio.json");

        public IActionResult Index()
        {

            var request = new RestRequest("", Method.GET);

            IRestResponse response = client.Execute(request);

            var responseContent = JsonSerializer.Deserialize<List<Portfolio>>(response.Content);

            var model = responseContent.ToList();

            return View(model);
        }

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
