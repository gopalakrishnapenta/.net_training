using System;
namespace OopsSession.ConstructorEx
{
    public class Visitor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Requirement {get; set; }

        public Visitor(int id)
        {
            Id = id;
        }
        public Visitor(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public Visitor(int id, string name, string requirement)
        {
            Id = id;
            Name = name;
            Requirement = requirement;
        }
    }
}