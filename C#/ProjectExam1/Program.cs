using ProjectExam1.Data;
using ProjectExam1.Model;

namespace ProjectExam1
{
    internal class Program
    {
        /// <summary>
        /// Application entry point. Retrieves students from the static DataBank
        /// and prints a simple listing to the console.
        /// </summary>
        /// <param name="args">Command-line arguments (not used).</param>
        static void Main(string[] args)
        {
            // Retrieve students from the in-memory data store
            var students = DataBank.GetStudents();

            // Write a header and then each student's Id and Name
            Console.WriteLine("Students:");
            foreach (var s in students)
            {
                // Format output consistently for easier reading and potential parsing
                Console.WriteLine($"| Id = {s.Id}|Name = {s.Name}");
            }

            var Sessions =  DataBank.GetStudentSessions();
            Console.WriteLine();
            Console.WriteLine("Sessions: ");
            foreach(var ss in Sessions)
            {
                Console.WriteLine($"| Id = {ss.Id}|Name = {ss.Name}");
            }

            var StudentSessions = DataBank.GetStudentAndSessions();
            Console.WriteLine();
            Console.WriteLine("StudentAndSessions: ");
            
            foreach (var sas in StudentSessions)
            {
                var studentId = sas.Student.Id.ToString() ?? "(no-student-id)";
                var studentName = sas.Student.Name ?? "(no-student-name)";
                var sessionId = sas.Session.Id.ToString() ?? "(no-session-id)";
                var sessionName = sas.Session.Name ?? "(no-session-name)";


                Console.WriteLine($"| StudentId = {studentId} | StudentName = {studentName} | SessionId = {sessionId} | SessionName = {sessionName}");
            }


        }

    }
}
