using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagementSystem
{
    public class LibraryUtility
    {
        private readonly List<Book> books = new List<Book>();
        private int nextId = 1;

        public void AddBook(string title, string author, string genre, int year)
        {
            books.Add(new Book
            {
                Id = nextId++,
                Title = title,
                Author = author,
                Genre = genre,
                PublicationYear = year
            });
        }

        public SortedDictionary<string, List<Book>> GroupBooksByGenre()
        {
            return new SortedDictionary<string, List<Book>>(
                books.GroupBy(b => b.Genre)
                     .ToDictionary(g => g.Key, g => g.ToList())
            );
        }

        public List<Book> GetBooksByAuthor(string author)
        {
            return books
                .Where(b => b.Author.Equals(author, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public int GetTotalBooksCount()
        {
            return books.Count;
        }
    }
}
