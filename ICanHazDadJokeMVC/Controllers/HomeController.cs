using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ICanHazDadJokeMVC.Models;
using Newtonsoft.Json;

namespace ICanHazDadJokeMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            ICanHazDadJokeModel model = new ICanHazDadJokeModel();
            ICanHazDadJokeService service = new ICanHazDadJokeService();
            var resMsg = await service.RandomJoke();
            if (resMsg.IsSuccessStatusCode)
            {
                var response = resMsg.Content.ReadAsStringAsync().Result;
                model = JsonConvert.DeserializeObject<ICanHazDadJokeModel>(response);
            }
            return View(model);
        }

        public async Task<IActionResult> SearchJoke(string searchTerm)
        {
            ICanHazDadJokeListModel models = new ICanHazDadJokeListModel();
            ICanHazDadJokeService service = new ICanHazDadJokeService();
            var resMsg = await service.SearchJoke(searchTerm);
            if (resMsg.IsSuccessStatusCode)
            {
                var response = resMsg.Content.ReadAsStringAsync().Result;
                models = JsonConvert.DeserializeObject<ICanHazDadJokeListModel>(response);
            }
            models.SearchTerm = searchTerm;
            return View(models);
        }

        public IActionResult About()
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
