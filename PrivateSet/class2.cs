namespace CollegeApp
{
    public partial class Student
    {
        public int Id;
        public string Name;

        public void DisplayBasicInfo()
        {
            Console.WriteLine($"ID: {Id}, Name: {Name}");
        }
    }
}
