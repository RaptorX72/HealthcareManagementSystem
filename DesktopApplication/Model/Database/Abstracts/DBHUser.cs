using DesktopApplication.Model.Management;

namespace DesktopApplication.Model.Database {
    public abstract class DBHUser : IDBHandlerUser {
        public abstract List<User> GetAllUsers();
        public abstract User GetUserById(Guid userId);
        public abstract User LoginUser(string username, string password);
        public abstract void UpdateUserById(Guid userId, User user);
    }
}
