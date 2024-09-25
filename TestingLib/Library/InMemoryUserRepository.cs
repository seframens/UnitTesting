namespace TestingLib.Library
{
    // Пример реализации репозитория пользователей (in-memory)
    public class InMemoryUserRepository : IUserRepository
    {
        private readonly List<User> _users = new List<User>();

        public List<User> GetAllUsers() => _users;
        public User GetUserById(int id) => _users.FirstOrDefault(u => u.Id == id);
        public void AddUser(User user) => _users.Add(user); 
        public void UpdateUser(User user) { 
            var index = _users.FindIndex(u => u.Id == user.Id); 
            if (index != -1) { 
                _users[index] = user; 
            } 
        }
        public void DeleteUser(int id) => _users.RemoveAll(u => u.Id == id);
    }
}
