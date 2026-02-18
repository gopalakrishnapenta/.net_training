using System;
using OopsSession;
using System.Data;

namespace OopsSession
{
    public class Program
    {
        static void Main(string[] args)
        {
            Student gopi = new Student(101);

            gopi.Name = "Gopi";
            gopi.Age = 18;
            gopi.Marks = 90;

            Console.WriteLine($"Id    : {gopi.StudentId}");
            Console.WriteLine($"Name  : {gopi.Name}");
            Console.WriteLine($"Age   : {gopi.Age}");
            Console.WriteLine($"Marks : {gopi.Marks}");
            Console.WriteLine($"Grade : {gopi.Grade}");

        }
    }
}
