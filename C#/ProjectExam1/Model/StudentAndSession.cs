using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectExam1.Model
{
    /// <summary>
    /// Simple mapping object that pairs a <see cref="Student"/> with a <see cref="StudentSession"/>.
    /// Useful for presenting assignments or enrollments in the UI or reports.
    /// </summary>
    public class StudentAndSession
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StudentAndSession"/> class.
        /// </summary>
        public StudentAndSession()
        {

        }

        /// <summary>
        /// Gets or sets the student that is part of this mapping.
        /// </summary>
        public Student Student { get; set; }

        /// <summary>
        /// Gets or sets the session associated with the <see cref="Student"/>.
        /// </summary>
        public StudentSession Session { get; set; } 

    }
}
