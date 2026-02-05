using System;

namespace LibraryManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            LibraryUtility library = new LibraryUtility();

            library.AddBook("1984", "George Orwell", "Fiction", 1949);
            library.AddBook("Sapiens", "Yuval Noah Harari", "Non-Fiction", 2011);
            library.AddBook("The Hobbit", "J.R.R. Tolkien", "Fiction", 1937);
            library.AddBook("Sherlock Holmes", "Arthur Conan Doyle", "Mystery", 1892);

            var groupedBooks = library.GroupBooksByGenre();

            Console.WriteLine("Books Grouped by Genre:");
            foreach (var genre in groupedBooks)
            {
                Console.WriteLine($"\nGenre: {genre.Key}");
                foreach (var book in genre.Value)
                {
                    Console.WriteLine(book);
                }
            }

            Console.WriteLine("\nBooks by George Orwell:");
            foreach (var book in library.GetBooksByAuthor("George Orwell"))
            {
                Console.WriteLine(book);
            }

            Console.WriteLine($"\nTotal Books: {library.GetTotalBooksCount()}");
        }
    }
}
