using System;
using System.Collections.Generic;
using System.Linq;

namespace UniversityCourseRegistration
{
    #region INTERFACES

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

    #endregion

    #region ENTITIES

    public class EngineeringStudent : IStudent
    {
        public int StudentId { get; set; }
        public required string Name { get; set; }
        public int Semester { get; set; }
        public required string Specialization { get; set; }

        public override string ToString()
            => $"{StudentId} - {Name} (Sem {Semester})";

        public override bool Equals(object? obj)
            => obj is EngineeringStudent other && StudentId == other.StudentId;

        public override int GetHashCode()
            => StudentId.GetHashCode();
    }

    public class LabCourse : ICourse
    {
        public required string CourseCode { get; set; }
        public required string Title { get; set; }
        public int MaxCapacity { get; set; }
        public int Credits { get; set; }

        public required string LabEquipment { get; set; }
        public int RequiredSemester { get; set; }

        public override string ToString()
            => $"{CourseCode} - {Title}";

        public override bool Equals(object? obj)
            => obj is LabCourse other && CourseCode == other.CourseCode;

        public override int GetHashCode()
            => CourseCode.GetHashCode();
    }

    #endregion

    #region ENROLLMENT SYSTEM

    public class EnrollmentSystem<TStudent, TCourse>
        where TStudent : IStudent
        where TCourse : ICourse
    {
        private readonly Dictionary<TCourse, List<TStudent>> _enrollments = new();

        public bool EnrollStudent(TStudent student, TCourse course, out string reason)
        {
            if (!_enrollments.ContainsKey(course))
                _enrollments[course] = new List<TStudent>();

            if (_enrollments[course].Count >= course.MaxCapacity)
            {
                reason = "Failed: Course at full capacity.";
                return false;
            }

            if (_enrollments[course].Any(s => s.StudentId == student.StudentId))
            {
                reason = "Failed: Student already enrolled.";
                return false;
            }

            if (course is LabCourse lab && student.Semester < lab.RequiredSemester)
            {
                reason = "Failed: Semester prerequisite not met.";
                return false;
            }

            _enrollments[course].Add(student);
            reason = "Enrollment successful.";
            return true;
        }

        public IReadOnlyList<TStudent> GetEnrolledStudents(TCourse course)
        {
            return _enrollments.ContainsKey(course)
                ? _enrollments[course].AsReadOnly()
                : new List<TStudent>().AsReadOnly();
        }

        public IEnumerable<TCourse> GetStudentCourses(TStudent student)
        {
            return _enrollments
                .Where(e => e.Value.Any(s => s.StudentId == student.StudentId))
                .Select(e => e.Key);
        }

        public int CalculateStudentWorkload(TStudent student)
        {
            return GetStudentCourses(student).Sum(c => c.Credits);
        }
    }

    #endregion

    #region GRADEBOOK

    public class GradeBook<TStudent, TCourse>
        where TStudent : IStudent
        where TCourse : ICourse
    {
        private readonly Dictionary<(TStudent, TCourse), double> _grades = new();
        private readonly EnrollmentSystem<TStudent, TCourse> _enrollment;

        public GradeBook(EnrollmentSystem<TStudent, TCourse> enrollment)
        {
            _enrollment = enrollment;
        }

        public void AddGrade(TStudent student, TCourse course, double grade)
        {
            if (grade < 0 || grade > 100)
                throw new ArgumentException("Grade must be between 0 and 100.");

            if (!_enrollment.GetStudentCourses(student).Contains(course))
                throw new InvalidOperationException("Student not enrolled in course.");

            _grades[(student, course)] = grade;
        }

        public double? CalculateGPA(TStudent student)
        {
            var studentGrades = _grades
                .Where(g => g.Key.Item1.StudentId == student.StudentId)
                .ToList();

            if (!studentGrades.Any())
                return null;

            double totalWeighted = 0;
            int totalCredits = 0;

            foreach (var entry in studentGrades)
            {
                totalWeighted += entry.Value * entry.Key.Item2.Credits;
                totalCredits += entry.Key.Item2.Credits;
            }

            return totalCredits == 0 ? null : totalWeighted / totalCredits;
        }

        public (TStudent student, double grade)? GetTopStudent(TCourse course)
        {
            var courseGrades = _grades
                .Where(g => EqualityComparer<TCourse>.Default.Equals(g.Key.Item2, course))
                .ToList();

            if (!courseGrades.Any())
                return null;

            var top = courseGrades.OrderByDescending(g => g.Value).First();
            return (top.Key.Item1, top.Value);
        }
    }

    #endregion

    #region TEST SCENARIO

    class Program
    {
        static void Main()
        {
            var enrollment = new EnrollmentSystem<EngineeringStudent, LabCourse>();
            var gradebook = new GradeBook<EngineeringStudent, LabCourse>(enrollment);

            // a) Create students
            var s1 = new EngineeringStudent { StudentId = 1, Name = "Alice", Semester = 3, Specialization = "CSE" };
            var s2 = new EngineeringStudent { StudentId = 2, Name = "Bob", Semester = 1, Specialization = "ECE" };
            var s3 = new EngineeringStudent { StudentId = 3, Name = "Charlie", Semester = 4, Specialization = "IT" };

            // b) Create courses
            var c1 = new LabCourse
            {
                CourseCode = "CS301",
                Title = "Advanced Programming Lab",
                Credits = 4,
                MaxCapacity = 2,
                LabEquipment = "High-end PCs",
                RequiredSemester = 3
            };

            var c2 = new LabCourse
            {
                CourseCode = "CS101",
                Title = "Basic Electronics Lab",
                Credits = 3,
                MaxCapacity = 3,
                LabEquipment = "Electronics Kit",
                RequiredSemester = 1
            };

            Console.WriteLine("=== ENROLLMENT DEMO ===");

            Enroll(enrollment, s1, c1);
            Enroll(enrollment, s2, c1); // prerequisite fail
            Enroll(enrollment, s3, c1);
            Enroll(enrollment, s3, c1); // capacity fail
            Enroll(enrollment, s2, c2);

            Console.WriteLine("\n=== GRADE ASSIGNMENT ===");

            gradebook.AddGrade(s1, c1, 85);
            gradebook.AddGrade(s3, c1, 92);
            gradebook.AddGrade(s2, c2, 78);

            Console.WriteLine($"\nAlice GPA: {gradebook.CalculateGPA(s1)}");
            Console.WriteLine($"Charlie GPA: {gradebook.CalculateGPA(s3)}");

            var top = gradebook.GetTopStudent(c1);
            if (top.HasValue)
                Console.WriteLine($"\nTop student in {c1.Title}: {top.Value.student.Name} ({top.Value.grade})");

            Console.WriteLine($"\nAlice Workload: {enrollment.CalculateStudentWorkload(s1)} credits");
        }

        static void Enroll(
            EnrollmentSystem<EngineeringStudent, LabCourse> system,
            EngineeringStudent student,
            LabCourse course)
        {
            bool result = system.EnrollStudent(student, course, out string reason);
            Console.WriteLine($"{student.Name} -> {course.CourseCode}: {reason}");
        }
    }

    #endregion
}
