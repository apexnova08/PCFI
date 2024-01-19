using APIClientApp;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http.Headers;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetEquitySchedule()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7084");
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("EquitySchedule?SellingPrice=20000&ReservationDate=2022-2-2&EquityTerm=5").Result;

            if (response.IsSuccessStatusCode)
            {
                var scheds = await response.Content.ReadFromJsonAsync<IEnumerable<GetResponse>>();
                foreach (var sched in scheds)
                {
                    Console.WriteLine(sched.Interest);
                }
                Console.WriteLine(response);
            }
            else
            {
                Console.WriteLine("Not Epic");
            }

            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}