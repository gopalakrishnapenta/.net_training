using System;
using System.Collections.Generic;
using System.Text;

namespace IndexerEx
{
    public class Student
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        private string[] Books = new string[4];
        public string this[int index]
        {
            get
            {
                return Books[index]; 
            }
            set
            {
                Books[index] = value;
            }
        }


    }
}
