using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace CustomLinkedList.Tests
{
    [TestFixture]
    public class LinkedListTests
    {
        private DynamicList<int> list;

        [SetUp]
        public void SetUp()
        {
            this.list = new DynamicList<int>();
        }

        [Test]
        public void TestIfThereAreAllNeededPublicMembers()
        {
            var listType = this.list.GetType();

            bool hasCounter = listType.GetMember("Count").Length > 0;
            bool hasAddMethod = listType.GetMethod("Add") != null;
            bool hasRemoveAtMethod = listType.GetMethod("RemoveAt") != null;
            bool hasRemoveMethod = listType.GetMethod("Remove") != null;
            bool hasIndexOfMethod = listType.GetMethod("IndexOf") != null;
            bool hasContainsMethod = listType.GetMethod("Contains") != null;

            Assert.IsTrue(hasCounter, "Missing public property Count");
            Assert.IsTrue(hasAddMethod, "Missing public method Add");
            Assert.IsTrue(hasRemoveAtMethod, "Missing public method RemoveAt");
            Assert.IsTrue(hasRemoveMethod, "Missing public method Remove");
            Assert.IsTrue(hasIndexOfMethod, "Missing public method IndexOf");
            Assert.IsTrue(hasContainsMethod, "Missing public method Contains");
        }

        [Test]
        public void TestIfCountReturnsCorrectResult()
        {
            AddValuesToList();

            int expected = 3;
            int actual = this.list.Count;

            Assert.AreEqual(expected, actual, "Count property does not return a correct result!");
        }

        [Test]
        public void TestListInit()
        {
            int expected = 0;
            int actual = this.list.Count;

            Assert.AreEqual(expected, actual, "After init, the list should be empty!");
        }

        [Test]
        public void TestAddMethod()
        {
            AddValuesToList();

            var tempList = GetTempList();

            string expected = "75 -89 0";
            string actual = String.Join(" ", tempList);

            Assert.AreEqual(expected, actual, "Add() does not add properly the given values!");
        }

        [Test]
        public void TestRemoveAtMethodWithNonEmptyList()
        {
            AddValuesToList();

            this.list.RemoveAt(1);

            var tempList = GetTempList();

            string expected = "75 0";
            string actual = String.Join(" ", tempList);

            Assert.AreEqual(expected, actual, "RemoveAt() does not add properly the given values!");
        }

        [Test]
        public void TestRemoveAtMethodWithEmptyList()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => {
                this.list.RemoveAt(1);
            }, "Invalid index: 1");
        }

        [Test]
        public void TestRemoveMethodWithEmptyList()
        {
            int expectedIndex = -1;
            int actualIndex = this.list.Remove(5);

            var tempList = GetTempList();

            string expected = "";
            string actual = String.Join(" ", tempList);

            Assert.AreEqual(expectedIndex, actualIndex, "Remove() does not return -1");
            Assert.AreEqual(expected, actual, "Remove() should not remove any element!");
        }

        [Test]
        public void TestRemoveMethodWithPresentElement()
        {
            AddValuesToList();

            int expectedIndex = 1;
            int actualIndex = this.list.Remove(-89);

            var tempList = GetTempList();

            string expected = "75 0";
            string actual = String.Join(" ", tempList);

            Assert.AreEqual(expectedIndex, actualIndex, "Remove() does not return the correct index of the removed element");
            Assert.AreEqual(expected, actual, "Remove() does not remove properly the given value!");
        }
        
        [Test]
        public void TestRemoveMethodWithNonPresentElement()
        {
            AddValuesToList();

            int expectedIndex = -1;
            int actualIndex = this.list.Remove(89);

            var tempList = GetTempList();

            string expected = "75 -89 0";
            string actual = String.Join(" ", tempList);

            Assert.AreEqual(expectedIndex, actualIndex, "Remove() does not return -1");
            Assert.AreEqual(expected, actual, "Remove() should not remove any element!");
        }
        

        [Test]
        public void TestIfIndexOfFindsAnElement()
        {
            AddValuesToList();

            int expected = 2;
            int actual = this.list.IndexOf(0);

            Assert.AreEqual(expected, actual, "IndexOf() does not return a correct index!");
        }


        [Test]
        public void TestIfIndexOfFindsAnNonPresentElement()
        {
            AddValuesToList();

            int expected = -1;
            int actual = this.list.IndexOf(12);

            Assert.AreEqual(expected, actual, "IndexOf() found an element which is not present!");
        }

        [Test]
        public void TestIfContainsMethodFindsAPresentElement()
        {
            AddValuesToList();

            bool actual = this.list.Contains(75);

            Assert.IsTrue(actual, "Contains() cannot found an element which not present!");
        }

        [Test]
        public void TestIfContainsMethodFindsANonPresentElement()
        {
            AddValuesToList();

            bool actual = this.list.Contains(5);

            Assert.IsFalse(actual, "Contains() found an element which is not present!");
        }

        private List<int> GetTempList()
        {
            var tempList = new List<int>();

            for (int index = 0; index < this.list.Count; index++)
            {
                tempList.Add(this.list[index]);
            }

            return tempList;
        }

        private void AddValuesToList()
        {
            this.list.Add(75);
            this.list.Add(-89);
            this.list.Add(0);
        }
    }
}
