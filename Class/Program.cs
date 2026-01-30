using System;

namespace EmployeeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Employee emp = new Employee
            {
                Id = 101,
                Name = "Gopal",
                Salary = 45000
            };

            Console.WriteLine("Id     : " + emp.Id);
            Console.WriteLine("Name   : " + emp.Name);
            Console.WriteLine("Salary : " + emp.Salary);

        }
    }
}




















public static class StringExtensions
{
    public static bool IsLong(this string str)
    {
        return str.Length > 5;
    }
}
class Program
{
    static void Main()
    {
        string name = "Gopal";

        bool result = name.IsLong();  // call
        Console.WriteLine(result);
    }
}
