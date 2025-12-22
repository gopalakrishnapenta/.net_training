using System;
using System.Linq.Expressions;
using OopsSession.ConstructorEx;
namespace OopsSession
{
    public class Program
    {
        public static void Main(String[] args)
        {
            Visitor v1 = new Visitor(101);
            Visitor v2 = new Visitor(102, "Alice");
            Console.WriteLine($"Visitor 1: Id = {v1.Id}");
        }
        
    }
}