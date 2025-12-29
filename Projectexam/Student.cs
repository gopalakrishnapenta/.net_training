using System;
using System.Collections.Generic;
using System.Text;

namespace Projectexam
{
    /// <summary>
    /// Represents a student who may appear for examinations.
    /// </summary>
    public class Student
    {
        /// <summary>
        /// Unique identifier for the student.
        /// </summary>
        public int StudentId { get; set; }

        /// <summary>
        /// Full name of the student.
        /// </summary>
        public string StudentName { get; set; }

        /// <summary>
        /// The semester in which the student is currently enrolled.
        /// </summary>
        public Semester Semester { get; set; }
    }
}
