using System;
public class Palindrome
{
    public static void Main(String[] args)
    {
        Console.WriteLine("Enter a number: ");
        String number = Console.ReadLine();
        if(int.TryParse(number, out int num))
        {
            int originalNum = num;
            int reversedNum = 0;

            while (num > 0)
            {
                int digit = num % 10;
                reversedNum = reversedNum * 10 + digit;
                num /= 10;
            }

            if (reversedNum == originalNum)
            {
                Console.WriteLine(originalNum + " is a palindrome.");
            }
            else
            {
                Console.WriteLine(originalNum + " is not a palindrome.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid integer.");
        }
    }
}