namespace CollegeApp
{
    public partial class Student
    {
        public int Marks;
        public void DisplayMarks()
        {
            Console.WriteLine($"id = {Id}, name : {Name}, Marks: {Marks}");
        }
    }
}
