using System;

namespace OopsSession
{
    public class Person
    {
        public int id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
    }

    public class Man : Person
    {
        public string playing { get; set; }
    }

    public class Women : Person
    {
        public string playManage { get; set; }
    }

    public class Child : Person
    {
        public string schoolName { get; set; }
    }
}
