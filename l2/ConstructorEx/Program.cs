using System;
using System.Data;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Runtime.InteropServices.Marshalling;
using OopsSession.ConstructorEx;
namespace OopsSession
{
    public class Program
    {
        public static void Main(String[] args)
        {
            //Visitor v1 = new Visitor(1);
            //Visitor v2 = new Visitor(2, "Gopi");
            Visitor v3 = new Visitor(3, "Krishna", "Need access to lab");
            Console.WriteLine(v3.LogHistory);
            //Console.WriteLine($"Visitor 1: Id = {v1.Id}");
            //Console.WriteLine($"Visitor 2: Id = {v2.Id}, Name = {v2.Name}");
            Console.WriteLine($"Visitor 3: Id = {v3.Id}, Name = {v3.Name}, Requirement = {v3.Requirement}");
        }
        
    }
}