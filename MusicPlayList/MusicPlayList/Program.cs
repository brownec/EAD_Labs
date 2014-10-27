// Cliff Browne - X00014810
// EAD1 - CA1 Example - Music Play List
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections;

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
    ////////////////////////////////////////END OF MEDIA FILE CLASS///////////////////////////////////////////////////////////

    //*************************************START OF MUSIC FILE CLASS*********************************************************
    // iii.	The genre of the track i.e. pop, rock, dance, hip hop, wrap, or other.
    public enum MusicGenre
    {
        Electronic, Pop, Rap, Rock, Soul, Other
    }
    // PART TWO
            // 2.	Design and develop a MusicFile class to represent a music file/track:
            // a.	A music file is a special type of media file
    public class MusicFile : MediaFile
    {
        // b.	In addition to the inherited filename property a music file has 3 additional properties:
        // i.	The title of the music track 
        // ii.	The artist performing the track
        private String title;
        private String artist;
        private MusicGenre genre;

        // Add read-only properties to the class for these 3 items, choose or define appropriate data types while doing so.
        public String Title
        {
            get
            {
                return title;
            }
        }

        public String Artist
        {
            get
            {
                return artist;
            }
        }

        public MusicGenre Genre
        {
            get
            {
                return genre;
            }
        }

        /* c.	Add a constructor which initialises all 3 properties to values specified as parameters to the constructor, 
                make sure that the title and artist are not blank. */
        public MusicFile(String filename, String title, String artist, MusicGenre genre)
            : base(filename)
        {
            // check to ensure that the title field is not NULL or EMPTY
            if(String.IsNullOrEmpty(title))
            {
                // exception thrown if title field is found to be NULL or EMPTY 
                throw new ArgumentException("Title field cannot be blank!");
            }
                // check to ensure that the artist field is not NULL or EMPTY
            else if(String.IsNullOrEmpty(artist))
            {
                // exception thrown if the artist field is found to be NULL or EMPTY
                throw new ArgumentException("Artist field cannot be blank!");
            }
            // set the fields
            this.title = title;
            this.artist = artist;
            this.genre = genre;
        }

        /* d.	Add another constructor which initialises just the title and artist to values specified as parameters to the constructor 
                and sets the genre to “other”, as above validate title and artist. */
        public MusicFile(String filename, String title, String artist)
            : this(filename, title, artist, MusicGenre.Other)
        {
            // Chained
        }

        // e.	Override ToString to return an appropriately formatted string containing full information about the music file.
        public override string ToString()
        {
            return base.ToString() + "Title: " + Title + " Artist: " + Artist + " Genre: " + Genre.ToString();
        }
    }
    ////////////////////////////////////////END OF MUSIC FILE CLASS///////////////////////////////////////////////////////////

    //*************************************START OF PLAYLIST CLASS*********************************************************       

    // PART THREE
            // 3.	Design and develop a Playlist class to represent a playlist of music files i.e. a list of tracks which is named:
                public class Playlist : IEnumerable
                {
                    // a.	Implement an auto-implemented for the playlist name in the class
                    public String Name { get; set; }
                    /* b.	Add a field to the class to store the collection of music files which comprises the playlist, 
                          * and add matching read-only property for this field. */
                    List<MusicFile> tracks;
         
                    // READ property for tracks
                    public Collection<MusicFile> Tracks
                    {
                        get
                        {
                            return new Collection<MusicFile>(tracks);
                        }
                    }

                    /*  c.	Implement a constructor for the class which takes 1 parameter corresponding to the playlist name, 
                          * sets the corresponding field, and creates a new empty collection of music files. */
                    public Playlist(String name)
                    {
                        this.Name = name;
                        // creates an empty collection of music files
                        tracks = new List<MusicFile>();
                    }

                    /*   d.	Implement a method to add a music track to the playlist’s collection of music files, throw an exception 
                          * if there is an attempt made to add a track to the playlist where the playlist already contains a track 
                          * with the same title and artist. */
                    public void AddTrack(MusicFile track)
                    {
                        // check to see if the playlist is empty
                        if(tracks == null)
                        {
                            // adds the track to the playlist
                            tracks.Add(track);
                        }
                        else
                        {
                            // search playlist for duplicate track and throw exception if duplicate track found
                            bool duplicate = false;
                            foreach(MusicFile t in tracks)
                            {
                                // search where title and artist match track in playlist
                                if((track.Title == t.Title) && (track.Artist == t.Artist))
                                {
                                    duplicate = true;
                                    break; // exit search, duplicate found
                                }
                            }
                            if(duplicate)
                            {
                                throw new ArgumentException("Error: Track " + track.Title + " by " + track.Artist + " is already in the playlist.");
                            }
                            else
                            {
                                // IF NO DUPLICATE found, add the track to the playlist
                                tracks.Add(track); 
                            }
                        }
                    }

                    /*   e.	Playlist should be an enumerated type, i.e. a user of the class should be able to iterate over the music files in the 
                          * playlist using a foreach loop. */
                    public IEnumerator GetEnumerator()
                    {
                        foreach(MusicFile m in tracks)
                        {
                            yield return m;
                        }
                    }

                    /*  f.	Add a read-only indexer to the class which allows the collection of music files in a playlist for a specified 
                          * genre to be retrieved e.g. the collection of dance or pop tracks for example, 
                          * the genre being specified as a parameter to the indexer. */
                    public IEnumerable<MusicFile> this[MusicGenre genre]
                    {
                        get
                        {
                            // LINQ query selecting from the entire Music File
                            var tracksForGenre = tracks.Where(t => t.Genre == genre);
                            return tracksForGenre;
                        }
                    }
                }
            
        

    // --------------------TEST CLASS--------------------
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*****EAD1 - Music Play List Example CA1*****");
        }
    }
}
