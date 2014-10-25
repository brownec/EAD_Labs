// Cliff Browne - x00014810
// EAD Lab 5 Enums and Structs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum CurrencyUnit { Euro, Dollar } // This is a collection of Currency Units 
namespace Lab5_Enums
{
    /* Implement a Money structure which stores an amount of money and the currency unit for that amount. 
 * Currency units should be euro or US dollar or yen. Use auto-implemented properties. */
    public struct Money
    {
        // Store the various conversion rates to be used in the conversion as constants in the structure.
        private const double EuroToDollarRate = 1.31; // use const as this value will not change
        private const double DollarToEuroRate = 0.76; // use const as this value will not change       

        // create a instance of CurrencyUnit with Getters and Setters
        public CurrencyUnit Currency
        {
            get;
            set;
        }

        public double Amount
        {
            get;
            set;
        }

        // Add a non-default constructor allowing the amount and the currency unit to be specified at the time of construction of an object.
        public Money (CurrencyUnit currency, double amount)
            :this()
        {
            this.Currency = currency; // line 21 - map instance of Currency with currency parameter being passed into constructor 
            this.Amount = amount; // line 27 - map Amount with the amount parameter being passed into constructor
        }

        // Implement a method in the structure which allows the currency amount to be converted into an amount in a different currency and returned.
        public double Convert (CurrencyUnit toCurrency)
        {
            if (Currency == toCurrency) // if the currency values are the same
            {
                return Amount;
            }
            else
            {
                if (toCurrency == CurrencyUnit.Dollar)
                {
                    return Amount * EuroToDollarRate;
                }
                else // convert the value to Euro
                {
                    return Amount * DollarToEuroRate;
                }
            }
        }

        /* Implement a method which allows 2 Money objects to be added together. 
           The first Money object determines the currency unit for the result 
           e.g. euro + dollar = euro. Convert currencies if necessary in this method */
        public static Money Add(Money lhs, Money rhs)
        {
            return lhs + rhs;
        }

        // overload the +operator
        public static Money operator +(Money lhs, Money rhs)
        {
            // lhs currency determines the currency for the result
            if (lhs.Currency == rhs.Currency)
            {
                // if both currencies the same
                return new Money(lhs.Currency, lhs.Amount + rhs.Amount);
            }
            else
            {
                // convert the currency if you need to add currencies together
                return new Money(lhs.Currency, lhs.Amount + rhs.Convert(lhs.Currency));
            }
        }

        // Override ToString method to output the amount
        public override string ToString()
        {
            return this.Currency + ": " + this.Amount;
        }

        // Test Class
        class Test
        {
            public static void Main()
            {
                Money m1 = new Money(CurrencyUnit.Euro, 50);
                Money m2 = new Money(CurrencyUnit.Dollar, 70);
                Money m3 = m1 + m2;
                Console.WriteLine(m3);
                Money m4 = m3 + (new Money(CurrencyUnit.Dollar, 100));
                Console.WriteLine(m4);
            }
        }
    }
}
