// Cliff Browne - X00014810
// EAD1 - Lab LINQ - Fleet
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Fleet
{
    // Implement a car class and override ToString() as usual
    public class Car
    {
        // A fleet is a collection of cars. Each car has a make, model, registration and engine size (cc)
        public String Make { get; set; }
        public String Model { get; set; }
        public String Registration { get; set; }
        public int EngineSize { get; set; }

        public override string ToString()
        {
            return Make + " " + Model + " " + Registration + " " + EngineSize;
        }
    }
    
    // Test Class
    class Program
    {
        static void Main(string [] args)
        {
            Console.WriteLine("*****EAD1 LINQ Lab - Fleet*****");
            // Create a fleet collection in memory and populate with some cars
            List<Car> fleet = new List<Car>();
            fleet.Add(new Car() { Make = "Alfa Romeo", Model = "156", Registration = "05 LK 2160", EngineSize = 1600 });
            fleet.Add(new Car() { Make = "Alfa Romeo", Model = "GT", Registration = "05 WK 1900", EngineSize = 1900 });
            fleet.Add(new Car() { Make = "Citroen", Model = "Estate", Registration = "08 D 1000", EngineSize = 1600 });
            fleet.Add(new Car() { Make = "Peugeot", Model = "206", Registration = "02 D 900", EngineSize = 1200 });
            fleet.Add(new Car() { Make = "Toyota", Model = "Yaris", Registration = "08 D 500", EngineSize = 1000 });
            fleet.Add(new Car() { Make = "Toyota", Model = "Yaris", Registration = "08 K 1200", EngineSize = 1000 });
            fleet.Add(new Car() { Make = "VW", Model = "Polo", Registration = "07 WK 8000", EngineSize = 1400 });


// Write LINQ queries on the fleet to:
            // **********QUERY 1. List all cars in ascending registration order**********
            var allCarsRegOrder = fleet.OrderBy(car => car.Registration);
            foreach(var car in allCarsRegOrder)
            {
                Console.WriteLine(car);
            }
            Console.WriteLine();

            // **********QUERY 2. List the models for all Toyota cars in the fleet**********
            var toyotaCars = fleet.Where(car => car.Make == "Toyota").Select(car => car.Model);
            foreach(var car in toyotaCars)
            {
                Console.WriteLine(car);
            }
            Console.WriteLine();

            // **********QUERY 3. List all cars in descending engine size order**********
            var engineSizeDescOrder = fleet.OrderByDescending(car => car.EngineSize);
            foreach(var car in engineSizeDescOrder)
            {
                Console.WriteLine(car);
            }
            Console.WriteLine();

            // **********QUERY 4. List just the make and model for cars whose engine size is 1600 cc**********
            var engineSize1600 = fleet.Select(car => new { car.Make, car.Model });
            foreach(var car in engineSize1600)
            {
                Console.WriteLine("Make: " + car.Make + " " + "Model: " + car.Model);
            }
            Console.WriteLine();
            
            // **********QUERY 5. Count the number of cars whose engine size is 1600 cc or less**********
            var count1600orLess = fleet.Where(car => car.EngineSize <= 1600).Count();
            Console.WriteLine("Number of cars with engines less than 1600 c.c is: " + count1600orLess);
        }
    }
}
