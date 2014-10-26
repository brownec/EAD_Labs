// Cliff Browne - X00014810 
// EAD1 Lab Unit Testing using Bank Account
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest_Bank
{
    /*      * dd read-only properties to correspond to these fields. 
     * An overdraft limit of greater than zero indicates that an overdraft facility applies to the account. */
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


        /* 4.	Implement a method Deposit which allows a deposit to be made to the account. 
         * The method should take the amount to deposit as a parameter.. */

        /* 5.	Implement a method Withdraw which allows a withdrawal to be made to the account. 
         * The method should take the amount to be withdrawn as a parameter. 
         * Only withdraw money if there are sufficient funds in the account subject to any overdraft facility that may be in place. 
         * Have the Withdraw method throw an exception if there are insufficient funds in the account to make the withdrawal.*/

        /* 6.	 
         * Modify the Deposit and  Withdraw methods to store the transaction concerned in the history. */

        // 7.	Override ToString() instead to return all information about the account including the transaction history.

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
            Console.WriteLine("*****EAD1 Unit Test Lab_Bank Account*****");
        }
    }
}
