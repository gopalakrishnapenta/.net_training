using System;
using System.Collections.Generic;

namespace Projectexam
{
    /// <summary>
    /// Program container: creates sample domain objects (Semester, HOD, Examiner, Room, Student, Exam)
    /// and prints a simple exam schedule to the console for demonstration purposes.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Application entry point.
        /// Constructs sample data and prints an exam schedule.
        /// </summary>
        /// <param name="args">Command-line arguments supplied to the application (unused).</param>
        static void Main(string[] args)
        {
            // Create a semester representing the academic term.
            Semester sem1 = new Semester { SemesterId = 1, SemesterName = "Sem1" };
            Semester sem2 = new Semester { SemesterId = 2, SemesterName = "Sem2" };

            // Create the Head of Department (HOD) who schedules the exams.
            HOD hod = new HOD { EmployeeID = 1, Name = "Gopi", Department = "CSE" };

            // Create two examiner instances who will conduct exams.
            Examiner examiner1 = new Examiner { EmployeeID = 2, Name = "Krishna", Department = "ECE" };
            Examiner examiner2 = new Examiner { EmployeeID = 3, Name = "Ravi", Department = "CSE" };

            // Create a room where all exams will be held (single-room demo).
            Room room = new Room { RoomNumber = 801 };

            // Create a small roster of students enrolled in the semester.
            List<Student> students = new List<Student>
                {
                    new Student { StudentId = 1, StudentName = "Alice", Semester = sem1 },
                    new Student { StudentId = 2, StudentName = "Bob", Semester = sem1 },
                    new Student { StudentId = 3, StudentName = "Charlie", Semester = sem2 },
                    new Student { StudentId = 4, StudentName = "David", Semester = sem2 },
                    new Student { StudentId = 5, StudentName = "Eva", Semester = sem1 },
                    new Student { StudentId = 6, StudentName = "Frank", Semester = sem1 }
                };

            // Define the schedule start time for the day's exams.
            DateTime startTime = new DateTime(2026, 1, 15, 9, 0, 0);

            // Create three exam entries that reuse the room and HOD but alternate examiners
            // and assign different student subsets to each exam.
            List<Exam> exams = new List<Exam>
                {
                    new Exam
                    {
                        ExamID = 1,
                        ExamName = "Python",
                        Room = room,
                        ExamDateTime = startTime,           // first slot: 09:00
                        Examiner = examiner1,
                        ScheduledBy = hod,
                        Semester = sem1,
                        Students = students.GetRange(0, 2)  // students 1..2
                    },
                    new Exam
                    {
                        ExamID = 2,
                        ExamName = "DSA",
                        Room = room,
                        ExamDateTime = startTime.AddHours(1), // second slot: 10:00
                        Examiner = examiner2,
                        ScheduledBy = hod,
                        Semester = sem2,
                        Students = students.GetRange(2, 2)   // students 3..4
                    },
                    new Exam
                    {
                        ExamID = 3,
                        ExamName = "EnvironmentalChemistry",
                        Room = room,
                        ExamDateTime = startTime.AddHours(2), // third slot: 11:00
                        Examiner = examiner1,
                        ScheduledBy = hod,
                        Semester = sem1,
                        Students = students.GetRange(4, 2)   // students 5..6
                    }
                };

            // Print a header then iterate through the exams and print details for each.
            Console.WriteLine("EXAM SCHEDULE\n");
            foreach (var exam in exams)
            {
                PrintExamSummary(exam);
                // Separator to visually distinguish exams in console output.
                Console.WriteLine("----------------------------------");
            }
        }

        /// <summary>
        /// Prints a formatted summary of an exam's details to the console.
        /// </summary>
        /// <param name="ex">Exam to be printed. Assumes non-null and populated properties for demo.</param>
        static void PrintExamSummary(Exam ex)
        {
            // Print core metadata fields with labels to make output readable.
            Console.WriteLine($"Exam ID      : {ex.ExamID}");                        // Numeric exam identifier
            Console.WriteLine($"Exam Name    : {ex.ExamName}");                      // Name or subject
            Console.WriteLine($"Date & Time  : {ex.ExamDateTime:yyyy-MM-dd HH:mm}");   // Scheduled datetime

            // Print location and staff information (Room, Examiner, ScheduledBy).
            // These properties are expected to be non-null in this demo code.
            Console.WriteLine($"Room         : {ex.Room.RoomNumber}");
            Console.WriteLine($"Examiner     : {ex.Examiner.Name}");
            Console.WriteLine($"Scheduled By : {ex.ScheduledBy.Name}");

            // Print the associated semester.
            Console.WriteLine($"Semester     : {ex.Semester.SemesterName}");

            // Print student list header then each student's id and name.
            Console.WriteLine("Students     :");
            foreach (var s in ex.Students)
            {
                // Each student line shows the id followed by the display name.
                Console.WriteLine($"   {s.StudentId} - {s.StudentName}");
            }
        }
    }
}
