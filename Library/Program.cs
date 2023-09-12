using Library.Models;

namespace Library
{
    internal class Program
    {
        static void Main()
        {
            Services.Library library = new( new List<Book>
            {
                 new Book(50884, "Clean Code: A Handbook of Agile Software Craftsmanship", "Robert C. Martin", "Clean Code is about transforming code into readable, elegant, efficient and maintainable software.", 2008),
                 new Book(16224, "Design Patterns: Elements of Reusable Object-Oriented Software", "Erich Gamma, Richard Helm, Ralph Johnson, John Vlissides", "This book provides essential knowledge about design patterns in software engineering.", 1994),
                 new Book(25217, "The Pragmatic Programmer: Your Journey to Mastery", "Andrew Hunt, David Thomas", "A guide to becoming a more efficient and effective programmer.", 1999),
                 new Book(07126, "Head First Design Patterns", "Elisabeth Freeman, Eric Freeman, Bert Bates, Kathy Sierra", "This book introduces design patterns in a unique and engaging way.", 2004),
                 new Book(35953, "Code: The Hidden Language of Computer Hardware and Software", "Charles Petzold", "This book provides an accessible introduction to the inner workings of computers.", 1999),
                 new Book(94140, "Introduction to the Theory of Computation", "Michael Sipser", "This book explores the theory of computation and formal languages.", 2012),
                 new Book(03627, "Artificial Intelligence: A Modern Approach", "Stuart Russell, Peter Norvig", "A comprehensive introduction to artificial intelligence.", 2009),
                 new Book(45886, "Effective Java", "Joshua Bloch", "This book offers best practices for writing high-quality Java code.", 2008),
                 new Book(33848, "Introduction to Algorithms", "Thomas H. Cormen, Charles E. Leiserson, Ronald L. Rivest, Clifford Stein", "A fundamental textbook on algorithms and data structures.", 2009),
                 new Book(31116, "Structure and Interpretation of Computer Programs", "Harold Abelson, Gerald Jay Sussman, Julie Sussman", "A classic book on programming and computer science concepts.", 1996),
                 new Book(07126, "Clean Architecture: A Craftsman's Guide to Software Structure and Design", "Robert C. Martin", "This book focuses on architectural design principles for software.", 2017),
                 new Book(17748, "JavaScript: The Good Parts", "Douglas Crockford", "This book highlights the good parts of the JavaScript language.", 2008),
                 new Book(14114, "Cracking the Coding Interview", "Gayle Laakmann McDowell", "A comprehensive resource for technical interview preparation.", 2011),
                 new Book(08188, "Art of Computer Programming, Volume 1: Fundamental Algorithms", "Donald E. Knuth", "A classic work on algorithms and computer programming.", 1997),
                 new Book(16224, "Refactoring: Improving the Design of Existing Code", "Martin Fowler", "This book provides techniques for improving code quality.", 1999) 
            });

        Console.WriteLine("Welcome to the library");
            while (true)
            {
                Console.WriteLine("Your list of possible actions:\n" +
                    "0. Exit the app\n" +
                    "1. Add a book\n" +
                    "2. Remove a book\n" +
                    "3. Find books by their author\n" +
                    "4. Find books by title\n" +
                    "5. Display book titles in ascending order\n" +
                    "6. Display all books\n" +
                    "7. Write all books to txt");

                Console.WriteLine("Choose your action");
                var num = Console.ReadLine();

                switch (num)
                {
                    case "0":
                        return;

                    case "1":
                        Console.WriteLine("Enter book title:");
                        string? title = Console.ReadLine();
                        if (IsStringNullOrEmpty(title))
                        {
                            continue;
                        }

                        Console.WriteLine("Enter book isbn:");
                        if (!int.TryParse(Console.ReadLine(), out int isbn)){
                            Console.WriteLine("That was not a proper isbn, request a retry");
                            continue;   
                        }

                        Console.WriteLine("Enter year of book's creation:");
                        if (!int.TryParse(Console.ReadLine(), out int year) || 0 > year || year > 2023){
                            Console.WriteLine("That was not a proper year, request a retry");
                            continue;   
                        }

                        Console.WriteLine("Enter book author:");
                        string? author = Console.ReadLine();
                        if (IsStringNullOrEmpty(author))
                        {
                            continue;
                        }

                        Console.WriteLine("Enter book description:");
                        string? description = Console.ReadLine();
                        if (IsStringNullOrEmpty(description))
                        {
                            continue;
                        }

                        library.AddBook(new Book(isbn, title!, author!, description!, year));

                        continue;

                    case "2":
                        Console.WriteLine("Enter isbn to remove a book:");

                        if (!int.TryParse(Console.ReadLine(), out int isbnBookToRemove))
                        {
                            Console.WriteLine("That was not a proper isbn, request a retry");
                            continue;
                        }

                        library.RemoveBook(isbnBookToRemove);
                        continue;

                    case "3":
                        string? authorToFind = Console.ReadLine();

                        if (IsStringNullOrEmpty(authorToFind))
                        {
                            continue;
                        }

                        foreach(Book book in library.FindBooksByAuthor(authorToFind!))
                        {
                            Console.WriteLine(book.ToString() + "\n");
                        }

                        continue;

                    case "4":
                        string? titleToFind = Console.ReadLine();

                        if (IsStringNullOrEmpty(titleToFind))
                        {
                            continue;
                        }

                        foreach (Book book in library.FindBooksByTitle(titleToFind!))
                        {
                            Console.WriteLine(book.ToString() + "\n");
                        }

                        continue;

                    case "5":
                        foreach (string bookTitle in library.GetAllBookTitlesAscending())
                        {
                            Console.WriteLine(bookTitle.ToString() + "\n");
                        }
                        continue;

                    case "6":
                        foreach (Book book in library.GetAllBooks())
                        {
                            Console.WriteLine(book.ToString() + "\n");
                        }
                        continue;

                    case "7":
                        Console.WriteLine("Enter path or leave blank");
                        var path = Console.ReadLine();

                        if (string.IsNullOrEmpty(path))
                        {
                            library.WriteAllBooksToTXT();
                        }
                        else
                        {
                            library.WriteAllBooksToTXT(path);
                        }

                        continue;

                    default:
                        Console.WriteLine("No such action");
                        continue;
                }
            }

            static bool IsStringNullOrEmpty(string? title){
                if (string.IsNullOrEmpty(title))
                {
                    Console.WriteLine("You should actually enter something, request a retry");
                    return true;
                }
                return false;
            }
        }
    }
}