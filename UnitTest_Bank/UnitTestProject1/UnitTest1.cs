using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTest_Bank;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        // Test the Deposit Method
        [TestMethod]
        public void TestMethod1()
        {
            BankAccount bank1 = new BankAccount("99-10-10", "cb123456");
            bank1.makeDeposit(100.00);
            bank1.makeDeposit(200.00);
            Assert.AreEqual(bank1.Balance, 300.00);
        }

        // Test Exception thrown if invalid overdraft amount
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateBankAccountWithInvalidOverdraft()
        {
            // -1000 overdraft limit/overdraft cannot be a negative amount
            BankAccount bank2 = new BankAccount("99-20-96", "cb987654", -1000)
        }

        // Test for Deposit and Withdrawl
        [TestMethod]
        public void TestDepAndWD()
        {
            BankAccount bank3 = new BankAccount("99-11-00", "cb000000", 1000)
            bank3.makeDeposit(100.00);
            bank3.makeWithdrawl(90.00);
            Assert.AreEqual(bank3.Balance, 10.00);
        }

        // Test TransactionHistory contains the number of actual Transactions
        [TestMethod]
        public void TestTransactionHistory()
        {
            BankAccount bank4 = new BankAccount("99-00-10", "cb456789");
            bank4.makeDeposit(500.00);
            bank4.makeDeposit(500.00);
            bank4.makeWithdrawl(600.00);
            Assert.AreEqual(bank4.Balance, 400.00);
            // Test the number of transactions on the account
            CollectionAssert.AreEqual(bank4.TransactionHistory, new List<double>()
            {
                500.00, 500.00, -600
            });
        }
    }
}
