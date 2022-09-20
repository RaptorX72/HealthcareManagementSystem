using DesktopApplication.Model.Management;
using MySql.Data.MySqlClient;

namespace DesktopApplication.Model.Database {
    public class MySQLDBHUser : DBHUser {
        private MySqlConnection con;

        public MySQLDBHUser(DBConnectionInfo info) {
            con = CommonTools.CreateMySQLConnection(info);
        }

        private User FillUserWithReaderData(MySqlDataReader reader) {
            return new User(
                reader.GetGuid("id"),
                reader.GetString("userName"),
                reader.GetString("email"),
                reader.GetString("salt"),
                reader.GetString("password")
            );
        }

        public override User AddUser(User user) {
            User newUser = user;
            if (CheckIfEmailExists(user.Email)) throw new InvalidEmailException("Email already exists!");
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                con.Open();
                //check if guid already exists in database
                while (true) {
                    cmd.CommandText = $"SELECT Count(id) FROM User WHERE id = '{newUser.Id}'";
                    //if yes, generate a new guid
                    if ((Int64)cmd.ExecuteScalar() == 0) break;
                    else newUser = new User(user.Username, user.Email, user.Salt, user.Password); ;
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

        public override bool CheckIfEmailExists(string email) {
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = $"SELECT Count(id) FROM User WHERE email = '{email}'";
                bool found = (Int64)cmd.ExecuteScalar() > 0;
                con.Close();
                return found;
            }
        }

        public override List<User> GetAllUsers() {
            List<User> users = new List<User>();
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = "SELECT * From User";
                using (MySqlDataReader reader = cmd.ExecuteReader()) {
                    while (reader.Read()) users.Add(FillUserWithReaderData(reader));
                }
                con.Close();
            }
            return users;
        }

        public override User GetUserById(Guid userId) {
            User user = User.Empty;
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = $"SELECT * From User WHERE id = '{userId}'";
                using (MySqlDataReader reader = cmd.ExecuteReader()) {
                    reader.Read();
                    user = FillUserWithReaderData(reader);
                }
                con.Close();
            }
            return user;
        }

        public override User LoginUser(string email, string password) {
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = $"SELECT * From User WHERE email = '{email}'";
                using (MySqlDataReader reader = cmd.ExecuteReader()) {
                    if (!reader.HasRows) {
                        con.Close();
                        throw new InvalidEmailException("Email not found in database");
                    }
                    while(reader.Read()) {
                        string salt = reader.GetString("salt");
                        string userPassword = reader.GetString("password");
                        if (User.HashPassword(salt, password) == userPassword) {
                            User user = FillUserWithReaderData(reader);
                            con.Close();
                            return user;
                        } else {
                            con.Close();
                            throw new InvalidPasswordException("Password is incorrect");
                        }
                    }
                }
            }
            return User.Empty;
        }

        public override void UpdateUserById(Guid userId, User user) {
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = $"UPDATE User SET userName = @userName, email = @email, salt = @salt, password = @password WHERE id = '{userId}'";
                cmd.Parameters.AddWithValue("@userName", user.Username);
                cmd.Parameters.AddWithValue("@email", user.Email);
                cmd.Parameters.AddWithValue("@salt", user.Salt);
                cmd.Parameters.AddWithValue("@password", user.Password);
                try {
                    cmd.ExecuteNonQuery();
                } catch (Exception ex) {
                    throw new GenericDatabaseException(ex.Message);
                } finally {
                    con.Close();
                }
            }
        }
    }
}
