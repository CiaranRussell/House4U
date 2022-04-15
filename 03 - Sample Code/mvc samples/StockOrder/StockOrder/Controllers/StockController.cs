// GC - simple on-line ordering system for items

using System.Web.Mvc;
using StockOrder.Models;

namespace StockOrder.Controllers
{
    public class StockController : Controller
    {
        // e.g. GET ../Home/Order - default route
        public ActionResult Order()
        {
            Order order = new Order() { ItemCode = "Widget", Qty = 1 };
            return View(order);                             // allow editing of order on view produced i.e. Order.cshtml
        }

        // POST ../Home/Order with data in URI
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Order(Order order)              // model binder creates an order object from POSTed key/value pairs
        {
            // if client side validation in place then will have been completed prior to POST - see web.config ClientSideValidation="true"
            if (ModelState.IsValid)
            {
                return RedirectToAction("Confirm", order);      // move to confirm page i.e. produce a RedirectResult (redirecting client to a new URL)
                // redirect to "Confirm" action on this controller
            }
            else
            {
                return View(order);                         // re-display the order with error messages
            }
        }


        // GET ../Home/Confirm
        public ActionResult Confirm(Order order)
        {
            return View(order);                             // show order details on confirmation page
        }
    }
}