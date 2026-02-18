using System;
using EmployeePayrollSystem;
namespace EmployeePayrollSystem
{
    public class Employee
    {
        public int Id{get; set;}
        public virtual decimal getSalary()
        {
            return 0; 
        }
    }
    public class FullTimeEmployee : Employee
    {
        public decimal MonthlySalary{get; set; }
        public override decimal getSalary()
        {
            return MonthlySalary;
        }
    }
    public class ContractEmployee : Employee
    {
        public int hoursWorked;
    
        public decimal hourlyWage;

        public override decimal getSalary()
        {
            return hoursWorked*hourlyWage;
        }
    }

}