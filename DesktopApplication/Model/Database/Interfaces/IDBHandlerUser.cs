using DesktopApplication.Model.Management;

namespace DesktopApplication.Model.Database {
    public interface IDBHandlerUser {
        public List<User> GetAllUsers();

        public User GetUserById(Guid userId);

        public void UpdateUserById(Guid userId, User user);

        public User LoginUser(string username, string password);
    }
}