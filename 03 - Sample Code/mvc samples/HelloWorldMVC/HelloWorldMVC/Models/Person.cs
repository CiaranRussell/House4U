using System;

namespace HelloWorldMVC.Models
{
    // a simple model class
    // model contains business logic and data access logic
    public class Person
    {
        public String Name { get; set; }
        public int Age { get; set; }
    }

    // no validation yet, cf Data Annotations
}