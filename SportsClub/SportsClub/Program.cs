// Cliff Browne - X00014810
// EAD1 - CA1 Example Sports Club Program
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SportsClub
{
    // PART ONE
    // 1.	Design and develop a SportsPlayer class to represent a person who plays sports:
    // 3.	the player’s gender (use an appropriately defined type for gender)
    public enum Gender
    {
        m, f
    }

    /* d.	SportsPlayer should serve as a base class for more specific subclasses, and it 
            itself should not be able to be instantiated. */
    public abstract class SportsPlayer
    {
        // a.	Add appropriate read/write auto-implemented properties for the following:
        // 1.	the player’s name
        public String Name { get; set; }
        // 2.	the player’s age
        public int Age { get; set; }
        // 3.	the player’s gender (use an appropriately defined type for gender)
        public Gender Gender { get; set; }

        /* b.	Add a constructor which initialises all 3 properties to values specified as 
         *      parameters to the constructor. */
        public SportsPlayer(String name, int age, Gender gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        /* c.	Override ToString to return an appropriately formatted string containing full 
         *      information about the player. Format the string appropriately. */
        public override string ToString()
        {
            return "Player Name: " + Name + "Age: " + Age + "Gender: " + Gender;
        }
    }

// PART TWO
        // 2.	Design and develop a SoccerPlayer class to represent a soccer player:
        // a.	A soccer player is a special type of sports player
            
        // Collection of positions that a Soccer Player plays
    public enum SoccerPosition
    {
        Gk, D, M, S
    }

    public class SoccerPlayer : SportsPlayer
    {
        /* b.	In addition to inherited properties (i.e. name, age, and gender) a soccer player 
         *      has one additional property - the position on the soccer field the player plays. 
         *      This player can play in one of the following positions only - goalkeeper, defender, midfielder, or striker. 
         *      Use a read/write auto-implemented property and an appropriately defined type for this property. */
        public SoccerPosition Position { get; set; }

        /* c.	Add a constructor which initialises all 4 properties to values specified as 
         *      parameters to the constructor. */
        public SoccerPlayer(String name, int age, Gender gender, SoccerPosition position)
            : base(name, age, gender)
        {
            this.Position = position;
        }

        /* d.	Add a default constructor, by default a sports player’s name is blank, their age is 0, their gender is 
         *      male, and their position is defender. */
        public SoccerPlayer()
            : this("", 0, Gender.m, SoccerPosition.D)
        {

        }

        // custom equality comparison for .Equals, used by Contains() on List<>
        public override bool Equals(Object obj)
        {
            SoccerPlayer player = obj as SoccerPlayer;

            if (player == null)
            {
                return false;
            }

            // must match all 4 attributes to be equal
            if ((player.Name == this.Name) && (player.Age == this.Age) && (player.Gender == this.Gender) && (player.Position == this.Position))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // needed if overriding Equals
        public override int GetHashCode()
        {
            // return a hash (key) value for this object
            return Name.GetHashCode() + Age.GetHashCode() + Gender.GetHashCode() + Position.GetHashCode();
        }

        /* e.	Override ToString to return an appropriately formatted string containing full information about the soccer player. 
                Format the string appropriately. */
        public override string ToString()
        {
            return base.ToString() + "Position: " + Position;
        }
    }
        

// PART THREE
        // 3.	Design and develop a SoccerTeam class to represent a soccer team:
    public class SoccerTeam : IEnumerable
    {
        // a.	A soccer team contains:
        /* iii.	The age limit for players on the team e.g. for a junior team the age limit might be 12. 
         *      Use a special value to indicate no upper age limit e.g. for senior teams. 
         *      Also the minimum age limit for any team is 5. */
        public const int MinAge = 5; // minimum age limit for a team
        public const int NoAgeLimit = Int32.MaxValue; // a team with no minimum age limit (SENTINEL VALUE)
        private int ageLimit;

        // i.	The team name
        public String TeamName { get; set; }
        // ii.	The gender of the team (i.e. no mixed gender teams are allowed)
        public Gender TeamGender { get; set; }

        // iv.	A collection of soccer players for the team
        private List<SoccerPlayer> players;


        /* b.	Implement auto-implemented or standard read/write properties for all the above members as you see fit, 
         *      the age limit for the team should be validated when set. */
        // READ ONLY property for Collectiion of Players
        public Collection<SoccerPlayer> Players
        {
            get
            {
                return new Collection<SoccerPlayer>(players);
            }
        }

        // READ/WRITE property for the ageLimit of a team
        public int AgeLimit
        {
            get
            {
                return ageLimit;
            }
            set
            {
                if(value >= MinAge)
                {
                    this.ageLimit = value;
                }
                else
                {
                    throw new ArgumentException("Error: Age Limit for a Team must be greater than: " + MinAge);
                }
            }
        }

        /* c.	Implement a constructor for the class which takes 3 parameters corresponding to the first 3 items above, 
         *      and initialises these items and also creates a new empty collection of players. */
        public SoccerTeam(String teamName, Gender teamGender, int ageLimit)
        {
            this.TeamName = teamName;
            this.TeamGender = teamGender;
            this.AgeLimit = ageLimit;

            // CREATE A NEW EMPTY COLLECTION OF SOCCER PLAYERS
            this.players = new List<SoccerPlayer>();
        }

        /* d.	SoccerTeam should be an enumerated type, i.e. a user of the class should be able to iterate over the soccer 
         *      players in the soccer team using a foreach loop. */
        public IEnumerator GetEnumerator()
        {
            foreach(SoccerPlayer player in players)
            {
                yield return player;
            }
        }
        
        /* e.	Add an indexer property which allows the a SoccerTeam to be read (not written) using array type indexing, 
         *      where the index specified is a player name, and if a player with that name exists in the team 
         *      (matching should be case insensitive) return that player, otherwise throw an exception. */
        public SoccerPlayer this[String playerName]
        {
            get
            {
                SoccerPlayer player = null;
                Boolean found = false; // if player name is found

                for(int i = 0; i < players.Count; i++)
                {
                    // ignores case
                    if(String.Compare(players[i].Name, playerName, StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        found = true;
                        player = players[i];
                    }
                }
                if(found)
                {
                    return player;
                }
                else
                {
                    throw new ArgumentException("Error: Player: " + playerName + " is not in the team " + TeamName);
                }
            }
        }


        // f.	Implement a method to add a player to the soccer team’s collection of players, validate the input.
        public void AddPlayer(SoccerPlayer player)
        {
            if(players == null) // no players
            {
                players.Add(player);
            }
            else
            {
                if(players.Contains(player)) // already in team, Contains uses Equals for SoccerPlayer to test
                {
                    throw new ArgumentException("Error! Player: " + player.Name + " is already in the team.");
                }
                else
                {
                    // Add the new Player
                    if(player.Gender == TeamGender)
                    {
                        if(player.Age <= AgeLimit)
                        {
                            players.Add(player);
                        }
                        else
                        {
                            // exception if player too old
                            throw new ArgumentException("Error! Player: " + player.Name + " is too old for team: " + TeamName);
                        }
                    }
                    else
                    {
                        throw new ArgumentException("Error! Player: " + player.Name + " is " + player.Gender + " but team is " + TeamGender + " only.");
                    }
                }
            }
        }
    }
        
    // ------------------TEST CLASS------------------
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("*****EAD1 - Sports Club Program*****");
        }
    }
}