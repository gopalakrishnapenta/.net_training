using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectExam1.Model
{
    /// <summary>
    /// Represents a session (course/module) that a student can be associated with.
    /// Contains lightweight descriptive information for display purposes.
    /// </summary>
    public class StudentSession
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StudentSession"/> class.
        /// </summary>
        public StudentSession()
        {

        }

        /// <summary>
        /// Gets or sets the unique identifier for the session.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the short name of the session (for example: "Math").
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a brief description of the session contents or purpose.
        /// </summary>
        public string Detail { get; set; }

    }
}
