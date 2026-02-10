using System.Collections.Generic;
using System.Linq;
using UniversityCourseRegistrationSystem.Models;

namespace UniversityCourseRegistrationSystem.Services
{
    public class EnrollmentSystem<TStudent, TCourse>
        where TStudent : IStudent
        where TCourse : ICourse
    {
        private readonly Dictionary<TCourse, List<TStudent>> _enrollments = new();

        public bool EnrollStudent(TStudent student, TCourse course, out string reason)
        {
            if (!_enrollments.ContainsKey(course))
                _enrollments[course] = new List<TStudent>();

            var students = _enrollments[course];

            if (students.Count >= course.MaxCapacity)
            {
                reason = "Course capacity reached";
                return false;
            }

            if (students.Any(s => s.StudentId == student.StudentId))
            {
                reason = "Student already enrolled";
                return false;
            }

            if (course is LabCourse lab && student.Semester < lab.RequiredSemester)
            {
                reason = "Student does not meet semester prerequisite";
                return false;
            }

            students.Add(student);
            reason = "Enrollment successful";
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

        public bool IsStudentEnrolled(TStudent student, TCourse course)
        {
            return _enrollments.ContainsKey(course) &&
                   _enrollments[course].Any(s => s.StudentId == student.StudentId);
        }
    }
}
