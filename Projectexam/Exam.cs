using System;
using System.Collections.Generic;
using System.Text;

namespace Projectexam
{
    /// <summary>
    /// Represents an exam event, including scheduling metadata, participants and location.
    /// </summary>
    public class Exam
    {
        /// <summary>
        /// Unique identifier for the exam.
        /// </summary>
        public int ExamID { get; set; }

        /// <summary>
        /// Human-readable name for the exam (e.g. MID, ENDSEM).
        /// </summary>
        public string ExamName { get; set; }

        /// <summary>
        /// Scheduled date and time for the exam occurrence.
        /// </summary>
        public DateTime ExamDateTime { get; set; }

        /// <summary>
        /// Semester to which this exam belongs.
        /// </summary>
        public Semester Semester { get; set; }

        /// <summary>
        /// Room where the exam will be held.
        /// </summary>
        public Room Room { get; set; }

        /// <summary>
        /// Examiner assigned to the exam.
        /// </summary>
        public Examiner Examiner { get; set; }

        /// <summary>
        /// Head of department or staff member who scheduled the exam.
        /// </summary>
        public HOD ScheduledBy { get; set; }

        /// <summary>
        /// List of students assigned to sit for this exam.
        /// </summary>
        public List<Student> Students { get; set; }

        // Obsolete constructor kept for reference; prefer object initializer for readability.
        //public Exam(int examId, string examName, DateTime examDateTime, Semester semester, Room room, Examiner examiner,HOD scheduledBy) { 
        //    this.ExamID = examId;
        //    this.ExamName = examName;
        //    this.ExamDateTime = examDateTime;
        //    this.Semester = semester;
        //    this.Room = room;
        //    this.Examiner = examiner;
        //    this.ScheduledBy = scheduledBy;
        //}
    }
}
