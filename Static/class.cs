using System;
using Static;
namespace Static
{
    public static class GeneralUses
    {
        public static int Rno;
        static GeneralUses()
        {
            Rno=1;
        }
        public static int GetRno()
        {
            return Rno;
        }
        
    }
    
}