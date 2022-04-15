// CA3 sample solution - bank account
// author: GC

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    // a bank account
    public class BankAccount : IEnumerable
    {
        // fields
        private String sortCode;
        private String accountNo;
        private double balance;                 // �
        private double overdraftLimit;
        
        public String SortCode{get{return sortCode;}}
        
        public String AccountNo{get{return accountNo;}} 
        
        public double Balance{get{return balance;}}
        
        public double Overdraftlimit{get{return overdraftLimit;}}             // �  

        private const int MaxTransactions = 100;
        public double[] transactionHistory;   // a record of amounts deposited and withdrawn
        private int nextTransaction;           // the next free slot in the transactionHistory array 
 
        // constructor
        public BankAccount(String sortCode, String accountNo, double overdraftLimit)
        {
            this.sortCode = sortCode;
            this.accountNo = accountNo;
            this.balance = 0;
            this.overdraftLimit = overdraftLimit;

            transactionHistory = new double[MaxTransactions];
            nextTransaction = 0;                // no transaction to date
        }

        // overloaded constructor - chain
        public BankAccount(String sortCode, String accountNo)
            : this(sortCode, accountNo, 0)
        {
        }

       
        // deposit money in the account
        public void Deposit(double amount)                      // assume amount is positive
        {
            balance += amount;

            // record in transaction history
            transactionHistory[nextTransaction++] = amount;
        }

        // withdraw money if there are sufficient funds
        public bool Withdraw(double amount)                     // assume amount is positive
        {
            if ((balance + overdraftLimit) > amount)
            {
                balance -= amount;
                transactionHistory[nextTransaction++] = amount * -1;
                return true;                            // withdraw was succesful
            }
            else                                        // unsufficient funds
            {
                throw new ArgumentException("Insufficient funds withdrawal cancelled");
            }
        }

        // print account details to the console
     

        public override string ToString()
        {
            StringBuilder sbuilder = new StringBuilder();
            sbuilder.Append("sort code: " + sortCode + " account no: " + accountNo + " overdraft limit: " + overdraftLimit + " balance: " + balance);

            sbuilder.Append(" | Transaction History:");
            for (int i = 0; i < nextTransaction; i++ )
            {
                sbuilder.Append(transactionHistory[i] + " ");
            }
            return sbuilder.ToString();
        }

        public IEnumerator GetEnumerator()
        {
            return transactionHistory.GetEnumerator();
        }
    }

    

  

    





    // test class
    /* class BankAccountTest
     {
         public static void Main()
         {
             BankAccount b = new BankAccount("903555", "12344544", 1000);
             b.PrintAccountDetails();

             b.Deposit(100);

             if (b.Withdraw(200))
             {
                 Console.WriteLine("Withdrawal was successful");
                 b.PrintAccountDetails();
             }
             else
             {
                 Console.WriteLine("Withdrawal failed");
             }

             b.Deposit(500);
             b.PrintAccountDetails();
             b.PrintTransactionHistory();
         }
     }*/
}
