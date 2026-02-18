using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeTax
{
    public abstract class Employee

    {
        public int Salary {  get; set; }
       
        public int Id { get; set; }
        public abstract double CalcTax();
       
                  
    }
    public class IndEmployee : Employee
    {
        public override double CalcTax()
        {
            return Salary * 0.3;
        }
        
    }
    public class UsEmployee : Employee
        {
        public override double CalcTax()
        {
            return   Salary * 0.4;
        }
        }
}
