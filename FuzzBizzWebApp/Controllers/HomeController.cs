using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using FuzzBizzWebApp.Models;
using System.Net.Http;

namespace FuzzBizzWebApp.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index(string userInput)
        {
            List<FizzBuzzViewModel> content = new List<FizzBuzzViewModel>();

            if (userInput != null)
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(@"http://localhost:27278/");
                    string x = userInput;

                    HttpResponseMessage response = client.PostAsJsonAsync("api/FizzBuzz", userInput).Result;                    
                    content = response.Content.ReadAsAsync<List<FizzBuzzViewModel>>().Result;
                }
            }
            return View(content);
        }       
    }
}
