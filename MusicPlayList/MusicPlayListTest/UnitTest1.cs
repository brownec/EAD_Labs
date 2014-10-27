using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicPlayList;

namespace MusicPlayListTest
{
    [TestClass]
    public class MusicPlayListTest1
    {
        // Test that the title is not blank
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod1()
        {
            MusicFile track1 = new MusicFile("t1.mp3", "", "Moby", MusicGenre.Electronic);
        }

        // Test to ensure Artist field is not blank
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod2()
        {
            MusicFile track1 = new MusicFile("t1.mp3", "Go", "", MusicGenre.Electronic);
        }

        // Test to ensure that the Artist field is not NULL
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod3()
        {
            MusicFile track1 = new MusicFile("t1.mp3", "Go", null);
        }

        // Construct objects and test that properties have been set correctly
        [TestMethod]
        public void TestConstructor()
        {
            MusicFile track1 = new MusicFile("t1.mp3", "Go", "Moby", MusicGenre.Electronic);
            MusicFile track2 = new MusicFile("t2.mp3", "Ruby Tuesday", "Rolling Stones", MusicGenre.Rock);
            Assert.AreEqual(track1.Title, "Go");
            Assert.AreEqual(track1.Artist, "Moby");
            Assert.AreEqual(track1.Genre, MusicGenre.Electronic);
            Assert.AreEqual(track1.Genre, MusicGenre.Other);
        }

        // Test to ensure objects can be ADDED to a playlist
        [TestMethod]
        public void TestAdd()
        {
            MusicFile track1 = new MusicFile("t1.mp3", "Go", "Moby", MusicGenre.Electronic);
            MusicFile.track2 = new MusicFile("t2.mp3", "Ruby Tuesday", "Rolling Stones", MusicGenre.Rock);

            Playlist playlist = new Playlist("Various Artists");
            playlist.AddTrack(track1);
            playlist.AddTrack(track2);

            CollectionAssert.Contains(playlist.Tracks, track1);
            CollectionAssert.Contains(playlist.Tracks, track2);
        }

        // Test that a DUPLICATE track cannot be added, based on Artist and Title
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAdd2()
        {
            MusicFile track1 = new MusicFile("t1.mp3", "Go", "Moby", MusicGenre.Electronic);
            Playlist playlist = new Playlist("Various Artists");
            playlist.AddTrack(track1);
            playlist.AddTrack(new MusicFile("t1.mp3", "Go", "Moby", MusicGenre.Electronic));
        }

        // Test READ-ONLY INDEXER
        [TestMethod]
        public void TestIndexer()
        {
            MusicFile track1 = new MusicFile("t1.mp3", "Go", "Moby", MusicGenre.Electronic);
            MusicFile track2 = new MusicFile("t2.mp3", "Ruby Tuesday", "Rolling Stones", MusicGenre.Rock);
            MusicFile track3 = new MusicFile("t3.mp3", "Vlad The Impaler", "Kasabian", MusicGenre.Rock);

            Playlist playlist = new Playlist("Various Artists");
            playlist.AddTrack(track1);
            playlist.AddTrack(track2);
            playlist.AddTrack(track3);

            // Make a new list of Rock tracks added
            List<MusicFile> rockTracks = new List<MusicFile>();
            rockTracks.Add(track2);
            rockTracks.Add(track3);

            // Make a list of Rock tracks as determined by the INDEXER
            List<MusicFile> playlistRockTracks = new List<MusicFile>();
            foreach(MusicFile t in playlist[MusicGenre.Rock])
            {
                playlistRockTracks.Add(t);
            }

            // Check that both lists contain the same tracks
            CollectionAssert.AreEqual(rockTracks, playlistRockTracks);
        }

        public MusicFile track2 { get; set; }
    }
}
