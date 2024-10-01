using Bogus;

namespace TestingLib.Library
{
    // Пример реализации репозитория книг (in-memory)
    public class InMemoryBookRepository : IBookRepository
    {
        private readonly List<Book> _books = new List<Book>();

        public List<Book> GetAllBooks() => _books;
        public Book GetBookById(int id) => _books.FirstOrDefault(b => b.Id == id);
        public void AddBook(Book book) => _books.Add(book);
        public void UpdateBook(Book book)
        {
            var index = _books.FindIndex(b => b.Id == book.Id);
            if (index != -1)
            {
                _books[index] = book;
            }
        }
        public void DeleteBook(int id) => _books.RemoveAll(b => b.Id == id);


        public void InitByBogus()
        {
            //Set the randomizer seed if you wish to generate repeatable data sets.
            Randomizer.Seed = new Random(8675309);

            var bookIds = 0;
            var testBooks = new Faker<Book>("ru")
                .StrictMode(true)
                .RuleFor(b => b.Id, f => bookIds++)
                .RuleFor(b => b.Title, f => String.Join(" ",f.Lorem.Words(3)))
                .RuleFor(b => b.IsBorrowed, f => f.Random.Bool())
                .RuleFor(b => b.Author, f => f.Name.FullName());
            _books.AddRange(testBooks.GenerateBetween(50, 100));
        }
    }
}
