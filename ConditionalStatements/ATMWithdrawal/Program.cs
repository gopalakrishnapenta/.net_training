using System;

class Program
{
    static void Main()
    {
        bool cardInserted = true;
        int correctPin = 1234;
        int enteredPin = 1234;
        int balance = 5000;
        int withdrawalAmount = 2000;

        // Step 1: Check if card is inserted
        if (cardInserted)
        {
            // Step 2: Validate PIN
            if (enteredPin == correctPin)
            {
                // Step 3: Check sufficient balance
                if (withdrawalAmount <= balance)
                    Console.WriteLine("Transaction Successful");
                else
                    Console.WriteLine("Insufficient Balance");
            }
            else
            {
                Console.WriteLine("Invalid PIN");
            }
        }
        else
        {
            Console.WriteLine("Please Insert Card");
        }
    }
}
