public class Program
{
    public static void Main()
    {
        Console.Write("Enter cab type (Mini / Sedan / SUV): ");
        string cabType = Console.ReadLine();

        Console.Write("Enter distance (km): ");
        int km = Convert.ToInt32(Console.ReadLine());

        Cab cab = null;

        if (cabType == "Mini")
        {
            cab = new Mini();
        }
        else if (cabType == "Sedan")
        {
            cab = new Sedan();
        }
        else if (cabType == "SUV")
        {
            cab = new Suv();
        }
        else
        {
            Console.WriteLine("Invalid cab type");
            return;
        }

        double fare = cab.CalculateFare(km);
        Console.WriteLine("Total Fare: " + fare);
    }
}
