using System;
namespace OopsSession
{
    public class Father
    {
        public virtual String InterestOn()
        {
            return "I am interested in business.";
        }
    }
    public class Son : Father
    {
        public override string InterestOn()
        {
            return "I am interested in sports.";
        }
    }
}