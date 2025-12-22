using System;
namespace EmployeeSystem
{
    public  class Program
    {
        public static void Main(String[] args)
        {
            Employee emp1 = new Employee(101, "Alice", 50000);
            Employee emp2 = new Employee(102, "Alices", 55000);
            Developer dev1 = new Developer(201, "Bob", 60000, "C#");
            Manager mgr1 = new Manager(301, "Charlie", 70000, "10");

            Console.WriteLine(emp1.getDetails());
            Console.WriteLine(emp2.getDetails());
            Console.WriteLine(dev1.getDetails());
            Console.WriteLine(mgr1.getDetails());
        }
    }
}