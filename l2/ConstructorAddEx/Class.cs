using System;
using System.Data;

namespace ConstructorAdd
{
    public class ConstructorAddEx
    {
        public int A {get ; set ;}

        public int B {get ; set ;}

        public int Sum {get ;}

        public ConstructorAddEx(int a, int b)
        {
            this.A = a;
            this.B = b;
            this.Sum = a + b; // only in constructor GET can SET the value
        }
    }
}