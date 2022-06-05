using Core.DTOs;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using MvcCalculator.Models;
using System.Diagnostics;

namespace MvcCalculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICalcService _calcService;

        public HomeController(ILogger<HomeController> logger, ICalcService calcService)
        {
            _logger = logger;
            _calcService = calcService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public string Calculate(string data)
        {
            string result;
            try
            {
                result = _calcService.GetMathResult(data).ToString();
            }
            catch (Exception ex)
            {
                result= ex.Message.ToString();
            }

            return result;
        }

        [HttpGet]
        public List<string> GetCalcHistory()
        {

            return _calcService.GetCalcHistories().ToList();
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