using System;
public class ElectricityBill
{
    public static void Main(String[] args)
    {
        Console.WriteLine("Enter the number of units consumed:");
        String inputUnits = Console.ReadLine();

        if (int.TryParse(inputUnits, out int unitsConsumed))
        {
            double billAmount = 0;

            if (unitsConsumed <= 100)
            {
                billAmount = unitsConsumed * 0.5;
            }
            else if (unitsConsumed <= 200)
            {
                billAmount = (100 * 0.5) + ((unitsConsumed - 100) * 0.75);
            }
            else if (unitsConsumed <= 300)
            {
                billAmount = (100 * 0.5) + (100 * 0.75) + ((unitsConsumed - 200) * 1.20);
            }
            else
            {
                billAmount = (100 * 0.5) + (100 * 0.75) + (100 * 1.20) + ((unitsConsumed - 300) * 1.50);
            }

            // Adding a surcharge of 20% on the total bill amount
            billAmount += billAmount * 0.20;

            Console.WriteLine($"The total electricity bill for {unitsConsumed} units is: {billAmount:C2}");
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number of units.");
        }
    }
}