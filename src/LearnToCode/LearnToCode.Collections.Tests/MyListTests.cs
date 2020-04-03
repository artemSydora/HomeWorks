using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LearnToCode.Collections.Tests
{
    public class MyListTests
    {
        // Arrange
        // Act
        // Assert

        [Test]
        public void Add_ShouldAddItem()
        {
            // Arrange
            var list = new MyList<object>();
            var expected = new object();

            // Act
            list.Add(expected);
            var actual = list[0];

            // Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(1, list.Count);
        }

        [Test]
        public void Indexer_ShouldRetrieveItem()
        {
            // Arrange
            var list = new MyList<object>();
            var expected = new object();

            // Act
            list.Add(expected);
            var actual = list[0];

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Indexer_ShouldSetItem()
        {
            // Arrange
            var list = new MyList<object>();
            var expected = new object();

            // Act
            list.Add(new object());
            list[0] = expected;
            var actual = list[0];

            // Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(1, list.Count);
        }

        [Test]
        public void Indexer_GetShouldThrowIndexOutOfRangeException()
        {
            // Arrange
            var list = new MyList<object>();

            // Act
            list.Add(new object());

            // Assert
            Assert.Throws<IndexOutOfRangeException>(() => { var result = list[1]; });
        }

        [Test]
        public void Indexer_SetShouldThrowIndexOutOfRangeException()
        {
            // Arrange
            var list = new MyList<object>();

            // Act
            list.Add(new object());

            // Assert
            Assert.Throws<IndexOutOfRangeException>(() => list[1] = new object());
        }

        [Test]
        public void Remove_ShouldRemoveItem()
        {
            // Arrange
            var list = new MyList<object>();
            var obj = new object();

            // Act
            list.Add(obj);
            list.Remove(obj);

            // Assert
            Assert.AreEqual(0, list.Count);
            Assert.Throws<IndexOutOfRangeException>(() => { var result = list[0]; });
        }

        [Test]
        public void Clear_ShouldClearTheList()
        {
            Assert.Fail("Not implemented");
            // Arrange
            // Act
            // Assert
        }

        [Test]
        public void InsertAt_ShouldInsertItemAtIndex()
        {
            Assert.Fail("Not implemented");
            // Arrange
            // Act
            // Assert
        }

        [Test]
        public void ListShouldBeAbleToBeUsedInForEach()
        {
            // Arrange
            var expected = new[] { 0, 1, 2 };
            var list = new MyList<int>();
            list.Add(0);
            list.Add(1);
            list.Add(2);

            // Act
            var actual = new List<int>();

            // TODO: uncomment when MyList is ready to be used in `foreach`
            //foreach(int item in list)
            //{
            //    actual.Add(item);
            //}

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
