using DesktopApplication.Model.Management;
using MySql.Data.MySqlClient;

namespace DesktopApplication.Model.Database {
    public class MySQLDBHUser : DBHUser {
        private MySqlConnection con;

        public MySQLDBHUser(MySqlConnection con) {
            this.con = con;
        }

        public override User AddUser(User user) {
            User newUser = new User(user.Username, user.Email, user.Password);
            //TODO: add email exist check
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                con.Open();
                //check if guid already exists in database
                while (true) {
                    cmd.CommandText = $"SELECT id FROM User WHERE id = '{newUser.Id}'";
                    //if yes, generate a new guid
                    if (cmd.ExecuteNonQuery() > 0) newUser = new User(user.Username, user.Email, user.Password);
                    else break;
                }
                cmd.CommandText = "INSERT INTO User (id, userName, email, salt, password) VALUES (@id, @username, @email, @salt, @password)";
                cmd.Parameters.AddWithValue("@id", newUser.Id);
                cmd.Parameters.AddWithValue("@username", newUser.Username);
                cmd.Parameters.AddWithValue("@email", newUser.Email);
                cmd.Parameters.AddWithValue("@salt", newUser.Salt);
                cmd.Parameters.AddWithValue("@password", newUser.Password);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return newUser;
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
