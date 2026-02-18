using System;

class BankAccount
{
    static void Main()
    {
        int balance = 10000;

        // Show current balance first
        Console.WriteLine("Current Balance: " + balance);

        try
        {
            Console.WriteLine("Enter withdrawal amount:");
            if (!int.TryParse(Console.ReadLine(), out int amount))
            {
                throw new FormatException("Please enter a valid number.");
            }

            // 1. Amount must be greater than zero
            if (amount <= 0)
            {
                throw new ArgumentException("Withdrawal amount must be greater than zero.");
            }

            // 2. Amount must not exceed balance
            if (amount > balance)
            {
                throw new InvalidOperationException("Insufficient balance.");
            }

            // 3. Deduct amount
            balance -= amount;
            Console.WriteLine("Withdrawal successful!");
            Console.WriteLine("Updated Balance: " + balance);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            // 4. Log transaction
            Console.WriteLine("Transaction completed at: " + DateTime.Now);
        }
    }
}
