using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        private const int MIN_ATTACK_HP = 30;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            var expectedName = "Pesho";
            var expectedDmg = 15;
            var expectedHp = 100;

            Warrior warrior = new Warrior("Pesho", 15, 100);

            Assert.AreEqual(expectedName, warrior.Name);
            Assert.AreEqual(expectedDmg, warrior.Damage);
            Assert.AreEqual(expectedHp, warrior.HP);
        }

        [Test]
        public void TestWithLikeEmptyName()
        {
            Assert.That(() => new Warrior(null, 15, 100), Throws.ArgumentException.With.Message.EqualTo("Name should not be empty or whitespace!"));
        }

        [Test]
        public void TestWithLikeWhiteSpaceName()
        {
            Assert.That(() => new Warrior("      ", 15, 100), Throws.ArgumentException.With.Message.EqualTo("Name should not be empty or whitespace!"));             
        }

        [Test]
        public void TestWithLikeZeroDamage()
        {
            Assert.That(() => new Warrior("Pesho", 0, 100), Throws.ArgumentException.With.Message.EqualTo("Damage value should be positive!"));
        }

        [Test]
        public void TestWithNegativeDamage()
        {
            Assert.That(() => new Warrior("Pesho", -1, 100), Throws.ArgumentException.With.Message.EqualTo("Damage value should be positive!"));
        }

        [Test]
        public void TestWithLikeNegativeHP()
        {
            Assert.That(() => new Warrior("P", 1, -1), Throws.ArgumentException.With.Message.EqualTo("HP should not be negative!"));
        }

        [Test]
        public void TestIfAttackWorksCorrectly()
        {
            var expectedAttHp = 95;
            var expectedDefHp = 80;

            var attacker = new Warrior("Pesho", 10, 100);
            var defender = new Warrior("Gosho", 5, 90);

            attacker.Attack(defender);

            Assert.AreEqual(expectedAttHp, attacker.HP);
            Assert.AreEqual(expectedDefHp, defender.HP);
        }

        [Test]
        public void AttackingWithLowHP()
        {
            var attacker = new Warrior("Pesho", 10, 20);
            var defender = new Warrior("Gosho", 5, 90);

            Assert.That(() => attacker.Attack(defender), Throws.InvalidOperationException.With.Message.EqualTo("Your HP is too low in order to attack other warriors!"));
        }

        [Test]
        public void TestAttackingEnemyWithLowHP()
        {
            var attacker = new Warrior("Pesho", 10, 50);
            var defender = new Warrior("Gosho", 5, 20);

            Assert.That(() => attacker.Attack(defender), Throws.InvalidOperationException.With.Message.EqualTo($"Enemy HP must be greater than {MIN_ATTACK_HP} in order to attack him!"));
        }

        [Test]
        public void TestAttackingStrongerEnemy()
        {
            var attacker = new Warrior("Pesho", 10, 50);
            var defender = new Warrior("Gosho", 55, 50);

            Assert.That(() => attacker.Attack(defender), Throws.InvalidOperationException.With.Message.EqualTo($"You are trying to attack too strong enemy"));
        }

        [Test]
        public void TestKillingEnemy()
        {
            var expectedAttHP = 15;
            var expectedEnemyHp = 0;

            var attacker = new Warrior("Pesho", 60, 50);
            var defender = new Warrior("Gosho", 35, 50);
            attacker.Attack(defender);

            Assert.AreEqual(expectedAttHP, attacker.HP);
            Assert.AreEqual(expectedEnemyHp, defender.HP);
        }
    }
}