using System.Text;

namespace DesktopApplication.Model {
    public class CommonTools {
        public static string GenerateRandomString(int length) {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--) res.Append(valid[rnd.Next(valid.Length)]);
            return res.ToString();
        }

        public static MySql.Data.MySqlClient.MySqlConnection CreateMySQLConnection(DBConnectionInfo info) {
            MySql.Data.MySqlClient.MySqlConnection connection = new MySql.Data.MySqlClient.MySqlConnection();
            connection.ConnectionString = $"server={info.address};uid={info.username};pwd={info.password};database={info.databaseName}";
            return connection;
        }
    }
}
