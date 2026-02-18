using System;
using System.Collections.Generic;

namespace StudentApp.Models
{
    /// <summary>
    /// Student class
    /// </summary>
    class Student
    {
        public int Id;
        public string Name;
        public Dictionary<string, int> Marks;

        // Constructor
        public Student(int id, string name, int sub1, int sub2, int sub3)
        {
            Id = id;
            Name = name;

            Marks = new Dictionary<string, int>()
            {
                { "Maths", sub1 },
                { "Science", sub2 },
                { "English", sub3 }
            };
        }

        // Display student details
        public void Display()
        {
            Console.WriteLine($"StudentID: {Id}");
            Console.WriteLine($"Name: {Name}");
            foreach (var m in Marks)
            {
                Console.WriteLine($"{m.Key}: {m.Value}");
            }
            Console.WriteLine();
        }

        // Get failed subjects
        public List<string> GetFailedSubjects()
        {
            List<string> failedSubjects = new List<string>();

            foreach (var m in Marks)
            {
                if (m.Value < 35)
                {
                    failedSubjects.Add(m.Key);
                }
            }

            return failedSubjects;
        }
    }
}
