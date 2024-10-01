using TestingLib;
using TestingLib.Library;

internal class Program
{
    private static void Main(string[] args)
    {
        InMemoryBookRepository bookRepository = new InMemoryBookRepository();
        bookRepository.InitByBogus();
        List<Book> books = bookRepository.GetAllBooks();
        Console.BackgroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Black;
        Console.Clear();
        foreach (Book book in books)
        {
            Console.WriteLine(book.Id);
            Console.WriteLine(book.Title);
            Console.WriteLine(book.Author);
            Console.WriteLine(book.IsBorrowed);
            Console.WriteLine("------------------------");
        }
    }
}