// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to your project (entities/controllers/etc)
namespace FestivalManager.Tests
{
    using FestivalManager.Core.Controllers;
    using FestivalManager.Entities;
    using FestivalManager.Entities.Sets;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class SetControllerTests
    {
        [Test]
        public void Test()
        {
            var stage = new Stage();
            var setController = new SetController(stage);

            var set = new Short("TestSet");
            var set2 = new Short("TestSet2");

            stage.AddSet(set);
            stage.AddSet(set2);

            // SignUpPerformer Gosho 21 Guitar Microphone
            // SignUpPerformer Pesho 23 Drums
            // SignUpPerformer Ivan 20 Microphone
            var performer = new Performer("Gosho", 21);
            var performer2 = new Performer("Pesho", 23);
            var performer3 = new Performer("Ivan", 20);
            var performer4 = new Performer("Ivancho", 20);


            //RegisterSong SongName 03:00
            //RegisterSong SongName2 02:00
            //RegisterSong SongName4 00:01
            var song = new Song("SongName", new TimeSpan(0, 3, 0));
            var song2 = new Song("SongName2", new TimeSpan(0, 2, 0));
            var song3 = new Song("SongName3", new TimeSpan(0, 10, 0));
            var song4 = new Song("SongName4", new TimeSpan(0, 0, 1));

            set.AddPerformer(performer);
            set.AddPerformer(performer2);
            set.AddPerformer(performer3);
            set.AddPerformer(performer4);
            //AddSongToSet SongName TestSet
            //AddSongToSet SongName2 TestSet
            //AddSongToSet SongName3 TestSet
            //AddSongToSet SongName4 TestSet
            set.AddSong(song);
            set2.AddSong(song2);
            set.AddSong(song3);
            set.AddSong(song4);
            
            stage.AddPerformer(performer);


            var expected = "1. TestSet: -- Did not perform 2. TestSet2: -- Did not perform";
            var actual = setController.PerformSets();

            Assert.AreEqual(expected, actual);

        }
    }
}