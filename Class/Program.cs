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
