using ProjectExam1.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Runtime;
using System.Text;

namespace ProjectExam1.Data
{
    /// <summary>
    /// In-memory data holder for the sample application.
    /// Provides a simple, static data source for students and related read access methods.
    /// </summary>
    public static class DataBank
    {
        /// <summary>
        /// Backing store for students. Exposed for read-only consumption via <see cref="GetStudents"/>.
        /// </summary>
        public static List<Student> Students = new List<Student>();
        
        public static List<StudentSession> Sessions = new List<StudentSession>();

        public static List<StudentAndSession> StudentAndSessions = new List<StudentAndSession>();

        /// <summary>
        /// Static constructor populates the in-memory collections with sample data.
        /// This executes once per AppDomain when the type is first referenced.
        /// </summary>
        static DataBank()
        {
            Students.Add(new Student() { Id = 1, Name = "Gopi" });
            Students.Add(new Student() { Id = 2, Name = "Jotham" });
            Students.Add(new Student() { Id = 3, Name = "Shahid" });
            Students.Add(new Student() { Id = 4, Name = "Yaswanth" });

            Sessions.Add(new StudentSession() { Id = 1, Name = "CSE", Detail = "CSE session" });
            Sessions.Add(new StudentSession() { Id = 2, Name = "ECE", Detail = "ECE session " });
            Sessions.Add(new StudentSession() { Id = 3, Name = "ECE", Detail = "ECE session" });
            Sessions.Add(new StudentSession() { Id = 4, Name = "ECE", Detail = "ECE session" });
            //StudentAndSessions.Add(new StudentAndSession() {Student = Student,Session = Session });
            StudentAndSessions.Clear();
            if (Sessions.Count > 0)
            {
                for (int i = 0; i < Students.Count; i++)
                {
                    var student = Students[i];
                    var session = Sessions[i % Sessions.Count];
                    StudentAndSessions.Add(new StudentAndSession
                    {
                        Student = student,
                        Session = session
                    });
                }
            }
        }

        /// <summary>
        /// Returns the list of students. Caller should not assume modification safety.
        /// If callers require immutability, return a copy or a read-only wrapper.
        /// </summary>
        /// <returns>List of <see cref="Student"/> instances currently stored in-memory.</returns>
        public static List<Student> GetStudents()
        {
            return Students;
        }
        public static List<StudentSession> GetStudentSessions()
        {
            return Sessions;
        }
        public static List<StudentAndSession> GetStudentAndSessions()
        {
            return StudentAndSessions;
        }   

    }
}
