using DesktopApplication.Model.Management;
using MySql.Data.MySqlClient;

namespace DesktopApplication.Model.Database {
    public class MySQLDBHUser : DBHUser {
        private MySqlConnection con;

        public MySQLDBHUser(MySqlConnection con) {
            this.con = con;
        }

        public override User AddUser(User user) {
            throw new NotImplementedException();
        }

        public override List<User> GetAllUsers() {
            throw new NotImplementedException();
        }

        public override User GetUserById(Guid userId) {
            throw new NotImplementedException();
        }

        public override User LoginUser(string username, string password) {
            throw new NotImplementedException();
        }

        public override void UpdateUserById(Guid userId, User user) {
            throw new NotImplementedException();
        }
    }
}
