using System;
using System.Collections.Generic;
using System.Linq;

namespace Fleet
{
    class Program
    {
        static void Main(string[] args)
        {
            var carFleet  = new List<Fleets>
            {
                new Fleets("BMW","M2","221-D-001",2.0),
                new Fleets("BMW","M1","221-D-002",1.9),
                new Fleets("Renault","Clio","221-D-003",1.8),
                new Fleets("Renault","Megane","221-D-004",1.7),
                new Fleets("Toyota","Corolla","221-D-005",1.6),
                new Fleets("Toyota","Hilux","221-D-011",1.6),
                new Fleets("Toyota","Prius","221-D-006",1.5),
                new Fleets("Honda","Civic","221-D-007",1.4),
                new Fleets("Honda","Accord","221-D-008",1.3),
                new Fleets("Fiat","Punto","221-D-009",1.2),
                new Fleets("Fiat","500","221-D-010",1.1),
            };

            //Console.WriteLine(carFleet.ToString());

            var ListAllCars = carFleet.Select(carFleet => carFleet.Make);

            foreach (var make in ListAllCars)
            {
                Console.WriteLine(make);
            }
                Console.WriteLine("");
                Console.WriteLine("Query 1");

            var ascendindRegistractionOrder = carFleet.OrderBy(carFleet => carFleet.Registration)
                                                        .Select(carFleet => carFleet);

            foreach (var reg in ascendindRegistractionOrder)
            {
                Console.WriteLine(reg);
            }

                Console.WriteLine("");
                Console.WriteLine("Query 2");

            var listmodel = carFleet.Where(carFleet => carFleet.Make == "BMW")
                                    .Select(carFleet => carFleet.Model);

            foreach (var mod in listmodel)
            {
                Console.WriteLine(mod);
            }

                Console.WriteLine("");
                Console.WriteLine("Query 3");

            var listdecending = carFleet.OrderByDescending(carFleet => carFleet.EngizeSeize)
                                        .Select(carFleet => carFleet);

            foreach(var cf in listdecending)
            {
                Console.WriteLine(cf);
            }

                Console.WriteLine("");
                Console.WriteLine("Query 4");

            var listCarsOnEngineSeize = carFleet.Where(carFleet => carFleet.EngizeSeize == 1.6)
                                                .Select(carFleet => new {carFleet.Make, carFleet.Model});
            
            foreach(var lc in listCarsOnEngineSeize)
            {
                Console.WriteLine(lc.Make + lc.Model);

            }

                Console.WriteLine("");
                Console.WriteLine("Query 5");

            var countCarsOnEngineSeize = carFleet.Count(carFleet => carFleet.EngizeSeize <= 1.6);
            
                Console.WriteLine("No of cars with Engine Seize of 1.6 or smaller: " + countCarsOnEngineSeize);
            
                                    
        }
    }
}
