using System;
using System.Collections.Generic;

namespace BikeRentalApp
{
    class Program
    {
        // Given in the question
        public static SortedDictionary<int, Bike> bikeDetails =
            new SortedDictionary<int, Bike>();

        static void Main()
        {
            BikeUtility utility = new BikeUtility();
            int choice;

            do
            {
                Console.WriteLine("1. Add Bike Details:");
                Console.WriteLine("2. Group Bikes By Brand:");
                Console.WriteLine("3. Exit:");
                Console.WriteLine();
                Console.Write("Enter your choice:");

                choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                {
                    Console.Write("Enter the model:");
                    string model = Console.ReadLine();

                    Console.Write("Enter the brand:");
                    string brand = Console.ReadLine();

                    Console.Write("Enter the price per day:");
                    int price = Convert.ToInt32(Console.ReadLine());

                    utility.AddBikeDetails(model, brand, price);
                    Console.WriteLine();
                }
                else if (choice == 2)
                {
                    SortedDictionary<string, List<Bike>> grouped =
                        utility.GroupBikesByBrand();

                    foreach (var item in grouped)
                    {
                        Console.WriteLine(item.Key);

                        foreach (Bike bike in item.Value)
                        {
                            Console.WriteLine(bike.Model);
                        }

                        Console.WriteLine();
                    }
                }

            } while (choice != 3);
        }
    }
}
