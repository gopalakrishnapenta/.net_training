using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectExam1.Model
{
    /// <summary>
    /// Represents a student with a numeric identifier and a display name.
    /// </summary>
    


    public class Student
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Student"/> class.
        /// Default constructor required for serialization and simple creation.
        /// </summary>
        public Student()        
        {

        }

        /// <summary>
        /// Gets or sets the unique identifier for the student.
        /// Should be unique within the application's scope.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the student's full name or display name.
        /// This value is intended for UI display and logging.
        /// </summary>
        public string Name { get; set; }


    }
    
}
