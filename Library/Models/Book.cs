namespace Library.Models
{
    public class Book
    {
        public int ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }

        public Book(int isbn, string title, string author, string description, int year)
        {
            ISBN = isbn;
            Title = title;
            Author = author;
            Year = year;
            Description = description;
        }

        public override string ToString()
        {
            return $"Title: {Title}\n" +
                $"Author: {Author}\n" +
                $"Description: {Description}\n" +
                $"Year: {Year}\n" +
                $"ISBN: {ISBN}";
        }
    }
}
