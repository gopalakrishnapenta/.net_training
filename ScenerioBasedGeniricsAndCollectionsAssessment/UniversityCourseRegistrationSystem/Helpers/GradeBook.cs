using System;
using System.Collections.Generic;
using System.Linq;
using UniversityCourseRegistrationSystem.Models;
using UniversityCourseRegistrationSystem.Services;

namespace UniversityCourseRegistrationSystem.Helpers
{
    public class GradeBook<TStudent, TCourse>
        where TStudent : IStudent
        where TCourse : ICourse
    {
        private readonly EnrollmentSystem<TStudent, TCourse> _enrollmentSystem;
        private readonly Dictionary<(TStudent, TCourse), double> _grades = new();

        public GradeBook(EnrollmentSystem<TStudent, TCourse> enrollmentSystem)
        {
            _enrollmentSystem = enrollmentSystem;
        }

        public void AddGrade(TStudent student, TCourse course, double grade)
        {
            if (grade < 0 || grade > 100)
                throw new ArgumentOutOfRangeException(nameof(grade));

            if (!_enrollmentSystem.IsStudentEnrolled(student, course))
                throw new InvalidOperationException("Student not enrolled in course");

            _grades[(student, course)] = grade;
        }

        public double? CalculateGPA(TStudent student)
        {
            var records = _grades
                .Where(g => g.Key.Item1.StudentId == student.StudentId)
                .Select(g => new { g.Value, g.Key.Item2.Credits })
                .ToList();

            if (!records.Any()) return null;

            double total = records.Sum(r => r.Value * r.Credits);
            int credits = records.Sum(r => r.Credits);

            return total / credits;
        }

        public (TStudent student, double grade)? GetTopStudent(TCourse course)
        {
            var top = _grades
                .Where(g => EqualityComparer<TCourse>.Default.Equals(g.Key.Item2, course))
                .OrderByDescending(g => g.Value)
                .FirstOrDefault();

            return top.Equals(default(KeyValuePair<(TStudent, TCourse), double>))
                ? null
                : (top.Key.Item1, top.Value);
        }
    }
}
