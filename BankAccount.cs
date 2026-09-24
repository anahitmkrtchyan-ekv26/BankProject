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
            // TODO: Add validation to ensure the deposit amount is positive.
            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount > Balance)
            {
                throw new InsufficientFundsException("Not enough funds to withdraw.");
            }
            Balance -= amount;
        }

        public void Transfer(BankAccount targetAccount, decimal amount)
        {
            // BUG: Consider adding error handling if targetAccount is null.
            Withdraw(amount);
            targetAccount.Deposit(amount);
        }
    }
}
