using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryBookManagement
{
    public class Book
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public bool IsAvailable { get; set; } = true;
    }

    // Generic catalog class
    public class Catalog<T> where T : Book
    {
        private readonly List<T> _items = new();
        private readonly HashSet<string> _isbnSet = new();
        private readonly SortedDictionary<string, List<T>> _genreIndex = new();

        // Add item with genre indexing
        public bool AddItem(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            if (string.IsNullOrWhiteSpace(item.ISBN))
                throw new ArgumentException("Invalid ISBN");

            // Ensure ISBN uniqueness using HashSet
            if (!_isbnSet.Add(item.ISBN))
                return false; // duplicate ISBN

            _items.Add(item);

            // Add to genre index
            if (!_genreIndex.ContainsKey(item.Genre))
                _genreIndex[item.Genre] = new List<T>();

            _genreIndex[item.Genre].Add(item);

            return true;
        }

        // Indexer to get books by genre
        public List<T> this[string genre]
        {
            get
            {
                if (genre == null)
                    return new List<T>();

                return _genreIndex.ContainsKey(genre)
                    ? _genreIndex[genre]
                    : new List<T>();
            }
        }

        // Find books using LINQ
        public IEnumerable<T> FindBooks(Func<T, bool> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            return _items.Where(predicate);
        }
    }

    class Program
    {
        static void Main()
        {
            Catalog<Book> library = new Catalog<Book>();

            Book book1 = new Book
            {
                ISBN = "978-3-16-148410-0",
                Title = "C# Programming",
                Author = "John Sharp",
                Genre = "Programming"
            };

            Book book2 = new Book
            {
                ISBN = "978-1-23-456789-0",
                Title = "ASP.NET Core",
                Author = "Jane Doe",
                Genre = "Programming"
            };

            Book book3 = new Book
            {
                ISBN = "978-9-87-654321-0",
                Title = "History of India",
                Author = "R. Sharma",
                Genre = "History"
            };

            library.AddItem(book1);
            library.AddItem(book2);
            library.AddItem(book3);

            // Test 1: Genre indexer
            var programmingBooks = library["Programming"];
            Console.WriteLine("Programming Books Count: " + programmingBooks.Count); // 2

            // Test 2: LINQ search
            var johnsBooks = library.FindBooks(b => b.Author.Contains("John"));
            Console.WriteLine("Books by John: " + johnsBooks.Count()); // 1

            // Test 3: Duplicate ISBN
            bool addedDuplicate = library.AddItem(book1);
            Console.WriteLine("Duplicate Added? " + addedDuplicate); // false
        }
    }
}
