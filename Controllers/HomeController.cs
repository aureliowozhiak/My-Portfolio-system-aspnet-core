﻿using System;
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

        private RestClient portfolioItems = new RestClient("https://portfolio-aureliowozhiak.firebaseio.com/portfolio/items.json");
        
        private RestClient portfolioSkills = new RestClient("https://portfolio-aureliowozhiak.firebaseio.com/portfolio/skills.json");

        public IActionResult Index()
        {

            var request = new RestRequest("", Method.GET);

            //items

            IRestResponse responsePortfolioItems = portfolioItems.Execute(request);

            var responsePortfolioItemsContent = JsonSerializer.Deserialize<List<Portfolio>>(responsePortfolioItems.Content);

            //skillss

            IRestResponse responsePortfolioSkilss = portfolioItems.Execute(request);

            var responsePortfolioSkilssContent = JsonSerializer.Deserialize<List<Skills>>(responsePortfolioSkilss.Content);


            //return to model

            var modelItems = responsePortfolioItemsContent.ToList();
            var modelSkills = responsePortfolioSkilssContent.ToList();


            var model = modelItems;

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
