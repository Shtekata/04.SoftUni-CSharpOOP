namespace Telecom.Tests
{
    using NUnit.Framework;
    using System;

    public class Tests
    {
        private const string make = "Samsung";
        private const string model = "S10+";
        private Phone phone;

        [SetUp]
        public void SetUp()
        {
            phone = new Phone(make, model);
        }

        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            Assert.AreEqual(make, phone.Make);
            Assert.AreEqual(model, phone.Model);
        }

        [Test]
        public void TestWithLikeEmptyMake()
        {
            Assert.Throws<ArgumentException>(() => phone = new Phone(string.Empty, model));
        }

        [Test]
        public void TestWithLikeEmptyModel()
        {
            Assert.Throws<ArgumentException>(() => phone = new Phone(make, string.Empty));
        }

        [Test]
        public void InitialCountShouldBeZero()
        {
            var expectedCount = 0;

            Assert.AreEqual(expectedCount, phone.Count);
        }

        [Test]
        public void TestIfAddWorksCorrectly()
        {
            phone.AddContact("Pesho", "0888888888");
            phone.AddContact("Gosho", "0777777777");
            var expectedCount = 2;

            Assert.AreEqual(expectedCount, phone.Count);
        }

        [Test]

        public void TestAddingExistingPerson()
        {
            phone.AddContact("Pesho", "0888888888");

            Assert.Throws<InvalidOperationException>(() => phone.AddContact("Pesho", "0555555555"));
        }

        [Test]
        public void TestIfCallWorksCorrectly()
        {
            var name = "Pesho";
            var number = "0888888888";
            phone.AddContact(name, number);

            var expectedOutput = $"Calling {name} - {number}...";
            var actualOutput = phone.Call(name);

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void TestCallingNonExistingPerson()
        {
            Assert.Throws<InvalidOperationException>(() => phone.Call("Gosho"));
        }
    }
}