// GC

using System;
using System.Collections.Generic;
using System.Web.Mvc;

using HelloWorldMVC.Models;                     // Person 

namespace HelloWorldMVC.Controllers
{
    // ../Hello/
    public class HelloController : Controller
    {
        // all public methods are controller actions, unless [NonAction] used
        
        // controller actions return an ActionResult indirectly 
        // e.g. a ViewResult (HTML), ContentResult (text), EmptyResult, 
        // JsonResult, RedirectResult, JavascriptResult etc.     

        // e.g. GET to ../Hello/SayHello1/Lindsay/22      
        public ActionResult SayHello1(String name, int age)
        {
            // defaults values for name and age in routing table

            Person p = new Person();            // create new model class instance
            p.Name = name;
            p.Age = age;

            // ViewBag is a view dictionary which is a property a controller uses to pass data from the controller to the view
            // it is dynamically typed
            ViewBag.Person = p;

            // call View() on base class to produce and return a ViewResult /Views/Hello/SayHello1.cshtml view
            return View();                      // factory call
            // or return View("SayHello1") to be explicit about view to produce and return
        }

        // GET to /Hello/SayHello2/Natalie/28
        public ActionResult SayHello2(String name, int age)
        {
            Person p = new Person();
            p.Name = name;
            p.Age = age;

            // pass in message to view also
            ViewBag.Words = new List<string> { "hello", "world" };
            return View(p);                     // strongly typed view, pass in the object, SayHello2.cshtml
        }
    }
}