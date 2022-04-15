using HelloWorldMVC.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Web.Mvc;

using HelloWorldMVC.Models;

namespace HelloWorldMVC.Tests.Controllers
{
    [TestClass]
    public class HelloControllerTest
    {
        [TestMethod]
        public void TestSayHello1()
        {
            HelloController controller = new HelloController();
            ViewResult result = (ViewResult)controller.SayHello1("Gary", 35);           // call controller action
            Assert.AreEqual(result.ViewBag.Person.Name, "Gary");                        // result from action available in ViewBag
            Assert.AreEqual(result.ViewBag.Person.Age, 35);
        }

        [TestMethod]
        public void TestSayHello2()
        {
            HelloController controller = new HelloController();
            ViewResult result = (ViewResult)controller.SayHello2("Gary", 35);
            Person p = (Person) result.Model;                                           // Model instead of ViewBag
            Assert.AreEqual(p.Name, "Gary");
            Assert.AreEqual(p.Age, 35);
            CollectionAssert.AreEqual(result.ViewBag.Words, new List<string> { "hello", "world" });
        }
    }
}
