using System;
using System.Dynamic;
using System.Runtime.InteropServices;
namespace OopsSession
{
    public class Student
    {
        public int StudentId{ get ; private set ;}

        public string Name { get; set; }
        private int age;
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if(value > 0)
                {
                    age = value;
                }
                else
                {
                    Console.WriteLine("Age should greate rthan Zero");
                }
            }
            
        }
        private int marks;
        public int Marks
        {
            get
            {
                return marks;
            }
            set
            {
                if(value>=0 && value <= 100)
                {
                    marks = value;
                }
                else
                {
                    Console.WriteLine("Marks must be between 0 and 100");
                }
            }
        }
        public string  Grade
        {
            get
            {
                if(Marks>=75) return "A";
                else if(Marks>=60) return "B";
                else if(Marks>=40) return "C";
                else return "fail";
            }
        }
        public Student(int id)
        {
            StudentId = id;
        }

    }
}