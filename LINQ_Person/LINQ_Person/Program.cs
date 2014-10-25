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
            // Create a collection of people in memory
            // use the object initializers
            /* List<T> is enumerable since it implements IEnumerable<T>
            so we can run LINQ queries against the objects */
            var people = new List<Person>
            {
                new Person { FirstName = "Cliff", LastName = "Browne", Sex = Gender.m },
                new Person { FirstName = "Britney", LastName = "Spears", Sex = Gender.f},
                new Person { FirstName = "Kelly", LastName = "Brook", Sex = Gender.f}
            };

            // ******************************QUERY # 1******************************
            // Query the FirstName of the people created - Use a METHOD based query
            var everyoneFirstNameQuery = people.Select(person => person.FirstName);

            // Execute the query and output result to console
            foreach (var name in everyoneFirstNameQuery)
            {
                Console.WriteLine(name); // name is of type STRING
            }

            // ******************************QUERY # 2******************************
            // Query the FirstName and LastName of the people created (Do not include the Gender)
            // The result of this query contains items whose type is anonymous
            var everyoneNamesQuery = people.Select(person => new { person.FirstName, person.LastName });

            // Execute the query and output the results to console
            foreach(var person in everyoneNamesQuery)
            {
                Console.WriteLine(person.FirstName + " " + person.LastName);
            }

            // ******************************QUERY # 3******************************
            // Query the girls LastName and ORDER by LastName ascending
            // girlsLastNameAscQuery is a type of IEnumerable<Person>
            // WHERE and ORDERBY are EXTENSION METHODS taking methods as parameters
            var girlsLastNamesAscQuery = people.Where(person => person.Sex == Gender.f).OrderBy(person => person.LastName).Select(person => person);

            // Evaluate the query and iterate over the results
            // Query is not evaluated until it has been iterated over
            foreach(Person girl in girlsLastNamesAscQuery)
            {
                Console.WriteLine(girl.ToString());
            }

            // ******************************QUERY # 4******************************
            // SORT the longet FirstName from Longest to Shortest
            // If tied, sort by FirstName ORDER, select FirstName only
            var sortLongestFirstNameQuery = people.OrderByDescending(person => person.FirstName.Length).ThenBy(person => person.FirstName).Select(person => person.FirstName);

            // Evaluate the query and iterate over the result
            foreach(var p in sortLongestFirstNameQuery)
            {
                Console.WriteLine(p);
            }

            // ******************************QUERY # 5******************************
            // COUNT how many first names are 'Cliff'
            var countQuery = people.Count(person => person.FirstName == "Cliff");
            Console.WriteLine(countQuery); // returns an INT and outputs to console

            // ******************************QUERY # 6******************************
            // GROUP BY Gender
            var groupByGenderQuery = people.GroupBy(person => person.Sex);
            // The result is an Enumerable set of Enumerable sets - the last one containing 1 per group
            foreach(var genderGroup in groupByGenderQuery)
            {
                // Key contains value used to determine the groups
                Console.WriteLine(genderGroup.Key + " " + genderGroup.Count() + ": ");
                foreach(Person p in genderGroup)
                {
                    Console.WriteLine(p.FirstName + " " + p.LastName);
                }
            }
        }
    }
}

