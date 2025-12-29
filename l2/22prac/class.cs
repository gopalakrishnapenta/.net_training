using System;
namespace OopsSession
{
    public class Associate
    {
        private int Id{get ; set;}
        private string Name{get ; set;}

        public string Error{get ; set;}

        public int ID
        {
            get { return Id; }
            set 
            {
                if(value <= 0)
                {
                    Error += "Id should be greater than zero. ";
                }
                Id = value; 
            }
        }
    }
}