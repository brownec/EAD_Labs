// Cliff Browne - X00014810 
// EAD1 Lab Unit Testing using Bank Account
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestBank
{
    /*  An overdraft limit of greater than zero indicates that an overdraft facility applies to the account. */
    public class BankAccount
    {
        // 1.	Implement a BankAccount class which contains the following fields: sort code, account number, overdraft limit and balance. 
        private string sortCode;
        private string accNumber;
        private double overDraftLimit;
        private double accBalance;

        /* In addition to the fields in 1 above the bank account needs also to keep track of a transaction history 
        * i.e. all the amounts deposited in and withdraw from the account since it was created. 
        * The history just needs to record the amount concerned, a positive value in the history would indicate a deposit, 
        * a negative value in the history would indicate a withdrawal 
        * e.g. 100, -50, 75 would indicate a deposit of  €100 followed by a withdrawal of €50, followed by a deposit of €75. 
        * . */
        private List<double> transactionHistory;
        
        /* 2.	Implement a constructor for the class that takes as parameters the sort code, account number, and overdraft limit. 
         * The opening balance of a new account is zero. */
        public BankAccount(string sortCode, string accNumber, double overDraftLimit)
        {
            if (overDraftLimit >= 0)
            {
                this.sortCode = sortCode;
                this.accNumber = accNumber;
                this.overDraftLimit = overDraftLimit;
                accBalance = 0;
                // Add a field to the back account class to store the transaction history. Use a generic list
                transactionHistory = new List<double>();
            }
            else
            {
                throw new ArgumentException("Overdraft cannot be negative amount!");
            }
        }

        /* 3.	Implement another constructor for the class that takes as parameters just the sort code and account number. 
         * The overdraft limit should be set to zero. As above the opening balance of a new account is zero.*/
        public BankAccount(string sortCode, string accNumber)
            : this(sortCode, accNumber, 0) // overdraft limit set to zero
        {

        }

        // * dd read-only properties to correspond to these fields. 
        public string SortCode
        {
            get
            {
                return sortCode;
            }
        }

        public String AccNo
        {
            get
            {
                return accNumber;
            }
        }

        public double OverDraft
        {
            get
            {
                return overDraftLimit;
            }
        }

        public double AccBal
        {
            get
            {
                return accBalance;
            }
        }

        public List<double> TransHistory
        {
            get
            {
                return transactionHistory;
            }
        }

        /* 4.	Implement a method DEPOSIT which allows a deposit to be made to the account. 
         * The method should take the amount to deposit as a parameter.. */
        public void makeDeposit(double depAmount)
        {
            // 1. Check to ensure deposit amount is greater than zero
            if(depAmount > 0)
            {
                accBalance += depAmount; // accBalance property, adds the deposit amount to the current account balance
                // Modify the Deposit and  Withdraw methods to store the transaction concerned in the history
                transactionHistory.Add(depAmount); // updates the transactionHistory, adds the deposit amount
            }
            else
            {
                // 1. Exception thrown if deposit amount entered zero or less than zero
                throw new ArgumentException("Deposit Amount must be greater than zero!");
            }
        }

        /* 5.	Implement a method WITHDRAW which allows a withdrawal to be made to the account. 
         * The method should take the amount to be withdrawn as a parameter. 
         * Only withdraw money if there are sufficient funds in the account subject to any overdraft facility that may be in place. 
         * Have the Withdraw method throw an exception if there are insufficient funds in the account to make the withdrawal.*/
        public void makeWithdrawl(double wdAmount)
        {
            // 1. check to make sure amount entered is greater than zero
            if(wdAmount > 0) 
            {
                // 2. Check to ensure that the wihdrawl amount is less than the account balance and overdraft limit
                if((accBalance + overDraftLimit) > wdAmount)
                {
                    accBalance -= wdAmount; // calculates the account balance when withdrawl amount deducted
                    // Modify the Deposit and  Withdraw methods to store the transaction concerned in the history.
                    transactionHistory.Add(wdAmount * -1); // updates the transactionHistory and adds the withdrawl to the list
                }
                else
                {
                    // 2. Exception thrown if wihdrawl amount exceeds account balance plus overdraft amount
                    throw new ArgumentException("Insufficient Funds! Please enter another amount!");
                }
            }
            else
            {
                // 1. Exception if amount less than zero or zero
                throw new ArgumentException("Withdrawl amount must be greater than zero!");
            }
        }

        // 7.	Override ToString() instead to return all information about the account including the transaction history.
        public override string ToString()
        {
            Console.WriteLine("\t*****Account Details*****\n\n");
            string accountDetails = "Sort Code: " + sortCode + "\nAccount Number: " + accNumber + "\nOverdraft Limit: " + overDraftLimit;

            // Add Account Transaction History Details
            accountDetails += "\nTotal Transactions on this account are: " + transactionHistory.Count + "\n\n";

            foreach(double transaction in transactionHistory)
            {
                if(transaction < 0)
                {
                    accountDetails += "Withdrawl amount of E" + transaction + "\n";
                }
                else
                {
                    accountDetails += "Deposited amount of E" + transaction + "\n";
                }
            }
            accountDetails += "Current Account Balance: E" + accBalance + "\n";
            return accountDetails;
        }

        /* 8.	Implement a set of unit tests to test any logic associated with changing the balance and recording the transaction 
         * history and validating inputs e.g. initial overdraft limit and amounts to deposit and withdraw from the account. 
         * Use Assert, and CollectionAssert. 
         * Check the code coverage. */
    }

    // Test Class
    class Program
    {
        public static void Main()
        {
            /* Console.WriteLine("*****EAD1 Unit Test Lab_Bank Account*****");
            BankAccount ba1 = new BankAccount("96-10-09", "cb123456", 500.00);
            BankAccount ba2 = new BankAccount("97-10-08", "de987654", 1000.00);
            ba1.makeDeposit(100.00); // ba1 account balance now 600.00
            ba2.makeDeposit(50.00); // ba2 account balance now 1050.00
            ba1.makeWithdrawl(200.00); // ba1 account balance now 400.00
            ba2.makeWithdrawl(150.00); // ba2 account balance now 900.00
            Console.WriteLine(ba1); // output ba1 account details
            Console.WriteLine(ba2); // output ba2 account details
            Console.ReadLine(); */
        }
    }
}
