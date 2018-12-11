using DatabaseClass;
using NUnit.Framework;
using System;
using System.Linq;

namespace Db.Tests
{
    [TestFixture]
    public class DatabaseTests
    {
        private Database db;

        [Test]
        public void CheckTheCapacityOfTheArray()
        {
            db = new Database();
            int expectedResult = 16;
            int actualResult = db.Storage.Length;

            Assert.AreEqual(expectedResult, actualResult, "The max capacity of the array should be 16.");
        }

        [Test]
        public void CheckTheElementsCountWithEmptyConstructor()
        {
            db = new Database();
            int expectedResult = 0;
            int actualResult = db.Elements;

            Assert.AreEqual(expectedResult, actualResult, "There are 0 elements, when initialize the db with empty contrustor");
        }

        [Test]
        public void CheckTheElementsCountWithNonEmptyConstructor()
        {
            db = new Database(new int[] {
                0, 1, 2, 3, 4, 5, 6, 7
            });

            int expectedResult = 8;
            int actualResult = db.Elements;

            Assert.AreEqual(expectedResult, actualResult, "There are 8 elements, when initializing the db with a contrustor with 8 elements");
        }

        [Test]
        public void CheckTheElementsWithNonEmptyConstructor()
        {
            db = new Database(new int[] {
                0, 1, 2, 3, 4, 5, 6, 7, 8
            });

            string expectedResult = "0 1 2 3 4 5 6 7 8";
            string actualResult = String.Join(" ", db.Storage.Take(db.Elements).ToArray());

            Assert.AreEqual(expectedResult, actualResult, "There are 0 elements, when initialize the db with empty contrustor");
        }

        [Test]
        public void TestIfThrowAnErrorWhenThereAreMoreThan16ElementsInConstructor()
        {
            Assert.That(() =>
            {
                db = new Database(new int[] {
                0, 1, 2, 3, 4, 5, 6, 7, 8,
                -9, -10, -11, -12, -13, -14, 15, 16
            });
            }, Throws.InvalidOperationException.With.Message.EqualTo("Init array will exceed the max capacity of the array!"));
        }

        [Test]
        public void CheckIfItFetchesAllAddedElements()
        {
            db = new Database(new int[] {
                0, 1, 2, 3, 4, 5, 6, 7, 8, 9
            });

            db.Remove();

            var actualList = this.db.Fetch();

            string expectedResult = "0 1 2 3 4 5 6 7 8";
            string actualResult = String.Join(" ", actualList);
            
            int expectedCount = 9;
            int actualCount = actualList.Length;

            Assert.AreEqual(expectedCount, actualCount, "The count of the fetched elements from the collection is not correct!");
            Assert.AreEqual(expectedResult, actualResult, "The result from fetching does not contain the correct data!");
        }
    }
}