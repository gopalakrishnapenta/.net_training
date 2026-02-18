using System;

class PalindromeCheck
{
    // Static method for string palindrome
    static bool IsPalindrome(string input)
    {
        int left = 0;
        int right = input.Length - 1;

        while (left < right)
        {
            if (input[left] != input[right])
                return false;

            left++;
            right--;
        }
        return true;
    }

    // Static method for integer palindrome
    static bool IsPalindrome(int number)
    {
        int original = number;
        int reverse = 0;

        while (number > 0)
        {
            reverse = reverse * 10 + (number % 10);
            number /= 10;
        }
        return original == reverse;
    }

    static void Main()
    {
        Console.Write("Enter input (number or text): ");
        string input = Console.ReadLine();

        // Check if input is integer
        if (int.TryParse(input, out int num))
        {
            if (IsPalindrome(num))
                Console.WriteLine("Palindrome number");
            else
                Console.WriteLine("Not a palindrome number");
        }
        else
        {
            if (IsPalindrome(input))
                Console.WriteLine("Palindrome string");
            else
                Console.WriteLine("Not a palindrome string");
        }
    }
}
