using System;
using System.Data.Common;
using EmployeePayrollSystem;
namespace EmployeePayrollSystem
{
    public class Program
    {
        public static void Main(String[] args)
        {
            Employee e1 = new FullTimeEmployee{ Id = 101, MonthlySalary = 50000};
            Employee e2 = new ContractEmployee{ Id = 201, hoursWorked = 50, hourlyWage= 500};
            Console.WriteLine(e1.getSalary());
            Console.WriteLine(e2.getSalary());

            
        }
    }
}