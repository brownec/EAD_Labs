// Cliff Browne - X00014810
// EAD1 - Worksheet8_ToDo List
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo
{
    // 1.	Implement a ToDoNote class which represents a to-do note. The class should contain the following members:
            /* Fields – the subject matter of the note; the due-date (DateTime); and the priority. 
            Implement an appropriate type to represent the various priorities. */ 

            // Constructor – one constructor which sets all three fields to values passed in as parameters
            // Property – read/write properties for each of the three fields
            /* Override the inherited ToString method and return a readable string containing full information about the note. 
            The due date should be displayed as a date without its time portion. */


    /* 2.	Implement a SerialisedXML interface. 
     * This interface should contain just one method which takes a filename as an input parameter. 
     * Classes which implement this interface have to provide an implementation of this method 
     * i.e. they should provide an implementation of a method to write their contents to an XML file.

    /* The ToDoNote class should implement this interface and therefore should provide a method which writes 
     * out the contents of a note in XML format to a specified file name passed in as a parameter. 
     * This can be easily achieved using the XMLTextWriter class. 
     * Check out the SDK documentation for sample code on how to do this. */


    /* 3.	Implement a ToDoList class which represents a to-do-list. 
            A to-do-list contains to-do items. 
            This class should contain the following members: */

           /* Fields - the owner of the list; the collection of to-do notes in the list. 
            The collection should be a dynamically sized collection e.g. an ArrayList*/

           /* Constructor – one constructor which sets the name of the owner of the list, 
             and initialises the collection of to-do notes to empty */

           // Property – a read/write property for the owner field

           /* Indexer – an indexer which allows the notes in the to-do list to be read (not written) 
              using array type indexing 
              i.e. an object which is an instance of the ToDoList can be iterated over like an array. */

          //  Add – a method which allows a note to be added to the list (at the next available position)

    
    // ************************************************************
    // *************************Test Class*************************
    // ************************************************************
    /* 4.	A test class which creates a to-do-list, creates 2 to-do items, adds them to the list, 
     * displays the items in the list, and writes the first item to an XML file “todo.xml” */
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("*****EAD1 Worksheet 8 - ToDo List Program*****");
        }
    }
}
