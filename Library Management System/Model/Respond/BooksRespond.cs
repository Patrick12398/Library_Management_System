namespace Library_Management_System.Model.Respond
{
    public class BooksRespond
    {
        public BooksRespond(int id, string title, string author, string iSBN, int publishedYear, bool isAvailable)
        {
            Id = id;
            Title = title;
            Author = author;
            ISBN = iSBN;
            PublishedYear = publishedYear;
            IsAvailable = isAvailable;
        }

        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public int PublishedYear { get; set; }
        public bool IsAvailable { get; set; }
    }
}
