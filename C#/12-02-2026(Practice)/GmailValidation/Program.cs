using System;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter an email address:");
        string? email = Console.ReadLine();

        if (email == null)
        {
            Console.WriteLine("Invalid Gmail");
            return;
        }

        string[] parts =  email.Split('@');


        if(parts.Length != 2)
        {
            Console.WriteLine("Invalid Gmail");
            return;
        }
        string beforeAt =  parts[0];
        string afterAt =  parts[1];

        if(beforeAt.Length > 256 || beforeAt.Length == 0)
        {
            Console.WriteLine("Invalid Gmail");
            return;
        }

        if(!afterAt.Equals("gmail.com"))
        {
            Console.WriteLine("Invalid Gmail");
            return;
        }

        char firstChar = beforeAt[0];
        if (firstChar == '.' || firstChar == '_' || firstChar == '-')
        {
            Console.WriteLine("Invalid Gmail");
            return;
        }


        foreach(char c in beforeAt)
        {
            if(!(char.IsLetterOrDigit(c) || c == '.' || c == '_' || c == '-'))
            {
                Console.WriteLine("Invalid Gmail");
                return;
            }

        }
       
        Console.WriteLine("Valid Gmail");
    }
}