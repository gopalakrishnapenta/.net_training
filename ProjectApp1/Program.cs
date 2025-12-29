using MathsLib;
using ScienceLib;

namespace ProjectApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Algebra a1 = new Algebra();
            Console.WriteLine(a1.Add(3, 4));
            AeroScience s1 = new AeroScience();
            Console.WriteLine(s1.Sci(3, 4));
            ScienceLogin scienceLogin = new ScienceLogin();
            scienceLogin.Login("Gopi ", "123Gopi");
            MathsLogout mathsLogout = new MathsLogout();
            mathsLogout.Logout("krishna", "123r");


        }
    }
}
