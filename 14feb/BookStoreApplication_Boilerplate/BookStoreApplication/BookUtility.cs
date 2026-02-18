using System;
using System.Xml.Linq;

namespace BookStoreApplication
{
    public class BookUtility
    {
        private Book _book;

        public BookUtility(Book book)
        {
           
            _book = book;
        }

        public void GetBookDetails()
        {
          
            Console.WriteLine($"Details: {_book.Id} {_book.Title} {_book.Title} {_book.Price} {_book.Stock}");
            
        }

        public void UpdateBookPrice(int newPrice)
        {
            
            if(newPrice < 0) 
            {
                Console.WriteLine("Price cannot be negative.");
                return;
            }

            _book.Price = newPrice;
            Console.WriteLine($"Updated Price: {_book.Price}");

            
        }

        public void UpdateBookStock(int newStock)
        {
            
            if (newStock<0)
            {
                Console.WriteLine("Stock cannot be negative. ");
                return;
            }
            _book.Stock = newStock;
            Console.WriteLine($"Updated Stock: {_book.Stock}");
            
        }
    }
}
