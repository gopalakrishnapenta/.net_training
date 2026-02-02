using System;
using System.Collections.Generic;
using StudentGradeSystem;

namespace StudentGradeSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            SchoolManager manager = new SchoolManager();

            // Add students
            manager.AddStudent("Alice", "10th");
            manager.AddStudent("Bob", "10th");
            manager.AddStudent("Charlie", "11th");

            // Add grades
            manager.AddGrade(1, "Math", 85);
            manager.AddGrade(1, "Science", 90);

            manager.AddGrade(2, "Math", 78);
            manager.AddGrade(2, "Science", 82);

            manager.AddGrade(3, "Math", 92);
            manager.AddGrade(3, "Science", 88);

            // Group students by grade
            Console.WriteLine("Students Grouped by Grade:");
            SortedDictionary<string, List<Student>> grouped =
                manager.GroupStudentsByGradeLevel();

            foreach (var grade in grouped)
            {
                Console.WriteLine("\nGrade: " + grade.Key);
                foreach (Student s in grade.Value)
                {
                    Console.WriteLine(s.Name);
                }
            }

            // Student average
            Console.WriteLine("\nAlice Average: " +
                manager.CalculateStudentAverage(1));

            // Subject averages
            Console.WriteLine("\nSubject Averages:");
            Dictionary<string, double> subjectAvg =
                manager.CalculateSubjectAverages();

            foreach (var subject in subjectAvg)
            {
                Console.WriteLine(subject.Key + ": " + subject.Value);
            }

            // Top performers
            Console.WriteLine("\nTop Performers:");
            List<Student> topStudents = manager.GetTopPerformers(2);
            foreach (Student s in topStudents)
            {
                Console.WriteLine(s.Name);
            }
        }
    }
}
