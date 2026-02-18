using System;

class Program
{
    static void Main()
    {
        // Read cost price and selling price
        Console.Write("Enter Cost Price: ");
        double costPrice = double.Parse(Console.ReadLine());

        Console.Write("Enter Selling Price: ");
        double sellingPrice = double.Parse(Console.ReadLine());

        // Calculate profit or loss
        if (sellingPrice > costPrice)
        {
            double profit = sellingPrice - costPrice;
            Console.WriteLine("Profit Percentage = " + (profit / costPrice * 100));
        }
        else if (costPrice > sellingPrice)
        {
            double loss = costPrice - sellingPrice;
            Console.WriteLine("Loss Percentage = " + (loss / costPrice * 100));
        }
        else
        {
            Console.WriteLine("No Profit No Loss");
        }
    }
}
