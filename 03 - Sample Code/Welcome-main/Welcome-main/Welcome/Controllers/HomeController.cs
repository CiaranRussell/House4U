using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Welcome.Models;

namespace Welcome.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Welcome()
        {
            ViewBag.Message = "Date: " + DateTime.Now.ToShortDateString() + " - Time: " + DateTime.Now.ToShortTimeString();
            return View();
        }
    }
}