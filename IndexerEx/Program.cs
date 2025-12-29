using System.Security.Cryptography.X509Certificates;

namespace IndexerEx
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student s1 = new Student() { Id = 1, Name = "Gopi" };
            s1[0] = "java";
            s1[1] = "python";
            s1[2] = "c";
            Console.WriteLine($"id= {s1.Id} name = {s1.Name} books = {s1[0]},{s1[1]},{s1[2]}");
        }

       
    }
}
