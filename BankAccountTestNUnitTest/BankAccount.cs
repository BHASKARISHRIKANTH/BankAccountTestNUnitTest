using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountTestNUnitTest
{

    public class BankAccount
    {
        public double Balance { get; private set; }

        public BankAccount(double initialBalance = 0)
        {
            if (initialBalance < 0)
                throw new ArgumentException("Initial balance cannot be negative.");
            Balance = initialBalance;
        }

        public void Deposit(double amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Deposit amount must be positive.");
            Balance += amount;
        }

        public void Withdraw(double amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Withdraw amount must be positive.");
            if (amount > Balance)
                throw new InvalidOperationException("Insufficient balance.");
            Balance -= amount;
        }

        public double GetBalance()
        {
            return Balance;
        }

        public void Transfer(BankAccount toAccount, double amount)
        {
            if (toAccount == null)
                throw new ArgumentNullException(nameof(toAccount), "Target account cannot be null.");
            if (amount <= 0)
                throw new ArgumentException("Transfer amount must be positive.");
            if (amount > Balance)
                throw new InvalidOperationException("Insufficient balance to transfer.");

            Withdraw(amount);
            toAccount.Deposit(amount);
        }
    }
}




   
   
    




