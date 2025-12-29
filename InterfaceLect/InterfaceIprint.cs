using System;
namespace InterfaceLect
{
    public interface Iprint
    {
        public void Print();
    }
    public class Printer : Iprint
    {
        public void Print()
        {
            Console.WriteLine("Printing using Iprint interface");
        }
    }
}