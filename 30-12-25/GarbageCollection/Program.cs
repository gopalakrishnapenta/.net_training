using System;
using Microsoft.VisualBasic;
class Program
{
    static void Main()
    {
        var list = new List<byte[]>();
        for(int i = 0;i < 20000; i++)
            list.Add(new byte[1024]);
    Console.WriteLine("Allocated");
    Console.WriteLine("Total memory: "+GC.GetTotalMemory(forceFullCollection: false));
    }
}