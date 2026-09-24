using System;

namespace BankAccountProject
{
    public class BankAccount
    {
        public string AccountNumber { get; set; }

        public decimal Balance { get; private set; }

        public BankAccount(string accountNumber, decimal initialBalance = 0)
        {
            AccountNumber = accountNumber;
            Balance = initialBalance;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "The deposit amount must be greater than zero.");
            }

            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "The withdrawal amount must be greater than zero.");
            }

            if (amount > Balance)
            {
                throw new InsufficientFundsException("Not enough funds to withdraw.");
            }
            Balance -= amount;
        }

        public void Transfer(BankAccount targetAccount, decimal amount)
        {
            if (targetAccount == null)
            {
                throw new ArgumentNullException(nameof(targetAccount));
            }

            Withdraw(amount);
            targetAccount.Deposit(amount);
        }
    }
}
