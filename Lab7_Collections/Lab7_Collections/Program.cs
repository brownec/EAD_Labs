// Cliff Browne - X00014810
// EAD Lab7 - Collections
using System;
using System.Collections;
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

    // 2.	Implement a class which represents a student class   
    public class StudentClass : IEnumerable
    {
        /* A class contains a CRN (class reference number) which is unique, the name of the lecturer 
     * for the class. Use auto-implemented fields for the CRN and lecturer name. */
        public String CRN { get; set; }
        public String Lecturer { get; set; }

        // a collection of students in the class (STRONGLY TYPED)
        private List<Student> students;

        // Implement a constructor which sets the CRN and lecturer name and creates an empty collection
        public StudentClass(String crn, String lecturer)
        {
            this.CRN = crn;
            this.Lecturer = lecturer;

            // Use an ArrayList for the collection of students in the class
            students = new List<Student>();
        }

        /* Add a method to the class which adds a new student. 
        * It should throw an exception if an attempt is made to add a student to the class if a 
        * student with the same ID already exists in the class. */
        public void AddStudent(Student student)
        {
            if(students == null) // check to see if students are empty
            {
                students.Add(student); // adds the first student to the class/list/array
            }
            else
            {
                // LINQ query to check that the sudent id is unique
                if((students.Count(s => s.ID == student.ID)) ==1)
                {
                    throw new ArgumentException("Error: Student " + student.StudentName + " is already in the system.");
                }
                else
                {
                    students.Add(student);
                }
            }
        }

        /* Add 2 indexers to the class, the first allows a student at a specific index position (integer) 
          to be returned e.g. student 0, 1, 2 etc. 
          In both cases throw exceptions if there are problems e.g. the index specified is out of 
          range or if no matching student with the specified ID can be found.*/
        public Student this[int i]
        {
            get
            {
                // Validate the index values
                if((i >= 0) && (i < students.Count))
                {
                    return students[i];
                }
                else
                {
                    throw new ArgumentException("Error: The student index is out of range.");
                }
            }
        }

        // The second allows the collection to be indexed based on the student ID
        public Student this[String id]
        {
            get
            {
                // Find the matching student
                Student student = null;
                // LINQ query to find matching student
                int count = students.Count(s => s.ID == id);
                if(count == 1)
                {
                    student = students.Where(s => s.ID == id).First(); // selects the first student in the array
                    return student;
                }
                else
                {
                    throw new ArgumentException("Student not found!");
                }
            }
        }
        // Iterate over the Student Collection - foreach is now possible on StudentClass
        public IEnumerator GetEnumerator()
        {
            foreach (Student student in students)
            {
                yield return student; // Iterator
            }
        }
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
            Console.WriteLine("**********EAD Lab7 - Collections**********");
        }
    }
}
