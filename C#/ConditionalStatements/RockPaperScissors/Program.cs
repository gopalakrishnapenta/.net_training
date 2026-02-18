using System;

class Program
{
    static void Main()
    {
        // Read player choices
        Console.Write("Player 1 (rock/paper/scissors): ");
        string p1 = Console.ReadLine().ToLower();

        Console.Write("Player 2 (rock/paper/scissors): ");
        string p2 = Console.ReadLine().ToLower();

        // Compare choices using nested conditionals
        if (p1 == p2)
            Console.WriteLine("Match Draw");
        else if ((p1 == "rock" && p2 == "scissors") ||
                 (p1 == "scissors" && p2 == "paper") ||
                 (p1 == "paper" && p2 == "rock"))
            Console.WriteLine("Player 1 Wins");
        else
            Console.WriteLine("Player 2 Wins");
    }
}
