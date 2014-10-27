// Cliff Browne - X00014810
// EAD1 - Worksheet8_ToDo List
using System;
using System.Collections;
using System.Xml;
using System.Text;
using System.Collections.Generic;

namespace ToDo
{
    // ------------------------------------------------------------------------------------------
    // -------------------------------------TO-DO-LIST CLASS-------------------------------------
    // ------------------------------------------------------------------------------------------
    public class ToDoList
    {
        // Fields - the owner of the list; the collection of to-do notes in the list. 
        private String owner; // owner of the ToDoList
        // The collection should be a dynamically sized collection e.g. an ArrayList
        private ArrayList notes;

        /* Constructor – one constructor which sets the name of the owner of the list, 
        and initialises the collection of to-do notes to empty */
        public ToDoList(String owner)
        {
            Owner = owner;
            notes = new ArrayList(); // creates a new collection of to-do-notes
        }
        // Property – a read/write property for the owner field
        public String Owner
        {
            get
            {
                return owner;
            }
            set
            {
                owner = value;
            }
        }

        /* Indexer – an indexer which allows the notes in the to-do list to be read (not written) 
        using array type indexing 
        i.e. an object which is an instance of the ToDoList can be iterated over like an array. */
        public ToDoNote this[int i]
        {
            get
            {
                if ((i >= 0) && (i < notes.Count))
                {
                    return (ToDoNote)notes[i];
                }
                else
                {
                    throw new ArgumentException("Invalid Index!");
                }
            }
        }

        //  Add – a method which allows a note to be added to the list (at the next available position)
        public void AddToDoNote(ToDoNote note)
        {
            notes.Add(note);
        }

        // Return the length of the notes collection
        public int Length 
        { 
            get
            {
                return notes.Count;
            }
        }
    }
    ////////////////////////////////TO-DO-LIST END//////////////////////////////////////////////////////////////////

    // ------------------------------------------------------------------------------------------
    // -------------------------------------TO-DO-NOTE CLASS-------------------------------------
    // ------------------------------------------------------------------------------------------
    // Priority for the ToDoNotePriority collection
    public enum ToDoNotePriority
    {
        High, Normal, Low
    }

    // Interface to indicate that an item is serialsed to XML
    public interface SerialiseToXML
    {
        void WriteToXML(String filename);
    }

    // 1.	Implement a ToDoNote class which represents a to-do note. The class should contain the following members:
    /* The ToDoNote class should implement this interface and therefore should provide a method which writes 
     * out the contents of a note in XML format to a specified file name passed in as a parameter. 
     * This can be easily achieved using the XMLTextWriter class. 
     * Check out the SDK documentation for sample code on how to do this. */
    public class ToDoNote : SerialiseToXML
    {
        // Fields – the subject matter of the note; the due-date (DateTime); and the priority. 
        private String subject;
        private DateTime dueDate;
        // Implement an appropriate type to represent the various priorities
        private ToDoNotePriority priority; // priority set for completion

        // Constructor – one constructor which sets all three fields to values passed in as parameters
        public ToDoNote(string subject, DateTime dueDate, ToDoNotePriority priority)
        {
            Subject = subject;
            DueDate = dueDate;
            Priority = priority;
        }

        // Property – read/write properties for each of the three fields
        public String Subject
        {
            get
            {
                return subject;
            }
            set
            {
                subject = value;
            }
        }

        public DateTime DueDate
        {
            get
            {
                return dueDate;
            }
            set
            {
                dueDate = value;
            }
        }

        public ToDoNotePriority Priority
        {
            get
            {
                return priority;
            }
            set
            {
                priority = value;
            }
        }

        /* Override the inherited ToString method and return a readable string containing full information about the note. 
        The due date should be displayed as a date without its time portion. */
        public override string ToString()
        {
            return "Subject: " + Subject + "Due Date: " + DueDate.ToString("d") + "Priority Level: " + Priority.ToString();
        }
        
        /* 2.	Implement a SerialisedXML interface. 
         * This interface should contain just one method which takes a filename as an input parameter. 
         * Classes which implement this interface have to provide an implementation of this method 
         * i.e. they should provide an implementation of a method to write their contents to an XML file. */
        public void WriteToXML(String filename)
        {
            XmlTextWriter tw = new XmlTextWriter(filename, null);
            tw.Formatting = Formatting.Indented;
            tw.WriteStartDocument();
            tw.WriteStartElement("To-Do-Note");
            tw.WriteElementString("Subject", subject);
            tw.WriteElementString("Due-Date", dueDate.ToString("d"));
            tw.WriteElementString("Priority", priority.ToString());
            tw.WriteEndElement();
            tw.WriteEndDocument();

            tw.Flush();
            tw.Close();
        }
    }

    // *************************Test Class*************************
    /* 4.	A test class which creates a to-do-list, creates 2 to-do items, adds them to the list, 
     * displays the items in the list, and writes the first item to an XML file “todo.xml” */
    class Program
    {
        static void Main()
        {
            Console.WriteLine("*****EAD1 Worksheet 8 - ToDo List Program*****");
            // Create a To-Do-List and add in some notes
            ToDoList list = new ToDoList("Cliff");
            list.AddToDoNote(new ToDoNote("NCT due", new DateTime(2014, 10, 28), ToDoNotePriority.High));
            list.AddToDoNote(new ToDoNote("Tax car for 3 months", new DateTime(2014, 12, 12), ToDoNotePriority.Normal));
            list.AddToDoNote(new ToDoNote("Pay Irish Water Bill", new DateTime(2015, 01, 31), ToDoNotePriority.Low));

            // Output Note details to console
            for(int i = 0; i < list.Length; i++)
            {
                Console.WriteLine(list[i]);
            }

            // Output the second note to the an XML file
            list[1].WriteToXML("todo.xml");
        }
    }
}
