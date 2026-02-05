using System;
using System.Collections.Generic;
using System.Linq;

namespace BankAccountManagement
{
    // Transaction class
    class Transaction
    {
        public string TransactionId { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Type { get; set; } // Deposit / Withdrawal / Transfer
        public double Amount { get; set; }
        public string Description { get; set; }
    }

    // Account class
    class Account
    {
        public string AccountNumber { get; set; }
        public string AccountHolder { get; set; }
        public string AccountType { get; set; } // Savings / Current / Fixed
        public double Balance { get; set; }
        public List<Transaction> TransactionHistory { get; set; }

        public Account()
        {
            TransactionHistory = new List<Transaction>();
        }
    }

    // BankManager class
    class BankManager
    {
        private List<Account> accounts = new List<Account>();
        private int accountCounter = 1001;
        private int transactionCounter = 1;

        // Create account
        public void CreateAccount(string holder, string type, double initialDeposit)
        {
            Account account = new Account
            {
                AccountNumber = "ACC" + accountCounter++,
                AccountHolder = holder,
                AccountType = type,
                Balance = initialDeposit
            };

            account.TransactionHistory.Add(new Transaction
            {
                TransactionId = "T" + transactionCounter++,
                TransactionDate = DateTime.Now,
                Type = "Deposit",
                Amount = initialDeposit,
                Description = "Initial Deposit"
            });

            accounts.Add(account);
            Console.WriteLine("Account created successfully");
        }

        // Deposit money
        public bool Deposit(string accountNumber, double amount)
        {
            Account account = accounts
                .FirstOrDefault(a => a.AccountNumber == accountNumber);

            if (account == null || amount <= 0)
                return false;

            account.Balance += amount;
            account.TransactionHistory.Add(new Transaction
            {
                TransactionId = "T" + transactionCounter++,
                TransactionDate = DateTime.Now,
                Type = "Deposit",
                Amount = amount,
                Description = "Cash Deposit"
            });

            return true;
        }

        // Withdraw money
        public bool Withdraw(string accountNumber, double amount)
        {
            Account account = accounts
                .FirstOrDefault(a => a.AccountNumber == accountNumber);

            if (account == null || amount <= 0 || account.Balance < amount)
                return false;

            account.Balance -= amount;
            account.TransactionHistory.Add(new Transaction
            {
                TransactionId = "T" + transactionCounter++,
                TransactionDate = DateTime.Now,
                Type = "Withdrawal",
                Amount = amount,
                Description = "Cash Withdrawal"
            });

            return true;
        }

        // Group accounts by type
        public Dictionary<string, List<Account>> GroupAccountsByType()
        {
            return accounts
                .GroupBy(a => a.AccountType)
                .ToDictionary(g => g.Key, g => g.ToList());
        }

        // Get account statement
        public List<Transaction> GetAccountStatement(string accountNumber,
                                                     DateTime from, DateTime to)
        {
            Account account = accounts
                .FirstOrDefault(a => a.AccountNumber == accountNumber);

            if (account == null)
                return new List<Transaction>();

            return account.TransactionHistory
                .Where(t => t.TransactionDate >= from &&
                            t.TransactionDate <= to)
                .ToList();
        }
    }

    // Program class
    class Program
    {
        static void Main()
        {
            BankManager manager = new BankManager();

            // Create accounts
            manager.CreateAccount("Ravi", "Savings", 5000);
            manager.CreateAccount("Anita", "Current", 10000);

            // Perform transactions
            manager.Deposit("ACC1001", 2000);
            manager.Withdraw("ACC1001", 1500);

            // Group accounts by type
            Console.WriteLine("\nAccounts Grouped By Type:");
            var grouped = manager.GroupAccountsByType();
            foreach (var group in grouped)
            {
                Console.WriteLine(group.Key);
                foreach (var acc in group.Value)
                    Console.WriteLine(acc.AccountNumber + " - " + acc.AccountHolder);
            }

            // Get account statement
            Console.WriteLine("\nAccount Statement for ACC1001:");
            var statement = manager.GetAccountStatement(
                "ACC1001",
                DateTime.Now.AddDays(-1),
                DateTime.Now.AddDays(1));

            foreach (var txn in statement)
            {
                Console.WriteLine(txn.TransactionDate +
                                  " " + txn.Type +
                                  " " + txn.Amount);
            }
        }
    }
}
