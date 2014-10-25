// Cliff Browne - X00014810
// EAD Lab7 - Collections
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7_Collections
{
    public enum Gender
    {
        m, f
    }

    // 1.	Implement a class which represents a student. 
     public class Student
    {
        // * A student has a unique ID, a name, and a gender
        public String ID { get; set; }
        public String StudentName { get; set; }
        public Gender Gend { get; set; }

        // * Add appropriate constructors and properties to the class
        public Student (String id, String name, Gender sex)
        {
            this.ID = id;
            this.StudentName = name;
            this.Gend = sex;
        }
        
         // Override the ToString() method
        public override string ToString()
        {
            return "ID: " + ID + "Student Name: " + StudentName + "Gender: " + Gend;
        }
    }

    /* 2.	Implement a class which represents a student class. 
     * A class contains a CRN (class reference number) which is unique, the name of the lecturer 
     * for the class, and a collection of students in the class. 
     * Use auto-implemented fields for the CRN and lecturer name. 
     * Implement a constructor which sets the CRN and lecturer name and creates an empty collection. 
     * Use an ArrayList for the collection of students in the class.
        1.	Add a method to the class which adds a new student. 
        * It should throw an exception if an attempt is made to add a student to the class if a 
        * student with the same ID already exists in the class.
        2.	Add 2 indexers to the class, the first allows a student at a specific index position (integer) 
        * to be returned e.g. student 0, 1, 2 etc. 
        * The second allows the collection to be indexed based on the student ID. 
        * In both cases throw exceptions if there are problems e.g. the index specified is out of 
        * range or if no matching student with the specified ID can be found. */
    public class StudentClass : IEnumerable
    {

    }


    // Test Class
    /* 3.	Use a test class to create students, a student class, add the students to the class and test the indexers. 
 * It should catch any exceptions that may be thrown.
4.	Modify the solution to use a generic collection i.e. a List<Student> instead of an ArrayList in the student class. 
 */
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("**********EAD Lab7 - Collections**********")
        }
    }
}
