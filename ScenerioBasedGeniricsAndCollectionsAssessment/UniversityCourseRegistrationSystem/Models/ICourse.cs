namespace UniversityCourseRegistrationSystem.Models
{
    public interface ICourse
    {
        string CourseCode { get; }
        string Title { get; }
        int MaxCapacity { get; }
        int Credits { get; }
    }
}
