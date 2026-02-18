using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceLect1
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
