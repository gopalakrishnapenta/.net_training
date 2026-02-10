namespace UniversityCourseRegistrationSystem.Models
{
    public class LabCourse : ICourse
    {
        public string CourseCode { get; set; }
        public string Title { get; set; }
        public int MaxCapacity { get; set; }
        public int Credits { get; set; }
        public string LabEquipment { get; set; }
        public int RequiredSemester { get; set; }

        public override string ToString()
            => $"{CourseCode} - {Title}";
    }
}
        