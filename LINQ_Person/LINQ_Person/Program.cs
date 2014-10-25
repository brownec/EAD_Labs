// Cliff Browne - X00014810
// EAD LINQ Sample Lab - Person (Linq to Memory)
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Person
{
    // Create a collection called Gender to store the sex/gender of the person object
    enum Gender { m, f };

    // Create a Person Class that stores Person first name, last name and gender(sex)
    class Person
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public Gender Sex { get; set; }

        // Override the ToString() Method to return Person details
        public override string ToString()
        {
            return FirstName + " " + LastName + " " + Sex;
        }
    }

    // Test Class
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("EAD LINQ Person Lab");
        }
    }
}
