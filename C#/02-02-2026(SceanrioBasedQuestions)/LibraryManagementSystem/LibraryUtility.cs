using System;
using System.Collections.Generic;

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
            Dictionary<string, List<Book>> grouped = new Dictionary<string, List<Book>>();
            
            foreach (var book in books)
            {
                if (book.Genre != null)
                {
                    if (!grouped.ContainsKey(book.Genre))
                    {
                        grouped[book.Genre] = new List<Book>();
                    }
                    grouped[book.Genre].Add(book);
                }
            }
            
            return new SortedDictionary<string, List<Book>>(grouped);
        }

        public List<Book> GetBooksByAuthor(string author)
        {
            List<Book> result = new List<Book>();
            foreach (var book in books)
            {
                if (book.Author != null && book.Author.Equals(author, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(book);
                }
            }
            return result;
        }

        public int GetTotalBooksCount()
        {
            return books.Count;
        }
    }
}
