using System;

namespace OopsSession
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Base class reference, derived class objects
            Person p1 = new Person(1, "John", 23);
            Person p2 = new Man(2, "Robert", 30, "Cricket");
            Person p3 = new Women(3, "Alice", 28, "Football");
            Person p4 = new Child(4, "Bob", 10, "ABC School");

            Console.WriteLine(p1.getDetails());
            Console.WriteLine(p2.getDetails());
            Console.WriteLine(p3.getDetails());
            Console.WriteLine(p4.getDetails());
        }
    }
}
