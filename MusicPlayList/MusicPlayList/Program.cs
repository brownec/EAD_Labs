// Cliff Browne - X00014810
// EAD1 - CA1 Example - Music Play List
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayList
{
    // PART ONE
            //  1.	Design and develop a MediaFile class to represent a generic media file:
    /* d.	MediaFile should serve as a base class for more specific subclasses *****ABSTRACT****
    (e.g. music file, video file, photo file etc), and it itself should not be able to be instantiated.*/
    public abstract class MediaFile
    {
        // a.	Add a read/write property for the filename for the media file, validate the filename, it must not be blank.
        private String filename;
        public String Filename
        {
            // READ property
            get
            {
                return filename;
            }
            // WRITE property
            set
            {
                // Ensure that the filename is specified i.e. It cannot be blank
                if (String.IsNullOrEmpty(value))
                {
                    // Exception thrown if the fiename is blank or null
                    throw new ArgumentException("Error: Filename cannot be blank!");
                }
                // otherwise return the name of the filename
                else
                {
                    filename = value;
                }
            }
        }

        // b.	Add a CONSTRUCTOR which initialises the filename to a value specified as a parameter to the constructor.
        protected MediaFile(String filename)
        {
            Filename = filename;
        }

        /* c.	OVERRIDE ToSTRING() to return an appropriately formatted string containing full information about the media file. 
        Format the string appropriately. */
        public override string ToString()
        {
            return "Filename: " + filename;
        }
    }
        

    // PART TWO
            // 2.	Design and develop a MusicFile class to represent a music file/track:
            // a.	A music file is a special type of media file
            // b.	In addition to the inherited filename property a music file has 3 additional properties:
                // i.	The title of the music track 
                // ii.	The artist performing the track
                // iii.	The genre of the track i.e. pop, rock, dance, hip hop, wrap, or other. */
            // Add read-only properties to the class for these 3 items, choose or define appropriate data types while doing so.
            /* c.	Add a constructor which initialises all 3 properties to values specified as parameters to the constructor, 
                    make sure that the title and artist are not blank. */
            /* d.	Add another constructor which initialises just the title and artist to values specified as parameters to the constructor 
                    and sets the genre to “other”, as above validate title and artist. */
            // e.	Override ToString to return an appropriately formatted string containing full information about the music file.

    // PART THREE
            /* 3.	Design and develop a Playlist class to represent a playlist of music files i.e. a list of tracks which is named:
            a.	Implement an auto-implemented for the playlist name in the class
            b.	Add a field to the class to store the collection of music files which comprises the playlist, 
                 * and add matching read-only property for this field.
            c.	Implement a constructor for the class which takes 1 parameter corresponding to the playlist name, 
                 * sets the corresponding field, and creates a new empty collection of music files.
            d.	Implement a method to add a music track to the playlist’s collection of music files, throw an exception 
                 * if there is an attempt made to add a track to the playlist where the playlist already contains a track 
                 * with the same title and artist.
            e.	Playlist should be an enumerated type, i.e. a user of the class should be able to iterate over the music files in the 
                 * playlist using a foreach loop.
            f.	Add a read-only indexer to the class which allows the collection of music files in a playlist for a specified 
                 * genre to be retrieved e.g. the collection of dance or pop tracks for example, 
                 * the genre being specified as a paramter to the indexer. */

    // --------------------TEST CLASS--------------------
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*****EAD1 - Music Play List Example CA1*****")
        }
    }
}
