using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using XPS.RomanConverter.Helpers;
using XPS.RomanConverter.Models;
using XPS.RomanConverter.Models;

namespace XPS.RomanConverter.Controllers
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


        [HttpPost]
        public IActionResult Index(ConverterModel model)
        {
            model.RomanNumber = RomanConverterHelper.CovertToRoman(model.Number);
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