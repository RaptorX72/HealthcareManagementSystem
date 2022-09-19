using DesktopApplication.Model.Management;

namespace DesktopApplication.Model.Database {
    public interface IDBHandlerUser {
        public bool CheckIfEmailExists(string email);

        public User AddUser(User user);

        public List<User> GetAllUsers();

        public User GetUserById(Guid userId);

        public void UpdateUserById(Guid userId, User user);

        public User LoginUser(string email, string password);
    }
}