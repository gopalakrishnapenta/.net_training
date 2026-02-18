using System;
using System.Collections.Generic;
using System.Text;

namespace FullStack.Sample
{
    internal class Sample
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, Sample!");
        }
        public static string GetGreeting()
        {
            return "Hello from Sample!";
        }
        public static int Add(int a, int b)
        {
            return a + b;
        }
    }
}
