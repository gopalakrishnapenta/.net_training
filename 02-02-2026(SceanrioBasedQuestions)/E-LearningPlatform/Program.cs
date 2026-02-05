using System;
using System.Collections.Generic;
using System.Linq;

namespace ELearningPlatform
{
    // Course class
    class Course
    {
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public string Instructor { get; set; }
        public int DurationWeeks { get; set; }
        public double Price { get; set; }
        public List<string> Modules { get; set; }

        public Course()
        {
            Modules = new List<string>();
        }
    }

    // Enrollment class
    class Enrollment
    {
        public int EnrollmentId { get; set; }
        public string StudentId { get; set; }
        public string CourseCode { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public double ProgressPercentage { get; set; }
    }

    // StudentProgress class
    class StudentProgress
    {
        public string StudentId { get; set; }
        public string CourseCode { get; set; }
        public Dictionary<string, double> ModuleScores { get; set; }
        public DateTime LastAccessed { get; set; }

        public StudentProgress()
        {
            ModuleScores = new Dictionary<string, double>();
        }
    }

    // LearningManager class
    class LearningManager
    {
        private List<Course> courses = new List<Course>();
        private List<Enrollment> enrollments = new List<Enrollment>();
        private List<StudentProgress> progresses = new List<StudentProgress>();
        private int enrollmentCounter = 1;

        // Add course
        public void AddCourse(string code, string name, string instructor,
                              int weeks, double price, List<string> modules)
        {
            Course course = new Course
            {
                CourseCode = code,
                CourseName = name,
                Instructor = instructor,
                DurationWeeks = weeks,
                Price = price,
                Modules = modules
            };

            courses.Add(course);
            Console.WriteLine("Course added successfully");
        }

        // Enroll student
        public bool EnrollStudent(string studentId, string courseCode)
        {
            Course course = courses.FirstOrDefault(c => c.CourseCode == courseCode);
            if (course == null)
                return false;

            Enrollment enrollment = new Enrollment
            {
                EnrollmentId = enrollmentCounter++,
                StudentId = studentId,
                CourseCode = courseCode,
                EnrollmentDate = DateTime.Now,
                ProgressPercentage = 0
            };

            enrollments.Add(enrollment);

            progresses.Add(new StudentProgress
            {
                StudentId = studentId,
                CourseCode = courseCode,
                LastAccessed = DateTime.Now
            });

            return true;
        }

        // Update progress
        public bool UpdateProgress(string studentId, string courseCode,
                                   string module, double score)
        {
            StudentProgress progress = progresses.FirstOrDefault(p =>
                p.StudentId == studentId && p.CourseCode == courseCode);

            if (progress == null)
                return false;

            progress.ModuleScores[module] = score;
            progress.LastAccessed = DateTime.Now;

            Enrollment enrollment = enrollments.First(e =>
                e.StudentId == studentId && e.CourseCode == courseCode);

            enrollment.ProgressPercentage =
                (progress.ModuleScores.Count * 100.0) /
                courses.First(c => c.CourseCode == courseCode).Modules.Count;

            return true;
        }

        // Group courses by instructor
        public Dictionary<string, List<Course>> GroupCoursesByInstructor()
        {
            return courses
                .GroupBy(c => c.Instructor)
                .ToDictionary(g => g.Key, g => g.ToList());
        }

        // Get top performing students
        public List<Enrollment> GetTopPerformingStudents(string courseCode, int count)
        {
            return enrollments
                .Where(e => e.CourseCode == courseCode)
                .OrderByDescending(e => e.ProgressPercentage)
                .Take(count)
                .ToList();
        }
    }

    // Program class
    class Program
    {
        static void Main()
        {
            LearningManager manager = new LearningManager();

            // Add course
            manager.AddCourse(
                "CS101",
                "C# Fundamentals",
                "John",
                6,
                4999,
                new List<string> { "Basics", "OOP", "Collections", "LINQ" }
            );

            // Enroll students
            manager.EnrollStudent("S1", "CS101");
            manager.EnrollStudent("S2", "CS101");

            // Update progress
            manager.UpdateProgress("S1", "CS101", "Basics", 90);
            manager.UpdateProgress("S1", "CS101", "OOP", 85);
            manager.UpdateProgress("S2", "CS101", "Basics", 70);

            // Group courses by instructor
            Console.WriteLine("\nCourses Grouped By Instructor:");
            var grouped = manager.GroupCoursesByInstructor();
            foreach (var g in grouped)
            {
                Console.WriteLine(g.Key);
                foreach (var c in g.Value)
                    Console.WriteLine(c.CourseName);
            }

            // Top performing students
            Console.WriteLine("\nTop Performing Students:");
            var top = manager.GetTopPerformingStudents("CS101", 2);
            foreach (var e in top)
                Console.WriteLine(e.StudentId + " - " + e.ProgressPercentage + "%");
        }
    }
}
