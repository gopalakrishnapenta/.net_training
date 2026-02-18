using System;

class Controller
{
    static void Main()
    {
        try
        {
            // Call Service method
            Service.Process();
        }
        catch (Exception ex)
        {
            // Handle exception at top layer
            Console.WriteLine("Controller handled exception: " + ex.Message);
        }
    }
}

class Service
{
    public static void Process()
    {
        try
        {
            // Call Repository method
            Repository.GetData();
        }
        catch (Exception ex)
        {
            // Catch and log exception
            Console.WriteLine("Service log: " + ex.Message);

            // Rethrow exception to Controller
            throw;
        }
    }
}

class Repository
{
    public static void GetData()
    {
        // Throw exception at data layer
        throw new Exception("Database connection failed.");
    }
}
