using System;

namespace OopsSession
{
    // Base class
    public class Person
    {
        public int id;
        public string name;
        public int age;

        public Person(int id, string name, int age)
        {
            this.id = id;
            this.name = name;
            this.age = age;
        }

        public virtual string getDetails()
        {
            return $"id is {id}, name is {name}, age is {age}";
        }
    }

    // Derived class: Man
    public class Man : Person
    {
        public string playing;

        public Man(int id, string name, int age, string playing)
            : base(id, name, age)
        {
            this.playing = playing;
        }

        public override string getDetails()
        {
            return base.getDetails() + $", playing is {playing}";
        }
    }

    // Derived class: Women
    public class Women : Person
    {
        public string playManage;

        public Women(int id, string name, int age, string playManage)
            : base(id, name, age)
        {
            this.playManage = playManage;
        }

        public override string getDetails()
        {
            return base.getDetails() + $", managing is {playManage}";
        }
    }

    // Derived class: Child
    public class Child : Person
    {
        public string schoolName;

        public Child(int id, string name, int age, string schoolName)
            : base(id, name, age)
        {
            this.schoolName = schoolName;
        }

        public override string getDetails()
        {
            return base.getDetails() + $", school is {schoolName}";
        }
    }
}
