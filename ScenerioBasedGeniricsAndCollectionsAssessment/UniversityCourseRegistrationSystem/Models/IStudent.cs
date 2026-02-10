namespace UniversityCourseRegistrationSystem.Models
{
    public interface IStudent
    {
        int StudentId { get; }
        string Name { get; }
        int Semester { get; }
    }
}
