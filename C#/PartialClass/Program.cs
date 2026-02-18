using System;
using System.Data.Common;

namespace CollegeApp
{
    class Program
    {
        static void Main()
        {
            Student s = new Student();
            s.Id = 101;
            s.Name = "Somu";
            s.Marks = 85;

           /// s.DisplayBasicInfo();
            s.DisplayMarks();
        }
    }
}
