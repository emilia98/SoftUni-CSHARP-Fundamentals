using DatabaseClass;
using NUnit.Framework;
using System;

namespace Db.Tests
{
    [TestFixture]
    public class DatabaseAddMethod
    {
        private Database db;

        [SetUp]
        public void SetUp()
        {
            db = new Database(new int[] {
                0, 1, 2, 3, 4, 5, 6, 7, 8,
                -9, -10, -11, -12, -13, -14
            });
        }

        [Test]
        public void AddIntegerWhenThereAreFreeCells()
        {
            db.Add(18);

            string expectedResult = String.Join(" ", db.Storage);
            string actualResult = "0 1 2 3 4 5 6 7 8 -9 -10 -11 -12 -13 -14 18";

            Assert.AreEqual(expectedResult, actualResult, "Wrong result is returned when adding a new element!");
        }
        
        [Test]
        public void AddElementWhenTheMaxCapacityIsExceeded()
        {
            Assert.That(() =>
            {
                db.Add(18);
                db.Add(-18);
            }, Throws.InvalidOperationException.With.Message.EqualTo("You exceeded the max capacity of the array"));
        }
    }
}