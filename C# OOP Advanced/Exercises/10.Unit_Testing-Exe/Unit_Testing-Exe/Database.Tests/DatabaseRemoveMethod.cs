using DatabaseClass;
using NUnit.Framework;
using System;
using System.Linq;

namespace Db.Tests
{
    [TestFixture]
    public class DatabaseRemoveMethod
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
        public void RemoveAnElementWhenThereAreElements_RemovedElement()
        {
            int removed = db.Remove();

            int expectedResult = -14;
            int actualResult = removed;

            Assert.AreEqual(expectedResult, actualResult, "Remove() does not remove the correct element!");
        }

        [Test]
        public void RemoveAnElementWhenThereAreElements_Array()
        {
            db.Remove();
            db.Remove();
            
            string expectedResult = String.Join(" ", db.Storage.Take(db.Elements).ToArray());
            string actualResult = "0 1 2 3 4 5 6 7 8 -9 -10 -11 -12";

            Assert.AreEqual(expectedResult, actualResult, "Remove() does not remove the correct elements!");
        }

        [Test]
        public void RemoveAnElementFromEmptyArray()
        {
            Assert.That(() =>
            {
                this.db = new Database();
                db.Remove();
            }, Throws.InvalidOperationException.With.Message.EqualTo("Cannot remove an element from empty collection!"));
        }
    }
}