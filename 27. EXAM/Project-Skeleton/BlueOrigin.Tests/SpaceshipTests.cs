namespace BlueOrigin.Tests
{
    using System;
    using NUnit.Framework;

    public class SpaceshipTests
    {
        [Test]
       public void SpaceshipContructorName()
        {
            var spaceship = new Spaceship("A", 5);

            var expName = "A";

            Assert.AreEqual(expName, spaceship.Name);
        }
        [Test]
        public void SpaceshipConstructorCapacity()
        {
            var spaceship = new Spaceship("A", 5);

            var expCapacity = 5;

            Assert.AreEqual(expCapacity, spaceship.Capacity);
        }
        [Test]
        public void SpaceshipConstructorAustronauts()
        {
            var spaceship = new Spaceship("A", 5);

            var expectedCount = 0;

            Assert.AreEqual(expectedCount, spaceship.Count);
        }
        [Test]
        public void SpaceshipConstructorAustronautsCount()
        {
            var spaceship = new Spaceship("A", 5);
            var astronautGosho = new Astronaut("Gosho", 57.3);
            spaceship.Add(astronautGosho);

            var expectedCount = 1;

            Assert.AreEqual(expectedCount, spaceship.Count);
        }
        [Test]
        public void SpaceshipConstructorInvalidName()
        {
            Assert.That(() => new Spaceship("", 5), Throws.ArgumentNullException);
        }
        [Test]
        public void SpaceshipConstructorInvalidName2()
        {
            Assert.That(() => new Spaceship(null, 5), Throws.ArgumentNullException);
        }
        [Test]
        public void SpaceshipConstructorInvalidCapacity()
        {
            Assert.That(() => new Spaceship("Pesho", -3), Throws.ArgumentException);
        }
        [Test]
        public void SpaceshipInvalidFullCapacity()
        {
            var spaceship = new Spaceship("A", 2);
            var astronautGosho = new Astronaut("Gosho", 57.3);
            var astronautMosho = new Astronaut("Mosho", 57.3);
            var astronautSosho = new Astronaut("Sosho", 57.3);


            spaceship.Add(astronautGosho);
            spaceship.Add(astronautMosho);



            Assert.That(() => spaceship.Add(astronautSosho), Throws.InvalidOperationException);
        }
        [Test]
        public void SpaceshipExistingAustronaut()
        {
            var spaceship = new Spaceship("A", 2);
            var astronautGosho = new Astronaut("Gosho", 57.3);

            spaceship.Add(astronautGosho);

            Assert.That(() => spaceship.Add(astronautGosho), Throws.InvalidOperationException);
        }
        [Test]
        public void SpaceshipRemoveAustronaut()
        {
            var spaceship = new Spaceship("A", 2);
            var astronautGosho = new Astronaut("Gosho", 57.3);

            spaceship.Add(astronautGosho);
            var expResult = spaceship.Remove(astronautGosho.Name);

            Assert.IsTrue(expResult);
        }
        [Test]
        public void SpaceshipRemoveNonExistingAustronaut()
        {
            var spaceship = new Spaceship("A", 2);
            var astronautGosho = new Astronaut("Gosho", 57.3);
            var astronautSosho = new Astronaut("Sosho", 57.3);

            spaceship.Add(astronautGosho);
            var expResult = spaceship.Remove(astronautSosho.Name);

            Assert.IsFalse(expResult);
        }
    }
}