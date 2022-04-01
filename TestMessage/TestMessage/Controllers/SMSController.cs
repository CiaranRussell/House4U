using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestMessage.Models;

namespace TestMessage.Controllers
{
    public class SMSController : Controller
    {
        

        // GET: SMSController/Details/5
        public ActionResult Confirm(SMSMessage msg)
        {
            return View(msg);
        }

        // GET: SMSController/Create
        
        public ActionResult Send()
        {
            return View();
        }

        // POST: SMSController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Send(SMSMessage msg)
        {
            try
            {
                return RedirectToAction("Confirm", msg);
            }
            catch
            {
                return View();
            }
        }

      
    }
}
