using Chainblock.Models;
using NUnit.Framework;
using System;

namespace Chainblock.Tests
{
    [TestFixture]
    public class TransactionTests
    {
        private const int id = 1;
        private const TransactionStatus ts = TransactionStatus.Successfull;
        private const string from = "Pesho";
        private const string to = "Gosho";
        private const double amount = 650;

        private Transaction transaction;

        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            transaction = new Transaction(id, ts, from, to, amount);

            Assert.AreEqual(id, transaction.Id);
            Assert.AreEqual(ts, transaction.Status);
            Assert.AreEqual(from, transaction.From);
            Assert.AreEqual(to, transaction.To);
            Assert.AreEqual(amount, transaction.Amount);
        }

        [Test]
        public void TestWithLikeNegativeId()
        {
            var negativeId = -5;

            Assert.Throws<ArgumentException>(() => new Transaction(negativeId, ts, from, to, amount));
        }

        [Test]
        public void TestWithLikeWhiteSpaceFrom()
        {
            var whiteSpaceFrom = "          ";

            Assert.Throws<ArgumentException>(() => new Transaction(id, ts, whiteSpaceFrom, to, amount));
        }

        [Test]
        public void TestWithLikeWhiteSpaceTo()
        {
            var whiteSpaceTo = "          ";

            Assert.Throws<ArgumentException>(() => new Transaction(id, ts, from, whiteSpaceTo, amount));
        }

        [Test]
        public void TestWithLikeZeroAmount()
        {
            var zeroAmount = 0.0;

            Assert.Throws<ArgumentException>(() => new Transaction(id, ts, from, to, zeroAmount));
        }

        [Test]
        public void TestWithLikeNegativeAmount()
        {
            var negativeAmount = -5.0;

            Assert.Throws<ArgumentException>(() => new Transaction(id, ts, from, to, negativeAmount));
        }
    }
}
