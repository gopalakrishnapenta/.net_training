    using System;
    using System.Runtime.InteropServices;
    public class Studentrecord
    {
        public class Student
    {
        public string name;
        public int id;
        public Student(string name,int id)
        {
            this.name=name;
            this.id=id;
        }
        public string getStudent()
        {
            return "Name: "+name+" ID: "+id;
        }
    }
        public class HighschoolStudent :Student
        {
            
            public int classlevel;
        
        public HighschoolStudent(string name, int id, int classlevel) : base(name, id)
        {
            this.classlevel = classlevel;
        }
        public string getHighschoolStudent()
        {
            return "Name: " + name + " ID: " + id + " Class Level: " + classlevel;
        }
        }


        public class UgStudent :Student
        {
            public string year;

        public UgStudent(string name, int id, string year): base(name, id)
            {

                this.year = year;
            }
        public string getUgStudent()
            {
                return "Name: " + name + " ID: " + id + " Year: " + year;
            }
        }
        public class PgStudent :Student
        {
            public string year;
        public PgStudent(string name, int id, string year) : base(name, id)
            {
                this.year = year;
            }
        public string getPgStudent()
            {
                return "Name: " + name + " ID: " + id + " Year: " + year;
            }
        }
        
        public static void Main(String[] args)
        {
            HighschoolStudent[] hsSt = new HighschoolStudent[3];
            hsSt[0] = new HighschoolStudent("John", 123, 10);
            hsSt[1] = new HighschoolStudent("Alice", 124, 11);
            hsSt[2] = new HighschoolStudent("Bob", 125, 12);

            UgStudent[] ugSt = new UgStudent[3];
            ugSt[0] = new UgStudent("David", 201, "First");
            ugSt[1] = new UgStudent("Eva", 202, "Second");
            ugSt[2] = new UgStudent("Frank", 203, "Third");

            PgStudent[] pgSt =new PgStudent[3];
            pgSt[0] = new PgStudent("Grace", 301, "First"); 
            pgSt[1] = new PgStudent("Hannah", 302, "Second");
            pgSt[2] = new PgStudent("Ian", 303, "Third");

            Console.WriteLine("High School Students:");
            foreach(HighschoolStudent hs in hsSt)
            {
                Console.WriteLine(hs.getHighschoolStudent());
            }

            Console.WriteLine("\nUndergraduate Students:");
            foreach(UgStudent ug in ugSt)
            {
                Console.WriteLine(ug.getUgStudent());
            }

            Console.WriteLine("\nPostgraduate Students:");
            foreach(PgStudent pg in pgSt)
            {
                Console.WriteLine(pg.getPgStudent());
            }

        }
    }