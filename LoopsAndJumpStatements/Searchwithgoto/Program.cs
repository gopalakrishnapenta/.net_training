using System;

class Program
{
    static void Main()
    {
        int[,] matrix =
        {
            {1, 2, 3},
            {4, 5, 6},
            {7, 8, 9}
        };

        int target = 5;

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (matrix[i, j] == target)
                {
                    Console.WriteLine("Found at position: " + i + ", " + j);
                    goto FOUND;
                }
            }
        }

        Console.WriteLine("Not Found");

    FOUND:
        Console.WriteLine("Search Completed");
    }
}
