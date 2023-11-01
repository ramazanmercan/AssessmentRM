using GuideFinder.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GuideFinder.API.Controllers
{
    public class HomeController : Controller
    {
        [Route("Home/Index")]
        public async Task<IActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                var responseGuide = await client.GetStringAsync("http://localhost:5000/api/guide");

                var guideList = JsonConvert.DeserializeObject<List<Guide>>(responseGuide);

                return View(guideList);
            }
        }

    }
}
