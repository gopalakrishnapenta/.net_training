namespace EmployeeTax
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IndEmployee i1 = new IndEmployee { Salary = 30000, Id = 101 };
            Console.WriteLine("I1 Employee Tax= "+i1.CalcTax());
            UsEmployee u1 = new UsEmployee { Salary = 30000, Id = 201 };
            Console.WriteLine("U1 Employee Tax= "+u1.CalcTax());
        }
    }
}
