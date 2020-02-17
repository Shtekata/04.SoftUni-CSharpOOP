using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTesting.Test
{
    [TestFixture]
    public class BankAccountTest
    {
        private BankAccount bankAccount;
        [SetUp]
        public void CreateBankAccount()
        {
            bankAccount = new BankAccount(100m);
        }
        [TearDown]
        public void destroyBankAccount()
        {
            bankAccount = null;
        }
        [Test]
        public void TestNewBankAccount()
        {
            Assert.That(bankAccount.Balance, Is.EqualTo(100m), "Creating a new Bank Account");
        }
        [Test]
        public void TestNewBankAccountWithNegativeBalance()
        {
            Assert.That(() => new BankAccount(-100m), Throws.ArgumentException.With.Message.EqualTo("Balance can not be negative!"));
        }
        [Test ]
        public void TestDeposit()
        {
            bankAccount.Deposit(100m);

            Assert.That(bankAccount.Balance, Is.EqualTo(200m), "Deposit");
        }
        [Test]
        public void TestDepositWithNegativeSum()
        {
            Assert.That(()=>bankAccount.Deposit(-1000m), Throws.ArgumentException.With.Message.EqualTo("Sum must be positive number!"));
        }
        [Test]
        public void TestWithdraw()
        {
            Assert.That(bankAccount.Withdraw(20m), Is.EqualTo(80m), "Withdraw");
        }
        [Test]
        public void TestWithdrawMoreThanBalance()
        {
            Assert.That(() => bankAccount.Withdraw(500m), Throws.ArgumentException.With.Message.EqualTo("Balance can not be negative!"));
        }
    }
}
