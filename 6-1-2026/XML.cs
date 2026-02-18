using System;
using System.IO;
using System.Xml.Serialization;

class Program
{
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    static void Main()
    {
        
        /// <summary>
        /// Creates a new student object and serializes it to XML.
        /// </summary>
        /// <value></value>
        #region Create Student Object
        Student student = new Student
        {
            Id = 1,
            Name = "Gopal",
            Age = 22
        };
        #endregion
        #region XML Serialization
        /// <summary>
        /// Serializes the student object to XML.
        /// </summary>
        /// <returns>XML string representation of the student object</returns>

        XmlSerializer serializer = new XmlSerializer(typeof(Student));
        /// <summary>
        /// Serializes the student object to XML.
        /// </summary>
        /// <param name="writer">The StringWriter to write the XML to.</param>
        /// <returns>None</returns>
        using (StringWriter writer = new StringWriter())
        {
            
            serializer.Serialize(writer, student);
            string xml = writer.ToString();
            Console.WriteLine(xml);
        }
        #endregion
    }
    
}
