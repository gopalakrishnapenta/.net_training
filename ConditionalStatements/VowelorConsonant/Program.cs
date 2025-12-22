using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a character: ");
        char ch = char.ToLower(Console.ReadLine()[0]);

        if (ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u')
            Console.WriteLine("Vowel");
        else
            Console.WriteLine("Consonant");
    }
}
