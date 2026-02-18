using System;
using System.Collections.Generic;

namespace BankStatementAnalysis
{
    public class TransactionProcessor
    {
        public static Dictionary<string, decimal> CalculateSpendByCategory(
            List<(string Category, decimal Amount)> transactions)
        {
            if (transactions == null)
                throw new ArgumentNullException(nameof(transactions));

            var spendByCategory = new Dictionary<string, decimal>();

            foreach (var transaction in transactions)
            {
                if (transaction.Amount < 0)
                {
                    decimal spendAmount = Math.Abs(transaction.Amount);

                    if (spendByCategory.ContainsKey(transaction.Category))
                    {
                        spendByCategory[transaction.Category] += spendAmount;
                    }
                    else
                    {
                        spendByCategory[transaction.Category] = spendAmount;
                    }
                }
            }

            return spendByCategory;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var transactions = new List<(string Category, decimal Amount)>
            {
                ("Food", -200m),
                ("Fuel", -500m),
                ("Food", -50m),
                ("Salary", 1000m)
            };

            var spendByCategory =
                TransactionProcessor.CalculateSpendByCategory(transactions);

            Console.WriteLine("Spend By Category:");

            foreach (var entry in spendByCategory)
            {
                Console.WriteLine($"{entry.Key} : {entry.Value}");
            }
        }
    }
}
