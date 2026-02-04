using System;

class OrderProcessor
{
    static void Main()
    {
        int[] orders = { 101, -1, 103 };

        // 1. Process each order
        foreach (int orderId in orders)
        {
            try
            {
                // 2. Validate order ID
                if (orderId <= 0)
                {
                    throw new ArgumentException("Invalid Order ID: " + orderId);
                }

                // Simulate order processing
                Console.WriteLine($"Order {orderId} processed successfully.");
            }
            catch (ArgumentException ex)
            {
                // 3. Handle invalid order without stopping loop
                Console.WriteLine("Order processing error: " + ex.Message);
            }
        }

        Console.WriteLine("All orders processed.");
    }
}
