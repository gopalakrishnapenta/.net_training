using System;

class Program
{
    static void Main()
    {
        Employee emp = new Employee(101, "Arun", 45000);

        Type t1 = typeof(Employee);     // compile-time
        Type t2 = emp.GetType();
                // runtime

        Console.WriteLine(t1.FullName);
        Console.WriteLine(t2.FullName);
        Console.WriteLine(t1 == t2);    // True
    }
}