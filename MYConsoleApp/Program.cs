using System.Reflection.PortableExecutable;

public class clac
{
    public bool IsEven(int number)
    {
        if(number % 2 == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
         
     }
     public static void Main(String[] args)
    {
        clac calculator = new clac();
        Console.Write("Enter a number: ");
        string? input = Console.ReadLine(); 
        if(int.TryParse(input, out int number))
        {
            bool result = calculator.IsEven(number);
            Console.WriteLine("Is the number even? " + result);
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a whole number.");
        }
    }
}