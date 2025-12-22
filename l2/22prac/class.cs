using System;
namespace OopsSession
{
    public class Associate
    {
        public int Id{get ; set;}
        public string Name{get ; set;}

        public Associate(int id, string name)
        {
            if(id <= 0)
            {
                throw new InvalidDataException("Id must be greater than zero");
            }
            if(name == string.Empty || name == null)
            {
                throw new InvalidDataException("Name cannot be null");
            }
            this.Id = id;
            this.Name = name;
        }
    }
}