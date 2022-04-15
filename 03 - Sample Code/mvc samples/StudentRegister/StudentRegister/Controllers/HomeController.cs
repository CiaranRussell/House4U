// GC

using StudentRegister.Models;
using System.Web.Mvc;

namespace StudentRegister.Controllers
{
    public class HomeController : Controller
    {
        // ../Home/Register is default URI              
        [HttpGet]                                       // GET only
        public ActionResult Register()
        {
            return View();                              // strongly typed view, don't need though to pass in a student object
        }

        [HttpPost]
        public ActionResult Register(Student student)
        {
            if (ModelState.IsValid)                     // check server-side validation
            {
                return RedirectToAction("Confirm", student);
            }
            else
            {
                return View();
            }
        }

        // display details of the student just registered
        public ActionResult Confirm(Student student)
        {
            return View(student);
        }
    }
}