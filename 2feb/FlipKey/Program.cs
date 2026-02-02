using System;
using System.Text;

public class Program
{
    // Method implementation as specified
    public string CleanseAndInvert(string input)
    {
        // Rule 1: Null or length < 6
        if (string.IsNullOrEmpty(input) || input.Length < 6)
        {
            return string.Empty;
        }

        // Rule 2: Must not contain space, digit, or special character
        foreach (char c in input)
        {
            if (!char.IsLetter(c))
            {
                return string.Empty;
            }
        }

        // Convert to lowercase
        input = input.ToLower();

        // Remove characters with even ASCII values
        StringBuilder filtered = new StringBuilder();
        foreach (char c in input)
        {
            if ((int)c % 2 != 0) // keep only odd ASCII values
            {
                filtered.Append(c);
            }
        }

        // Reverse the remaining characters
        char[] arr = filtered.ToString().ToCharArray();
        Array.Reverse(arr);

        // Convert even-positioned characters (0-based) to uppercase
        for (int i = 0; i < arr.Length; i++)
        {
            if (i % 2 == 0)
            {
                arr[i] = char.ToUpper(arr[i]);
            }
        }

        return new string(arr);
    }

    public static void Main(string[] args)
    {
        Program program = new Program();

        Console.WriteLine("Enter the word");
        string input = Console.ReadLine();

        string result = program.CleanseAndInvert(input);

        if (string.IsNullOrEmpty(result))
        {
            Console.WriteLine("Invalid Input");
        }
        else
        {
            Console.WriteLine("The generated key is - " + result);
        }
    }
}
