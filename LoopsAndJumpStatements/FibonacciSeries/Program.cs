using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml;
public class FibonacciSeries
{
    public static void Main(String[] args)
    {
        int a =0;
        int b =1;
        int c;

        Console.Write("Enter the number of terms in Fibonacci series: ");
        String input = Console.ReadLine();
        Console.Write(a+" "+b+" ");
        if(int.TryParse(input, out int Terms) && Terms > 0)
        {
            int  i =3;
            while (i <= Terms)
            {
                c =a+b;

                Console.Write(c+" ");
                a=b;
                b=c;
                i++;
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a positive integer. ");
        }
    }
}