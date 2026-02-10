using System;
using UniversityCourseRegistrationSystem.Models;
using UniversityCourseRegistrationSystem.Services;
using UniversityCourseRegistrationSystem.Helpers;

class Program
{
    static void Main()
    {
        var enrollment = new EnrollmentSystem<EngineeringStudent, LabCourse>();
        var gradeBook = new GradeBook<EngineeringStudent, LabCourse>(enrollment);

        var s1 = new EngineeringStudent { StudentId = 1, Name = "Arjun", Semester = 4, Specialization = "CSE" };
        var s2 = new EngineeringStudent { StudentId = 2, Name = "Meera", Semester = 2, Specialization = "ECE" };
        var s3 = new EngineeringStudent { StudentId = 3, Name = "Ravi", Semester = 4, Specialization = "IT" };

        var c1 = new LabCourse
        {
            CourseCode = "CSL401",
            Title = "Advanced Networks Lab",
            Credits = 4,
            MaxCapacity = 2,
            RequiredSemester = 4
        };

        var c2 = new LabCourse
        {
            CourseCode = "CSL201",
            Title = "Basic Electronics Lab",
            Credits = 3,
            MaxCapacity = 1,
            RequiredSemester = 3
        };

        Console.WriteLine(enrollment.EnrollStudent(s1, c1, out var r1) + " → " + r1);
        Console.WriteLine(enrollment.EnrollStudent(s2, c1, out var r2) + " → " + r2);
        Console.WriteLine(enrollment.EnrollStudent(s3, c1, out var r3) + " → " + r3);

        gradeBook.AddGrade(s1, c1, 85);
        gradeBook.AddGrade(s3, c1, 92);

        Console.WriteLine($"GPA of {s1.Name}: {gradeBook.CalculateGPA(s1)}");

        var top = gradeBook.GetTopStudent(c1);
        Console.WriteLine($"Top student in {c1.Title}: {top?.student.Name} ({top?.grade})");
    }
}
