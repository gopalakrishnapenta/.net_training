using System;

class DatabaseConnection
{
    static void Main()
    {
        bool isConnectionOpen = false;

        try
        {
            // 1. Open connection
            isConnectionOpen = true;
            Console.WriteLine("Database connection opened.");

            // 2. Simulate operation failure
            throw new Exception("Database operation failed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            // 3. Ensure connection is closed properly
            if (isConnectionOpen)
            {
                isConnectionOpen = false;
                Console.WriteLine("Database connection closed.");
            }
        }
    }
}
