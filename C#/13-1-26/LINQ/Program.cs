using System;
using System.Collections.Generic;
using System.Linq;

namespace Day18LINQ
{
    public class StudentMark
    {
        public string? Subject { get; set; }
        public int Marks { get; set; }
    }

    public class Day18LINQ
    {
        public static void Run(string[] args)
        {
            List<StudentMark> marks = new List<StudentMark>
            {
                new StudentMark { Subject = "Maths", Marks = 85 },
                new StudentMark { Subject = "Physics", Marks = 72 },
                new StudentMark { Subject = "Chemistry", Marks = 45 },
                new StudentMark { Subject = "English", Marks = 90 },
                new StudentMark { Subject = "Computer", Marks = 60 }
            };

            // Highest Marks (LINQ Query Syntax)
            var highest =
                (from m in marks
                 orderby m.Marks descending
                 select m).First();

            Console.WriteLine($"Highest Marks: {highest.Subject} - {highest.Marks}");

            // Average Marks (LINQ Query Syntax)
            var average =
                (from m in marks
                 select m.Marks).Average();

            Console.WriteLine($"Average Marks: {average}");
        }
    }
}
