// Cliff Browne - X00014810
// EAD1 CA1 Example Program - Bank Account and Unit Tests
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    /* You are required to design and implement a simple banking system in C# follows:
1.	Implement a BankAccount class to represent a generic bank account. */
    public class BankAccount
    {
        // Each account has an account number, balance, and abstract methods to make deposits and withdrawals from the account. 
        // More specifically the class should contain the following items: 

        /* Fields:
        The bank account number (alpha-numeric)
        The balance on the account */
        private string accountNumber;
        private double accountBalance;

        /* Properties:
        A read-only property for the account number field
        A read-write property for the balance field */
        public String AccountNumber
        {
            get
            {
                return accountNumber;
            }
        }

        public double AccountBalance
        {
            get
            {
                return accountBalance;
            }
        }
        /* Constructor:
        One constructor which sets the account number to the value of an input parameter, and sets the balance to zero */
        public BankAccount(String accNum, double accBal)
        {
            this.accountNumber = accNum;
            this.accountBalance = 0; // set the account balance to zero
        }

        /* Abstract Methods:
        MakeDeposit -allow an amount of money to be deposited in the account
        MakeWithdrawal - allow an amount of money to be withdrawn from the account */
        public void makeDeposit(double depAmt)
        {
            if (depAmt > 0)
            {
                accountBalance += depAmt;
            }
            else
            {
                throw new ArgumentException("Deposit amount must be greater than zero.");
            }
        }

        public void makeWithdrawl(double wdAmt)
        {
            // 1. check to ensure withdrawl amount greater than zero
            if (wdAmt > 0)
            {
                // 2. check to ensure account balance is greater than withdrawl amount
                if (accountBalance > wdAmt)
                {
                    accountBalance -= wdAmt;
                }
                else
                {
                    // 2. exception thrown if account balance less than withdrawl amount
                    throw new ArgumentException("Insufficient Funds. Please enter another amount to withdraw.");
                }
            }
            else
            {
                // 1. exception thrown if withdrawl amount less than or equal to zero
                throw new ArgumentException("Withdrawl Amount must be greater than zero.");
            }
        }
    }
     


    // Test Class
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("*****EAD CA1 Example Program - Bank Account*****")
        }
    }
}
