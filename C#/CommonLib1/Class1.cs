using System.Reflection.Metadata.Ecma335;

namespace CommonLib1
{
    public abstract class LoginAbs
    {
        public abstract void Login(string UserName, string Password);
        

        public bool LoginProcess()
        {
            return true;
        }
    }
    public abstract class LogoutAbs
    {
        public abstract void Logout(string UserName, string Password);
        public bool LogoutProcess()
        {
            return true;
        }
    }
}
