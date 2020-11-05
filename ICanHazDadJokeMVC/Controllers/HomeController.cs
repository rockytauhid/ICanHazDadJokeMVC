using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ICanHazDadJokeMVC.Models;

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
            model = await service.RandomJoke();
            return View(model);
        }

        public async Task<IActionResult> SearchJoke(string searchTerm)
        {
            ICanHazDadJokeListModel model = new ICanHazDadJokeListModel();

            ICanHazDadJokeService service = new ICanHazDadJokeService();
            model = await service.SearchJoke(searchTerm);
            model.SearchTerm = searchTerm;
            return View(model);
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
