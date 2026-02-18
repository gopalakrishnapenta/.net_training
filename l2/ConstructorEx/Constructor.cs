using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
namespace OopsSession.ConstructorEx
{
    public class Visitor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Requirement {get; set; }

        public string LogHistory { get; set; }

        public Visitor()
        {
            LogHistory += $"object is created at {DateAndTime.Now.ToString()} {Environment.NewLine}";
        }

        public Visitor(int id) :this()
        {
            this.Id = id;
            LogHistory += $"id is created at {DateAndTime.Now.ToString()} {Environment.NewLine}";
            if (id<=0)
            {
                throw new ArgumentException("Id cannot contain 0");
            }
        }
        public Visitor(int id, string name) :this(id)
        {
            LogHistory += $"name is created at {DateAndTime.Now.ToString()} {Environment.NewLine}";
            if (name.ToLower().Contains("idiot"))
            {
                throw new ArgumentException("Dont type idiot in name");
            }
            this.Name = name;
        }
        public Visitor(int id, string name, string requirement) : this(id,name)
        {
            LogHistory += $"requirement is created at {DateAndTime.Now.ToString()} {Environment.NewLine}";
            this.Requirement = requirement;
        }
    }
}