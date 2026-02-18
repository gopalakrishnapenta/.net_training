using System;
using System.Collections.Generic;

namespace StudentApp
{
    class Student
    {
        public int Id;
        public string Name;
        public Dictionary<string, int> Marks;

        public Student(int id, string name, int maths, int science, int english)
        {
            Id = id;
            Name = name;
            Marks = new Dictionary<string, int>()
            {
                { "Maths", maths },
                { "Science", science },
                { "English", english }
            };
        }

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

        public List<string> GetFailedSubjects()
        {
            List<string> failed = new List<string>();

            foreach (var m in Marks)
            {
                if (m.Value < 35)
                    failed.Add(m.Key);
            }
            return failed;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>()
            {
                new Student(1, "Rahul", 80, 85, 90),
                new Student(2, "Anita", 30, 75, 88),
                new Student(3, "Suresh", 92, 33, 20)
            };

            // Predicate → check failure
            Predicate<Student> hasFailed =
                s => s.GetFailedSubjects().Count > 0;

            // Func → create message
            Func<Student, string> buildFailMessage = s =>
            {
                string subjects = string.Join(", ", s.GetFailedSubjects());
                return $"Student {s.Name} has FAILED in: {subjects}";
            };

            // Action → print
            Action<string> print = msg =>
            {
                Console.WriteLine(msg);
                Console.WriteLine();
            };

            foreach (Student s in students)
            {
                s.Display();

                if (hasFailed(s))
                {
                    print(buildFailMessage(s));
                }
            }

           
        }
    }
}
