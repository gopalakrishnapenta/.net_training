using CommonLib1;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace ScienceLib
{
    public class ScienceLogin : LoginAbs
    {
        public override void Login(string UserName, string Password)
        {
            Console.WriteLine("Login Succesfull");
        }


    }
    public class ScienceLogout : LogoutAbs
    {
        public override void Logout(string Username, string Password)
        {
            throw new NotImplementedException();
        }
    }
}
