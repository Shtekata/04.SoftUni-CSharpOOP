using Database;
using NUnit.Framework;
using System;

namespace Tests
{
    public class DatabaseTests
    {
        private readonly int[] data = new int[] { 1, 2 };
        private Database.Database database;

        [SetUp]
        public void Setup()
        {
            database = new Database.Database(data);
        }

        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            var expectedCount = 2;

            Assert.AreEqual(expectedCount, database.Count, "Count");
        }
        [Test]
        public void TestAddingCorrectly()
        {
            var expectedCount = 3;

            database.Add(3);

            Assert.AreEqual(expectedCount, database.Count);
        }
        [Test]
        public void TestAddingWhenFull()
        {
            for (int i = 3; i <= 16; i++)
            {
                database.Add(i);
            }

            Assert.Throws<InvalidOperationException>(() => database.Add(17),"NoNo","hjk"); 
        }
        [Test]
        public void TestRemovingCorrectly()
        {
            var expectedCount = 1;

            database.Remove();

            Assert.AreEqual(expectedCount, database.Count);
        }
        [Test]
        public void TestRemovingWhenIsEmpty()
        {
            for (int i = 2 - 1; i >= 0; i--)
            {
                database.Remove();
            }

            Assert.Throws<InvalidOperationException>(() => database.Remove(), "Do");
        }
        [Test]
        public void FetchWorksCorrectly()
        {
            var output = database.Fetch();

            CollectionAssert.AreEqual(data, output);
        }
    }
}