namespace TestingLib.Library
{
    // Сервис для работы с книгами
    public class LibraryService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IUserRepository _userRepository;

        public LibraryService(IBookRepository bookRepository, IUserRepository userRepository)
        {
            _bookRepository = bookRepository;
            _userRepository = userRepository;
        }

        // Метод для выдачи книги пользователю
        public bool BorrowBook(int bookId, int userId)
        {
            var book = _bookRepository.GetBookById(bookId);
            var user = _userRepository.GetUserById(userId);

            if (book == null || user == null || book.IsBorrowed)
            {
                return false;
            }

            book.IsBorrowed = true;
            user.BorrowedBooks.Add(book);
            _bookRepository.UpdateBook(book);
            _userRepository.UpdateUser(user);

            return true;
        }

        // Метод для возврата книги
        public bool ReturnBook(int bookId, int userId)
        {
            var book = _bookRepository.GetBookById(bookId);
            var user = _userRepository.GetUserById(userId);

            if (book == null || user == null || !book.IsBorrowed || !user.BorrowedBooks.Contains(book))
            {
                return false;
            }

            book.IsBorrowed = false;
            user.BorrowedBooks.Remove(book);
            _bookRepository.UpdateBook(book);
            _userRepository.UpdateUser(user);

            return true;
        }
    }
}
