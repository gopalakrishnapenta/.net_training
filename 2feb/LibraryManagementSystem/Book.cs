namespace LibraryManagementSystem
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int PublicationYear { get; set; }

        public override string ToString()
        {
            return $"{Id}: {Title} by {Author} ({PublicationYear})";
        }
    }
}
