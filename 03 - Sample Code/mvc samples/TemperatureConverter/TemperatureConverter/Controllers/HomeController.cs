// GC

using System.Web.Mvc;

using TemperatureConverter.Models;

namespace TemperatureConverter.Controllers
{
    public class HomeController : Controller
    {
        // initial GET to /Home/Convert, default
        [HttpGet]
        public ActionResult Convert()
        {
            ViewBag.Celsius = 0.0;
            ViewBag.Fahrenheit = Temperature.ConvertCelsiusToFahrenheit(ViewBag.Celsius);
            return View();
        }

        // POST to /Home/Convert
        [HttpPost]               // result of form POST
        public ActionResult Convert(double celsius)
        {
            ViewBag.Celsius = celsius;
            ViewBag.Fahrenheit = Temperature.ConvertCelsiusToFahrenheit(celsius);
            return View();
        }
    }
}