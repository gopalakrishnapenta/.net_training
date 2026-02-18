using System;

namespace BookStoreApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Enter book details (BookID Title Price Stock): ");
            

            string[]? input = Console.ReadLine()?.Split(' ');

            Book book = new Book
            {
                Id = input?[0],
                Title = input?[1],
                Price = int.Parse(input?[2] ?? "0"),
                Stock = int.Parse(input?[3] ?? "0")
            };

            BookUtility utility = new BookUtility(book);

            Console.WriteLine("1. Display book details");
            Console.WriteLine("2. Update book price");
            Console.WriteLine("3. Update book stock");
            Console.WriteLine("4. Exit");

            while (true)
            {
               
                Console.WriteLine("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine() ?? "0");

                switch (choice)
                {
                    case 1:
                        utility.GetBookDetails();
                        break;

                    case 2:
                        
                        int newPrice = int.Parse(Console.ReadLine() ?? "0");
                        utility.UpdateBookPrice(newPrice);
                        break;

                    case 3:
                        
                        int newStock = int.Parse(Console.ReadLine() ?? "0");
                        utility.UpdateBookStock(newStock);
                        break;

                    case 4:
                        Console.WriteLine("Thank You");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
