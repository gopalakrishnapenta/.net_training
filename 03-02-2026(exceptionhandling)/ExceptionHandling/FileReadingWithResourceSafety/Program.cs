using System;
using System.IO;

class FileReader
{
    static void Main()
    {
        string filePath = "data.txt";

        try
        {
            // 1. Read file content safely
            using (StreamReader reader = new StreamReader(filePath))
            {
                string content = reader.ReadToEnd();
                Console.WriteLine("File Content:\n" + content);
            }
        }
        catch (FileNotFoundException)
        {
            // 2. Handle file not found
            Console.WriteLine("Error: File not found.");
        }
        catch (UnauthorizedAccessException)
        {
            // 3. Handle access denied
            Console.WriteLine("Error: You do not have permission to access this file.");
        }
        catch (Exception ex)
        {
            // Handle any other errors
            Console.WriteLine("Unexpected error: " + ex.Message);
        }
        finally
        {
            // 4. Resource safety confirmation
            Console.WriteLine("File read operation completed.");
        }
    }
}
