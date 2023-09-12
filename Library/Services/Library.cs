using Library.Models;
using System.Text;

namespace Library.Services
{
    public class Library
    {
        private readonly List<Book> _books;

        public Library() 
        { 
            _books= new List<Book>();
        }

        public Library(ICollection<Book> starterBooks) 
        { 
            _books = starterBooks.ToList();
        }

        public void AddBook(Book bookToAdd)
        {
            _books.Add(bookToAdd);
        }

        public void RemoveBook(int isbn) 
        {
            var bookToRemove = _books.FirstOrDefault(x => x.ISBN == isbn);
            if (bookToRemove != null)
            {
                _books.Remove(bookToRemove);
            }
        }
    
        public List<Book> FindBooksByAuthor(string authorName)
        {
            return _books.Select(x => x)
                .Where(x => x.Author.Contains(authorName)).ToList();
        }

        public List<Book> FindBooksByTitle(string bookTitle)
        {
            return _books.Select(x => x)
                .Where(x => x.Title.Contains(bookTitle)).ToList();
        }

        public List<Book> GetAllBooks()
        {
            return _books;
        }

        public List<string> GetAllBookTitlesAscending()
        {
            return _books.Select(x => x.Title)
                .OrderBy(x => x)
                .ToList();
        }

        public void WriteAllBooksToTXT(string filePath = "./books.txt")
        {
            try
            {
                var directory = Path.GetDirectoryName(filePath);

                if (!Directory.Exists(directory) && directory != null)
                {
                    Directory.CreateDirectory(directory);
                }
                if (!File.Exists(filePath))
                {
                    File.Create(filePath).Close();
                }

                using StreamWriter writer = new(filePath);
                StringBuilder sb = new();

                foreach (Book book in _books)
                {
                    sb.Append(book.ToString() + "\n\n");
                }
                writer.WriteLine(sb);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
