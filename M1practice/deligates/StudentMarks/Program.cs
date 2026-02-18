using System;
using System.Collections.Generic;
using StudentApp.Models;   // using Student namespace

namespace StudentApp
{
    /// <summary>
    /// Program class (Main)
    /// </summary>
    class Program
    {
        // Delegate declaration
        delegate void FailMessage(string message);
        delegate void DestintationDelegate(string message);

        static void Main()
        {
            List<Student> students = new List<Student>()
            {
                new Student(101, "Rahul", 80, 85, 90),
                new Student(102, "Anita", 30, 75, 88),
                new Student(103, "Suresh", 92, 33, 20)
            };

            // Delegate instance
            FailMessage notifyFail = SendFailMessage;


            foreach (Student s in students)
            {
                s.Display();

                List<string> failedSubjects = s.GetFailedSubjects();

                if (failedSubjects.Count > 0)
                {
                    string subjects = string.Join(", ", failedSubjects);
                    notifyFail($"Student {s.Id}:{s.Name} has FAILED in: {subjects}");
                }
                
            }

        }

        // Delegate target method
        static void SendFailMessage(string msg)
        {
            Console.WriteLine(msg);
            Console.WriteLine();
        }
    }
}
