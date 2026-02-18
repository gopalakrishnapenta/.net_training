using System;

// Custom Exception class
class LoginAttemptsExceededException : Exception
{
    public LoginAttemptsExceededException(string message) : base(message)
    {
    }
}

class LoginSystem
{
    static void Main()
    {
        int attempts = 0;
        const int maxAttempts = 3;

        try
        {
            while (true)
            {
                Console.WriteLine("Enter password:");
                string password = Console.ReadLine();

                // Assume correct password is "admin"
                if (password == "admin")
                {
                    Console.WriteLine("Login successful!");
                    break;
                }
                else
                {
                    attempts++;
                    Console.WriteLine("Invalid password. Attempt " + attempts);

                    // Throw custom exception after limit
                    if (attempts >= maxAttempts)
                    {
                        throw new LoginAttemptsExceededException(
                            "Login failed. Maximum attempts exceeded."
                        );
                    }
                }
            }
        }
        catch (LoginAttemptsExceededException ex)
        {
            // Handle custom exception
            Console.WriteLine("Error: " + ex.Message);
            Console.WriteLine("Application terminated.");
        }
    }
}
