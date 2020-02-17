using NUnit.Framework;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddRiderShouldAddSuccessfully()
        {
            var raceEntry = new RaceEntry();
            var unitMotorcycle = new UnitMotorcycle("Kawasaki", 60, 500);
            var unitRider = new UnitRider("Ivan", unitMotorcycle);

            var actualMessage = raceEntry.AddRider(unitRider);

            string expectedMessage= "Rider Ivan added in race.";

            Assert.AreEqual(expectedMessage, actualMessage);
            Assert.AreEqual(1, raceEntry.Counter);
        }

        [Test]
        public void AddRiderShouldThrowInvalidOperationExceptionIfNull()
        {
            var raceEntry = new RaceEntry();
            UnitRider unitRider = null;

            Assert.That(() => raceEntry.AddRider(unitRider), Throws.InvalidOperationException.With.Message.EqualTo("Rider cannot be null."));
            Assert.AreEqual(0, raceEntry.Counter);
        }

        [Test]
        public void AddRiderShouldThrowInvalidOperationExceptionIfRiderAlreadyExist()
        {
            var raceEntry = new RaceEntry();
            var unitMotorcycle = new UnitMotorcycle("Kawasaki", 60, 500);
            var unitRider = new UnitRider("Ivan", unitMotorcycle);

            raceEntry.AddRider(unitRider);

            Assert.That(() => raceEntry.AddRider(unitRider), Throws.InvalidOperationException.With.Message.EqualTo(string.Format("Rider {0} is already added.", unitRider.Name)));
            Assert.AreEqual(1, raceEntry.Counter);
        }

        [Test]
        public void CalculateAverageHorsePowerShouldReturnAverageHorsePowerOfAllRiders()
        {
            var raceEntry = new RaceEntry();

            var unitMotorcycle1 = new UnitMotorcycle("Kawasaki", 60, 500);
            var unitRider1 = new UnitRider("Ivan", unitMotorcycle1);

            var unitMotorcycle2 = new UnitMotorcycle("Honda", 24, 500);
            var unitRider2 = new UnitRider("Peter", unitMotorcycle2);

            var unitMotorcycle3 = new UnitMotorcycle("Yamaha", 78, 500);
            var unitRider3 = new UnitRider("Sam", unitMotorcycle3);

            raceEntry.AddRider(unitRider1);
            raceEntry.AddRider(unitRider2);
            raceEntry.AddRider(unitRider3);

            var result = raceEntry.CalculateAverageHorsePower();
            var expectedResult = 54;

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void CalculateAverageHorsePowerShouldReturnInvalidOperationExceptionWhenOnlyTwoRidersAdded()
        {
            var raceEntry = new RaceEntry();

            var unitMotorcycle1 = new UnitMotorcycle("Kawasaki", 60, 500);
            var unitRider1 = new UnitRider("Ivan", unitMotorcycle1);

            
            raceEntry.AddRider(unitRider1);

            Assert.That(() => raceEntry.CalculateAverageHorsePower(), Throws.InvalidOperationException.With.Message.EqualTo(string.Format("The race cannot start with less than {0} participants.", 2)));
        }
    }
}