using FightingArena;
using NUnit.Framework;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void Setup()
        {
            arena = new Arena();
        }

        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            Assert.IsNotNull(arena);
        }

        [Test]
        public void TestIfEnrollWorksCorrectly()
        {
            var warrior = new Warrior("Pesho", 25, 100);

            arena.Enroll(warrior);

            Assert.That(arena.Warriors, Has.Member(warrior));
        }

        [Test]
        public void TestEnrollingExistingWarrior()
        {
            var warrior = new Warrior("Pesho", 25, 100);

            arena.Enroll(warrior);

            Assert.That(() => arena.Enroll(warrior), Throws.InvalidOperationException.With.Message.EqualTo("Warrior is already enrolled for the fights!"));
        }

        [Test]
        public void TestIfCountWorksCorrectly()
        {
            var expectedArenaCount = 1;

            var warrior = new Warrior("Pesho", 25, 100);
            arena.Enroll(warrior);

            Assert.AreEqual(expectedArenaCount, arena.Count);
        }

        [Test]
        public void TestIfEnrollIncreasesCount()
        {
            var expectedArenaCount = 2;

            var warrior = new Warrior("Pesho", 25, 100);
            var warrior2 = new Warrior("Peesho", 25, 100);
            arena.Enroll(warrior);
            arena.Enroll(warrior2);

            Assert.AreEqual(expectedArenaCount, arena.Count);
        }

        [Test]
        public void TestIfFightWorksCorrectly()
        {
            var expectedAttHp = 75;
            var expectedDefHp = 45;
            var attacker = new Warrior("Pesho", 55, 100);
            var defender = new Warrior("Gosho", 25, 100);
            arena.Enroll(attacker);
            arena.Enroll(defender);

            arena.Fight(attacker.Name, defender.Name);

            Assert.AreEqual(expectedAttHp, attacker.HP);
            Assert.AreEqual(expectedDefHp, defender.HP);
        }

        [Test]
        public void TestFightingMissingWarrior()
        {
            var attacker = new Warrior("Pesho", 55, 100);
            var defender = new Warrior("Gosho", 25, 100);
            var missingName = defender.Name;
            arena.Enroll(attacker);

            Assert.That(() => arena.Fight(attacker.Name, missingName), Throws.InvalidOperationException.With.Message.EqualTo($"There is no fighter with name {missingName} enrolled for the fights!"));
            
        }
    }
}
