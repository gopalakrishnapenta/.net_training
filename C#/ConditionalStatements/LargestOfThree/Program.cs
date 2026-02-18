using System;
using System.Data;
public class LargestOfThree
{
    public static void Main(String[] args)
    {
        Console.Write("First Number: ");
        String input1 = Console.ReadLine();
        Console.Write("Second Number: ");
        String input2 = Console.ReadLine();
        Console.Write("Third Number: ");
        String input3 = Console.ReadLine();
        if(int.TryParse(input1, out int num1) && int.TryParse(input2,out int num2) && int.TryParse(input3, out int num3))
        {
            if(num1 >= num2 && num1 >= num3)
            {
                Console.WriteLine("Largest Number is: " + num1);
            }
            else if(num2 >= num1 && num2 >= num3)
            {
                Console.WriteLine("Largest Number is: " + num2);
            }
            else
            {
                Console.WriteLine("Largest Number is: " + num3);
            }
        }
    }
}