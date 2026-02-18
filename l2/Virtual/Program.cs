using System;
using System.Runtime.CompilerServices;
using OopsSession;
namespace OopsSession
{
    public class Program
    {
        public static void Main(String[] args)
        {
            Father f1 = new Father();
            Son s1= new Son();
            Console.WriteLine(f1.InterestOn());
            Console.WriteLine(s1.InterestOn());
        }
    }
}