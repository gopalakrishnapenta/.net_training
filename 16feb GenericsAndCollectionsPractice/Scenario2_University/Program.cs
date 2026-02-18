using System;
using System.Collections.Generic;
using System.Linq;

namespace Scenario2_University
{
    public interface IStudent
    {
        int StudentId { get; }
        string Name { get; }
        int Semester { get; }
    }

    public interface ICourse
    {
        string CourseCode { get; }
        string Title { get; }
        int MaxCapacity { get; }
        int Credits { get; }
    }

    public class EnrollmentSystem<TStudent, TCourse>
        where TStudent : IStudent
        where TCourse : ICourse
    {
        private readonly Dictionary<TCourse, List<TStudent>> _data = new();

        public bool EnrollStudent(TStudent student, TCourse course)
        {
            if (!_data.ContainsKey(course))
                _data[course] = new List<TStudent>();

            if (_data[course].Count >= course.MaxCapacity)
                return false;

            if (_data[course].Any(s => s.StudentId == student.StudentId))
                return false;

            if (course is LabCourse lab && student.Semester < lab.RequiredSemester)
                return false;

            _data[course].Add(student);
            return true;
        }

        public int CalculateStudentWorkload(TStudent student)
            => _data.Where(x => x.Value.Contains(student))
                    .Sum(x => x.Key.Credits);
    }

    public class EngineeringStudent : IStudent
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int Semester { get; set; }
        public string Specialization { get; set; }
    }

    public class LabCourse : ICourse
    {
        public string CourseCode { get; set; }
        public string Title { get; set; }
        public int MaxCapacity { get; set; }
        public int Credits { get; set; }
        public int RequiredSemester { get; set; }
    }

    class Program
    {
        static void Main()
        {
            var system = new EnrollmentSystem<EngineeringStudent, LabCourse>();

            var s1 = new EngineeringStudent { StudentId = 1, Name = "Arjun", Semester = 3 };
            var s2 = new EngineeringStudent { StudentId = 2, Name = "Ravi", Semester = 1 };

            var c1 = new LabCourse { CourseCode = "CS101", Title = "Programming Lab", Credits = 4, MaxCapacity = 2, RequiredSemester = 2 };

            Console.WriteLine(system.EnrollStudent(s1, c1)); // true
            Console.WriteLine(system.EnrollStudent(s2, c1)); // false (prerequisite)

            Console.WriteLine("Workload: " + system.CalculateStudentWorkload(s1));
        }
    }
}
