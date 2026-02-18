using System;

namespace OopsSession
{
    public class Program
    {
        public string getDetails(Person p)
        {
            if (p is Man m)
            {
                return $"id is {m.id}, name is {m.name}, age is {m.age}, playing is {m.playing}";
            }
            else if (p is Women w)
            {
                return $"id is {w.id}, name is {w.name}, age is {w.age}, managing is {w.playManage}";
            }
            else if (p is Child c)
            {
                return $"id is {c.id}, name is {c.name}, age is {c.age}, school is {c.schoolName}";
            }
            else
            {
                return $"id is {p.id}, name is {p.name}, age is {p.age}";
            }
        }

        public static void Main(string[] args)
        {
            Program program = new Program();

            Person person = new Person { id = 1, name = "John", age = 23 };
            Person p1 = new Man { id = 2, name = "Robert", age = 30, playing = "Cricket" };
            Person p2 = new Women { id = 3, name = "Alice", age = 28, playManage = "Football" };
            Person p3 = new Child { id = 4, name = "Bob", age = 10, schoolName = "ABC School" };

            Console.WriteLine(program.getDetails(person));
            Console.WriteLine(program.getDetails(p1));
            Console.WriteLine(program.getDetails(p2));
            Console.WriteLine(program.getDetails(p3));
        }
    }
}
