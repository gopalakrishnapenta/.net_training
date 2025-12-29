using System.Reflection.Metadata.Ecma335;

namespace CommonLib
{
    public abstract class LoginAbs
    {
        public abstract void Login(string UserName, string Password);
        
        public abstract void Logout();

        public class LoginProcess
        {
            
        }
    }
}
