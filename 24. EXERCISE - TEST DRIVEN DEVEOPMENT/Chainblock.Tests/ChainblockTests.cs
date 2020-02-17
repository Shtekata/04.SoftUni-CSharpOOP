using NUnit.Framework;

namespace Chainblock.Tests
{
    using Chainblock.Contracts;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class ChainblockTests
    {
        private const int id = 1;
        private const TransactionStatus ts = TransactionStatus.Successfull;
        private const string from = "Pesho";
        private const string to = "Gosho";
        private const double amount = 650;

        private Chainblock chainblock;
        private Transaction transaction;

        [SetUp]
        public void SetUp()
        {
            chainblock = new Chainblock();
            transaction = new Transaction(id, ts, from, to, amount);
            chainblock.Add(transaction);
        }

        [Test]
        public void TestIfAddWorksCorrectly()
        {
            var expectedCount = 1;

            Assert.AreEqual(expectedCount, chainblock.Count);
        }

        [Test]
        public void TestAddingSameTransactionTwice()
        {
            Assert.Throws<InvalidOperationException>(() => chainblock.Add(transaction));
        }

        [Test]

        public void TestIfContainsByTransactionWorksCorrectly()
        {
            var actualResult = chainblock.Contains(transaction);

            Assert.IsTrue(actualResult);
        }

        [Test]
        public void TestContainsNonExistantTransaction()
        {
            var nonExistantTr = new Transaction(10, TransactionStatus.Unauthorized, from, to, amount);

            var result = chainblock.Contains(nonExistantTr);

            Assert.IsFalse(result);
        }

        [Test]
        public void TestContainsById()
        {
            var result = chainblock.Contains(id);

            Assert.IsTrue(result);
        }

        [Test]
        public void TestContainsNonExistantId()
        {
            var result = chainblock.Contains(5);

            Assert.IsFalse(result);
        }

        [Test]
        public void TestContainsWithNegativeId()
        {
            Assert.Throws<InvalidOperationException>(() => chainblock.Contains(-5));
        }

        [Test]
        public void TestIfCountWorksCorrectly()
        {
            var expectedCount = 2;

            var newTr = new Transaction(2, TransactionStatus.Failed, from, to, amount);

            chainblock.Add(newTr);

            Assert.AreEqual(expectedCount, chainblock.Count);
        }

        [Test]
        public void TestIfGetByIdWorksCorrectly()
        {
            var result = chainblock.GetById(id);

            Assert.AreSame(transaction, result);
            Assert.AreEqual(transaction.Id, result.Id);
        }

        [Test]
        public void TestGettingNonExistantTransaction()
        {
            Assert.Throws<InvalidOperationException>(() => chainblock.GetById(5));
        }
        
        [Test]
        public void TestIfChangeTransactionStatusWorksCorrectly()
        {
            var newStatus = TransactionStatus.Aborted;

            chainblock.ChangeTransactionStatus(id, newStatus);

            var result = chainblock.GetById(id);

            Assert.AreEqual(newStatus, result.Status);
        }

        [Test]
        public void TestChangingStatusOnNonExistingTransaction()
        {
            Assert.Throws<ArgumentException>(() => chainblock.ChangeTransactionStatus(5, ts));
        }

        [Test]
        public void TestRemovingByIdCorrectly()
        {
            var expectedCount = 0;

            chainblock.RemoveTransactionById(id);

            Assert.AreEqual(expectedCount, chainblock.Count);
        }

        [Test]
        public void TestRemovingNonExistingId()
        {
            Assert.Throws<InvalidOperationException>(() => chainblock.RemoveTransactionById(5));
        }

        [Test]
        public void TestIfGetByStatusReturnAllWithIntendedStatus()
        {
            chainblock.Add(new Transaction(2, ts, from, to, amount + 10));
            chainblock.Add(new Transaction(3, ts, from, to, amount + 20));
            chainblock.Add(new Transaction(4, TransactionStatus.Aborted, from, to, amount + 30));

            var resultCollection = chainblock.GetByTransactionStatus(ts);

            var result = resultCollection.All(x => x.Status == ts);

            Assert.IsTrue(result);
        }

        [Test]
        public void TestIfGetByStatusReturnsCollectionWithCorrectCount()
        {
            var expectedCount = 3;

            chainblock.Add(new Transaction(2, ts, from, to, amount + 10));
            chainblock.Add(new Transaction(3, ts, from, to, amount + 20));
            chainblock.Add(new Transaction(4, TransactionStatus.Aborted, from, to, amount + 30));

            var resultCollection = chainblock.GetByTransactionStatus(ts);

            var actualCount = resultCollection.Count();

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void TestIfGetByStatusReturnedCollectionContainsOnlyOurTransactions()
        {
            var resultCollection = chainblock.GetByTransactionStatus(ts);

            var result = resultCollection.First();

            Assert.AreSame(transaction, result);
        }

        [Test]
        public void TestIfGetByStatusReturnsTransactionsOrderedCorrectly()
        {
            chainblock.Add(new Transaction(2, ts, from, to, amount + 10));
            chainblock.Add(new Transaction(3, ts, from, to, amount + 20));
            chainblock.Add(new Transaction(4, TransactionStatus.Aborted, from, to, amount + 30));

            var resultCollection = chainblock
                .GetByTransactionStatus(ts)
                .ToList();

            var areOrdered = true;
            var currentMax = resultCollection.First().Amount;

            for (int i = 0; i < resultCollection.Count(); i++)
            {
                var currentTransaction = resultCollection[i];

                if (currentTransaction.Amount > currentMax)
                {
                    areOrdered = false;
                    break;
                }

                currentMax = currentTransaction.Amount;
            }

            Assert.IsTrue(areOrdered);
        }

        [Test]
        public void TestGetByNonExistingStatus()
        {
            Assert.Throws<InvalidOperationException>(() => chainblock.GetByTransactionStatus(TransactionStatus.Aborted));
        }

        [Test]
        public void TestIfGetAllSendersWithTransactionStatusReturnsCorrectCount()
        {
            var expectedCount = 3;

            chainblock.Add(new Transaction(2, ts, from, to, amount + 10));
            chainblock.Add(new Transaction(3, ts, from, to, amount + 20));
            chainblock.Add(new Transaction(4, TransactionStatus.Aborted, from, to, amount + 30));


            var result = chainblock.GetAllSendersWithTransactionStatus(ts);

            Assert.AreEqual(expectedCount, result.Count());
        }

        [Test]
        public void TestIfGetAllSendersWithTransactionStatusReturnsCorrectCollection()
        {
            chainblock.Add(new Transaction(2, ts, from, to, amount + 10));
            chainblock.Add(new Transaction(3, ts, from, to, amount + 20));
            chainblock.Add(new Transaction(4, TransactionStatus.Aborted, from, to, amount + 30));

            var expectedCollection = chainblock
                .GetByTransactionStatus(ts)
                .Select(x => x.From)
                .ToArray();

            var actualCollection = chainblock.GetAllSendersWithTransactionStatus(ts);

            CollectionAssert.AreEqual(expectedCollection, actualCollection);
        }

        [Test]
        public void TestGettingAllSendersWithNonExistingTransactionStatus()
        {
            Assert.Throws<InvalidOperationException>(() => chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Unauthorized));
        }

        [Test]
        public void TestIfGetAllReceiversWithTransactionStatusReturnsCollectionWithCorrectCount()
        {
            var expectedCount = 3;

            chainblock.Add(new Transaction(2, ts, from, to, amount + 10));
            chainblock.Add(new Transaction(3, ts, from, to, amount + 20));
            chainblock.Add(new Transaction(4, TransactionStatus.Aborted, from, to, amount + 30));


            var result = chainblock.GetAllReceiversWithTransactionStatus(ts);

            Assert.AreEqual(expectedCount, result.Count());
        }

        [Test]
        public void TestIfGetAllReceiversWithTransactionStatusReturnsCorrectCollection()
        {
            chainblock.Add(new Transaction(2, ts, from, to, amount + 10));
            chainblock.Add(new Transaction(3, ts, from, to, amount + 20));
            chainblock.Add(new Transaction(4, TransactionStatus.Aborted, from, to, amount + 30));

            var expectedCollection = chainblock
                .GetByTransactionStatus(ts)
                .Select(x => x.To)
                .ToArray();

            var actualCollection = chainblock.GetAllReceiversWithTransactionStatus(ts);

            CollectionAssert.AreEqual(expectedCollection, actualCollection);
        }

        [Test]
        public void TestGettingAllReceiversWithNonExistingTransactionStatus()
        {
            Assert.Throws<InvalidOperationException>(() => chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Unauthorized));
        }

        [Test]
        public void TestIfGetAllOrderedByAmountDescendingThanByIdReturnsOrderedCollection()
        {
            chainblock.Add(new Transaction(2, ts, from, to, amount + 10));
            chainblock.Add(new Transaction(3, ts, from, to, amount + 10));
            chainblock.Add(new Transaction(4, TransactionStatus.Aborted, from, to, amount + 30));

            var resultCollection = chainblock
                .GetAllOrderedByAmountDescendingThenById()
                .ToList();

            var areOrdered = true;
            var currentMax = resultCollection.First().Amount;
            var currentId = resultCollection.First().Id;

            for (int i = 0; i < resultCollection.Count(); i++)
            {
                var currentTransaction = resultCollection[i];

                if (currentTransaction.Amount > currentMax)
                {
                    areOrdered = false;
                    break;
                }
                else if (currentTransaction.Amount == currentMax)
                {
                    if (currentTransaction.Id < currentId)
                    {
                        areOrdered = false;
                        break;
                    }
                }

                currentMax = currentTransaction.Amount;
                currentId = currentTransaction.Id;
            }

            Assert.IsTrue(areOrdered);
        }

        [Test]
        public void TestIfGetBySenderOrderedByAmountDescendingReturnsCorrectCount()
        {
            var expectedCount = 3;

            chainblock.Add(new Transaction(2, ts, from, to, amount + 10));
            chainblock.Add(new Transaction(3, ts, from, to, amount + 20));
            chainblock.Add(new Transaction(4, ts, "Vanko", to, amount + 30));

            var resultCollection = chainblock.GetBySenderOrderedByAmountDescending(from);

            Assert.AreEqual(expectedCount, resultCollection.Count());
        }

        [Test]
        public void TestIfGetBySenderOrderedByAmountDescendingReturnsCollectionWithCorrectSenderNames()
        {
            chainblock.Add(new Transaction(2, ts, from, to, amount + 10));
            chainblock.Add(new Transaction(3, ts, from, to, amount + 20));
            chainblock.Add(new Transaction(4, ts, "Vanko", to, amount + 30));

            var resultCollection = chainblock.GetBySenderOrderedByAmountDescending(from);

            var result = resultCollection.All(x => x.From == from);

            Assert.IsTrue(result);
        }

        [Test]
        public void TestIfGetBySenderOrderedByAmountDescendingReturnsOrderedCollection()
        {
            var tr1 = new Transaction(2, ts, from, to, amount + 10);
            var tr2 = new Transaction(3, ts, from, to, amount + 20);

            chainblock.Add(tr1);
            chainblock.Add(tr2);
            chainblock.Add(new Transaction(4, ts, "Vanko", to, amount + 30));

            var expectedResult = new List<ITransaction>() { tr2, tr1, transaction };

            var resultCollection = chainblock
                .GetBySenderOrderedByAmountDescending(from)
                .ToList();

            CollectionAssert.AreEqual(expectedResult, resultCollection);
        }

        [Test]
        public void TestGetBySenderOrderedByAmountDescendingWithNonExistingSender()
        {
            chainblock.Add(new Transaction(2, ts, from, to, amount + 10));
            chainblock.Add(new Transaction(3, ts, from, to, amount + 20));

            Assert.Throws<InvalidOperationException>(() => chainblock.GetBySenderOrderedByAmountDescending("Vanko"));
        }

        [Test]
        public void TestIfGetByReceiverOrderedByAmountDescendingReturnsCorrectCount()
        {
            var expectedCount = 3;

            chainblock.Add(new Transaction(2, ts, from, to, amount + 10));
            chainblock.Add(new Transaction(3, ts, from, to, amount + 20));
            chainblock.Add(new Transaction(4, ts, from, "Vanko", amount + 30));

            var resultCollection = chainblock.GetByReceiverOrderedByAmountThenById(to);

            Assert.AreEqual(expectedCount, resultCollection.Count());
        }

        [Test]
        public void TestIfGetByReceiverOrderedByAmountDescendingReturnsCollectionWithCorrectReceiverNames()
        {
            chainblock.Add(new Transaction(2, ts, from, to, amount + 10));
            chainblock.Add(new Transaction(3, ts, from, to, amount + 20));
            chainblock.Add(new Transaction(4, ts, from, "Vanko", amount + 30));

            var resultCollection = chainblock.GetByReceiverOrderedByAmountThenById(to);

            var result = resultCollection.All(x => x.To == to);

            Assert.IsTrue(result);
        }

        [Test]
        public void TestIfGetByReceiverOrderedByAmountDescendingReturnsOrderedCollection()
        {
            var tr1 = new Transaction(2, ts, from, to, amount);
            var tr2 = new Transaction(3, ts, from, to, amount + 20);

            chainblock.Add(tr1);
            chainblock.Add(tr2);
            chainblock.Add(new Transaction(4, ts, from, "Vanko", amount + 30));

            var expectedResult = new List<ITransaction>() { tr2, transaction, tr1 };

            var resultCollection = chainblock
                .GetByReceiverOrderedByAmountThenById(to)
                .ToList();

            CollectionAssert.AreEqual(expectedResult, resultCollection);
        }

        [Test]
        public void TestGetByReceiverOrderedByAmountDescendingWithNonExistingReceiver()
        {
            chainblock.Add(new Transaction(2, ts, from, to, amount + 10));
            chainblock.Add(new Transaction(3, ts, from, to, amount + 20));

            Assert.Throws<InvalidOperationException>(() => chainblock.GetByReceiverOrderedByAmountThenById("Vanko"));
        }

        [Test]
        public void TestIfGetByTransactionStatusAndMaximumAmountReturnsCorrectTransactions()
        {
            var maxAmount = amount + 20;

            chainblock.Add(new Transaction(2, ts, from, to, amount + 10));
            chainblock.Add(new Transaction(3, ts, from, to, amount + 20));
            chainblock.Add(new Transaction(4, TransactionStatus.Unauthorized, from, to, amount));
            chainblock.Add(new Transaction(5, ts, from, to, amount + 30));

            var resultCollection = chainblock.GetByTransactionStatusAndMaximumAmount(ts, maxAmount);

            var resilt = resultCollection.All(x => x.Status == ts && x.Amount <= maxAmount);

            Assert.IsTrue(resilt);
        }

        [Test]
        public void TestIfGetByTransactionStatusAndMaximumAmountReturnsOrderedCollection()
        {
            var maxAmount = amount + 20;

            var tr1 = new Transaction(2, ts, from, to, amount + 10);
            var tr2 = new Transaction(3, ts, from, to, amount + 20);
            var tr3 = new Transaction(4, TransactionStatus.Unauthorized, from, to, amount);
            var tr4 = new Transaction(5, ts, from, to, amount + 30);

            var expectedResult = new List<ITransaction>() { tr2, tr1, transaction };

            chainblock.Add(tr1);
            chainblock.Add(tr2);
            chainblock.Add(tr3);
            chainblock.Add(tr4);

            var actualResult = chainblock
                .GetByTransactionStatusAndMaximumAmount(ts, maxAmount)
                .ToList();

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void TestGetByTransactionStatusAndMaximumAmountWhenIsNoTransactionsCorrespondToTransactionStatus()
        {
            var result = chainblock.GetByTransactionStatusAndMaximumAmount(TransactionStatus.Unauthorized, amount + 10);

            CollectionAssert.IsEmpty(result);
        }

        [Test]
        public void TestGetByTransactionStatusAndMaximumAmountWhenIsNoTransactionsCorrespondToMaxAmount()
        {
            var result = chainblock.GetByTransactionStatusAndMaximumAmount(ts, amount - 10);

            CollectionAssert.IsEmpty(result);
        }

        [Test]
        public void TestGetBySenderAndMinimumAmountDescendingReturnsIntendedTransactions()
        {
            var minAmount = amount - 10;

            var tr1 = new Transaction(2, ts, from, to, amount + 10);
            var tr2 = new Transaction(3, ts, from, to, amount + 20);
            var tr3 = new Transaction(4, ts, "Vanko", to, amount);
            var tr4 = new Transaction(5, ts, from, to, amount - 30);

            chainblock.Add(tr1);
            chainblock.Add(tr2);
            chainblock.Add(tr3);
            chainblock.Add(tr4);

            var resultCollection = chainblock
                .GetBySenderAndMinimumAmountDescending(from, minAmount);

            var result = resultCollection.All(x => x.From == from && x.Amount > minAmount);

            Assert.IsTrue(result);
        }

        [Test]
        public void TestIfGetBySenderAndMinimumAmountDescendingReturnsOrderedCollection()
        {
            var minAmount = amount - 10;

            var tr1 = new Transaction(2, ts, from, to, amount + 10);
            var tr2 = new Transaction(3, ts, from, to, amount + 20);
            var tr3 = new Transaction(4, ts, "Vanko", to, amount);
            var tr4 = new Transaction(5, ts, from, to, amount - 30);

            var expectedResult = new List<ITransaction>() { tr2, tr1, transaction };

            chainblock.Add(tr1);
            chainblock.Add(tr2);
            chainblock.Add(tr3);
            chainblock.Add(tr4);

            var actualResult = chainblock
                .GetBySenderAndMinimumAmountDescending(from, minAmount)
                .ToList();

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void TestGetBySenderAndMinimumAmountDescendingWithLikeNonExistingSender()
        {
            Assert.Throws<InvalidOperationException>(() => chainblock.GetBySenderAndMinimumAmountDescending("Vanko0", amount - 10));
        }

        [Test]
        public void TestGetBySenderAndMinimumAmountDescendingWithLikeInvalidAmount()
        {
            Assert.Throws<InvalidOperationException>(() => chainblock.GetBySenderAndMinimumAmountDescending(from, amount + 10));
        }

        [Test]
        public void TestGetAllInAmountRangeWorksCorrectly()
        {
            var minAmount = amount + 5;
            var maxAmount = amount + 25;

            chainblock.Add(new Transaction(2, ts, from, to, amount + 10));
            chainblock.Add(new Transaction(3, ts, from, to, amount + 20));

            var resultCollection = chainblock.GetAllInAmountRange(minAmount, maxAmount);

            var result = resultCollection.All(x => x.Amount >= minAmount && x.Amount <= maxAmount);

            Assert.AreEqual(2, resultCollection.Count());
            Assert.IsTrue(result);
        }

        [Test]
        public void TestGetAllInAmountRangeWhenThereIsNotTransactionsCorrespondingToGivenRange()
        {
            var minAmount = amount + 35;
            var maxAmount = amount + 55;

            chainblock.Add(new Transaction(2, ts, from, to, amount + 10));
            chainblock.Add(new Transaction(3, ts, from, to, amount + 20));

            var resultCollection = chainblock.GetAllInAmountRange(minAmount, maxAmount);

            Assert.IsEmpty(resultCollection);
        }
    }
}
