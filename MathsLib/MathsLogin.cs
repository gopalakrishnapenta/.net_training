using CommonLib1;
using System;
using System.Collections.Generic;
using System.Text;

namespace MathsLib
{
    public class MathsLogin : LoginAbs
    {
        public override void Login(string UserName, string Password)
        {
            Console.WriteLine("Login Succesfull");
        }

        
    }
    public class MathsLogout : LogoutAbs
    {
        public override void Logout(string UserName, string Password)
        {
            Console.WriteLine("Logout Succesfull");
        }

    }
}
