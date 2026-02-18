using System;

class ExceptionRethrow
{
    static void Main()
    {
        try
        {
            ProcessData();
        }
        catch (Exception ex)
        {
            // Handle final exception
            Console.WriteLine("Main handled exception: " + ex.Message);
        }
    }

    static void ProcessData()
    {
        try
        {
            int.Parse("ABC");   // Causes FormatException
        }
        catch (Exception ex)
        {
            // Log exception
            Console.WriteLine("ProcessData log: " + ex.Message);

            // Rethrow while preserving stack trace
            throw;
        }
    }
}
