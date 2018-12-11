using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExtendedDatabase.Tests
{
    [TestFixture]
    public class ExtendedDbTest
    {
        private ExtendedDb db;

        [SetUp]
        public void SetUp()
        {
            db = new ExtendedDb();
        }

        [Test]
        public void CheckTheCapacityOfTheArray()
        {
            int expectedResult = 16;
            int actualResult = db.Storage.Length;

            Assert.AreEqual(expectedResult, actualResult, "The max capacity of the array should be 16.");
        }

        [Test]
        public void CheckTheElementsCountWithEmptyConstructor()
        {
            int expectedResult = 0;
            int actualResult = db.Elements;

            Assert.AreEqual(expectedResult, actualResult, "There are 0 elements, when initialize the db with empty contrustor");
        }

        [Test]
        public void CheckIfItFetchesAllAddedElements()
        {
            db.Add(new Person(15, "Pesho"));
            db.Add(new Person(4556, "Gosho"));
            db.Add(new Person(23, "Sharo"));

            db.Remove();

            var expectedList = new List<string>();
            expectedList.Add("15 - Pesho");
            expectedList.Add("4556 - Gosho");

            var actualList = this.db.Fetch().Select(x => String.Format("{0} - {1}", x.Id, x.Username)).ToList();

            string expectedResult = String.Join("\n", expectedList);
            string actualResult = String.Join("\n", actualList);

            int expectedCount = 2;
            int actualCount = actualList.Count;
            
            Assert.AreEqual(expectedCount, actualCount, "The count of the fetched elements from the collection is not correct!");
            Assert.AreEqual(expectedResult, actualResult, "The result from fetching does not contain the correct data!");
        }

        [Test]
        public void AddNewCorrectPersonToDb()
        {
            db.Add(new Person(15, "Pesho"));
            db.Add(new Person(4556, "Gosho"));

            var expectedList = new List<string>();
            expectedList.Add("15 - Pesho");
            expectedList.Add("4556 - Gosho");
            var actualList = GetPeople();

            string expectedResult = String.Join("\n", expectedList);
            string actualResult = String.Join("\n", actualList);

            Assert.AreEqual(expectedResult, actualResult, "Wrong result is returned when adding a new element!");
        }

        
        [Test]
        public void AddElementWhenTheMaxCapacityIsExceeded()
        {
            Assert.That(() =>
            {
                for(int i = 1; i <= 17; i++)
                {
                    db.Add(new Person(i, "Pesho" + i));
                }
            }, Throws.InvalidOperationException.With.Message.EqualTo("You exceeded the max capacity of the array"));
        }

        [Test]
        public void AddTwoPeopleWithSameIds()
        {
            Assert.That(() =>
            {
                db.Add(new Person(12, "Pesho"));
                db.Add(new Person(12, "Gosho"));
            }, Throws.InvalidOperationException.With.Message.EqualTo("Duplicate Ids"));
        }

        [Test]
        public void AddTwoPeopleWithSameUsernames()
        {
            Assert.That(() =>
            {
                db.Add(new Person(15, "Pesho"));
                db.Add(new Person(12, "Pesho"));
            }, Throws.InvalidOperationException.With.Message.EqualTo("Duplicate Usernames"));
        }

        [Test]
        public void RemoveAnElementFromEmptyArray()
        {
            Assert.That(() =>
            {
                db.Remove();
            }, Throws.InvalidOperationException.With.Message.EqualTo("Cannot remove an element from empty collection!"));
        }

        [Test]
        public void RemoveAnElementWhenThereAreElements()
        {
            db.Add(new Person(15, "Pesho"));
            db.Add(new Person(4556, "Gosho"));
            db.Add(new Person(23, "Sharo"));

            db.Remove();
            db.Remove();

            var expectedList = new List<string>();
            expectedList.Add("15 - Pesho");
            var actualList = GetPeople();

            string expectedResult = String.Join("\n", expectedList);
            string actualResult = String.Join("\n", actualList);
            
            Assert.AreEqual(expectedResult, actualResult, "Wrong result returned after removing some elements!");
        }

        [Test]
        public void TestIfSearchingForUserWithPresentingId()
        {
            db.Add(new Person(15, "Pesho"));
            db.Add(new Person(4556, "Gosho"));

            Person personFound = db.FindById(4556);

            string expectedResult = "4556 - Gosho";
            string actualResult = String.Format("{0} - {1}", personFound.Id, personFound.Username);

            Assert.AreEqual(expectedResult, actualResult, "Wrong result returned after finding by id!");
        }

        [Test]
        public void TestIfSearchingForUserWithNotAPresentingId()
        {
            db.Add(new Person(15, "Pesho"));
            db.Add(new Person(4556, "Gosho"));

            Assert.That(() =>
            {
                Person personFound = db.FindById(453);
            }, Throws.InvalidOperationException.With.Message.EqualTo("No user with this id is present!"));
        }

        [Test]
        public void TestIfSearchingByNegativeId()
        {
            db.Add(new Person(15, "Pesho"));
            db.Add(new Person(4556, "Gosho"));

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Person personFound = db.FindById(-453);
            }, "Negative id found!");
        }

        [Test]
        public void TestIfSearchingByNullUsername()
        {
            db.Add(new Person(15, "Pesho"));
            db.Add(new Person(4556, "Gosho"));

            Assert.Throws<ArgumentNullException>(() =>
            {
                Person personFound = db.FindByUsername(null);
            }, "Username should not be null!");
            /*
            Assert.That(() =>
            {
               
            }, Throws.ArgumentNullException.With.Message.EqualTo("Username should not be null!"));*/
        }

        [Test]
        public void TestIfSearchingForUserWithPresentingUsername()
        {
            db.Add(new Person(15, "Pesho"));
            db.Add(new Person(4556, "Gosho"));

            Person personFound = db.FindByUsername("Pesho");

            string expectedResult = "15 - Pesho";
            string actualResult = String.Format("{0} - {1}", personFound.Id, personFound.Username);

            Assert.AreEqual(expectedResult, actualResult, "Wrong result returned after finding by username!");
        }

        [Test]
        public void TestIfSearchingForUserWithNotAPresentingUsername()
        {
            db.Add(new Person(15, "Pesho"));
            db.Add(new Person(4556, "Gosho"));

            Assert.That(() =>
            {
                Person personFound = db.FindByUsername("Sharo");
            }, Throws.InvalidOperationException.With.Message.EqualTo("No user with this username is present!"));
        }

        private List<string> GetPeople()
        {
            var result = new List<string>();

            foreach(var person in this.db.Storage)
            {
                if(person != null)
                {
                    result.Add($"{person.Id} - {person.Username}");
                }
            }

            return result;
        }
    }
}
