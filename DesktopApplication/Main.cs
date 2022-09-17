using MySql.Data.MySqlClient;
using DesktopApplication.Model;
using DesktopApplication.Model.Database;
using DesktopApplication.Model.Management;

namespace DesktopApplication {
    public partial class Main : Form {
        public Main() {
            InitializeComponent();
            //Dummy code for testing
            DBConnectionInfo info = new DBConnectionInfo() {
                address = "localhost",
                username = "root",
                password = "",
                databaseName = "testdb"
            };
            DBHandler.SetDataBaseType(DataBaseType.MySQL, info);
            User newUser = new User("foobar", "foobar@email.com", "1234");
            newUser = DBHandler.DB.User().AddUser(newUser);
            MessageBox.Show(newUser.Password);
        }
    }
}