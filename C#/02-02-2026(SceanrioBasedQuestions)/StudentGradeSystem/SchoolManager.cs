    using System.Collections.Generic;

namespace StudentGradeSystem
{
    public class SchoolManager
    {
        private List<Student> students = new List<Student>();
        private int studentCounter = 1;

        // Add student
        public void AddStudent(string name, string gradeLevel)
        {
            Student student = new Student();
            student.StudentId = studentCounter;
            student.Name = name;
            student.GradeLevel = gradeLevel;

            students.Add(student);
            studentCounter++;
        }

        // Add grade for student
        public void AddGrade(int studentId, string subject, double grade)
        {
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].StudentId == studentId)
                {
                    if (grade >= 0 && grade <= 100)
                    {
                        students[i].Subjects[subject] = grade;
                    }
                    return;
                }
            }
        }

        // Group students by grade level
        public SortedDictionary<string, List<Student>> GroupStudentsByGradeLevel()
        {
            SortedDictionary<string, List<Student>> result =
                new SortedDictionary<string, List<Student>>();

            foreach (Student student in students)
            {
                if (!result.ContainsKey(student.GradeLevel))
                {
                    result[student.GradeLevel] = new List<Student>();
                }
                result[student.GradeLevel].Add(student);
            }

            return result;
        }

        // Calculate student average
        public double CalculateStudentAverage(int studentId)
        {
            foreach (Student student in students)
            {
                if (student.StudentId == studentId)
                {
                    if (student.Subjects.Count == 0)
                        return 0;

                    double total = 0;
                    int count = 0;

                    foreach (double grade in student.Subjects.Values)
                    {
                        total += grade;
                        count++;
                    }
                    return total / count;
                }
            }
            return 0;
        }

        // Calculate subject-wise averages
        public Dictionary<string, double> CalculateSubjectAverages()
        {
            Dictionary<string, double> totals = new Dictionary<string, double>();
            Dictionary<string, int> counts = new Dictionary<string, int>();

            foreach (Student student in students)
            {
                foreach (var subject in student.Subjects)
                {
                    if (!totals.ContainsKey(subject.Key))
                    {
                        totals[subject.Key] = 0;
                        counts[subject.Key] = 0;
                    }

                    totals[subject.Key] += subject.Value;
                    counts[subject.Key]++;
                }
            }

            Dictionary<string, double> averages = new Dictionary<string, double>();
            foreach (var subject in totals)
            {
                averages[subject.Key] = subject.Value / counts[subject.Key];
            }

            return averages;
        }

        // Get top N performers
        public List<Student> GetTopPerformers(int count)
        {
            List<Student> sorted = new List<Student>(students);

            // Bubble sort by average
            for (int i = 0; i < sorted.Count - 1; i++)
            {
                for (int j = i + 1; j < sorted.Count; j++)
                {
                    double avg1 = CalculateStudentAverage(sorted[i].StudentId);
                    double avg2 = CalculateStudentAverage(sorted[j].StudentId);

                    if (avg2 > avg1)
                    {
                        Student temp = sorted[i];
                        sorted[i] = sorted[j];
                        sorted[j] = temp;
                    }
                }
            }

            List<Student> top = new List<Student>();
            for (int i = 0; i < count && i < sorted.Count; i++)
            {
                top.Add(sorted[i]);
            }

            return top;
        }
    }
}
