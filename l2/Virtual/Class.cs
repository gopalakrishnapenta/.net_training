using System;
namespace OopsSession
{
    public class Father
    {
        public virtual String InterestOn()  // virutal uses to skip this method whemever we want to override in derived class
        {
            return "I am interested in business.";
        }
    }
    public class Son : Father
    {
        public override string InterestOn() // overide keyword is used to skip the base class method
        {
            return "I am interested in sports.";
        }
    }
}