using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace JsonSerializationDemo
{
    // Model class
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create object
            Student student = new Student
            {
                Id = 1,
                Name = "Gopal",
                Age = 22
            };

            /// <summary>
            /// Serializes the student object to a JSON string.
            /// </summary>
            /// <returns>JSON string representation of the student object.</returns>
            string jsonString = JsonSerializer.Serialize(student);
            Console.WriteLine("Serialized JSON:");
            Console.WriteLine(jsonString);

        
            /// <summary>
            /// Deserializes the JSON string from the file to a Student object.
            /// </summary>
            /// <returns>Student object deserialized from the JSON string.</returns>
            string jsonFromFile = File.ReadAllText("student.json");

            Student deserializedStudent =
                JsonSerializer.Deserialize<Student>(jsonFromFile);

            Console.WriteLine("\nDeserialized Object:");
            Console.WriteLine("Id: " + deserializedStudent.Id);
            Console.WriteLine("Name: " + deserializedStudent.Name);
            Console.WriteLine("Age: " + deserializedStudent.Age);

        }
    }
}
