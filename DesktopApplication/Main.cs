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
            try {
                DBHandler.DB.User().AddUser(new User("foobar", "foobar@email.com", "1234"));
            } catch (GenericDatabaseException ex) {
                MessageBox.Show(ex.Message);
            } catch (InvalidEmailException ex) {
                MessageBox.Show(ex.Message);
            }
            User newUser = User.Empty;
            try {
                newUser = DBHandler.DB.User().LoginUser("foobar@email.com", "1234");
            } catch (GenericDatabaseException ex) {
                MessageBox.Show(ex.Message);
            } catch (InvalidEmailException ex) {
                MessageBox.Show(ex.Message);
            } catch (InvalidPasswordException ex) {
                MessageBox.Show(ex.Message);
            }
            newUser.UpdateEmail("foobar2@email.com");
            newUser.UpdatePassword("QWERTZ");
            try {
                DBHandler.DB.User().UpdateUserById(newUser.Id, newUser);
            } catch (GenericDatabaseException ex) {
                MessageBox.Show(ex.Message);
            }
            MessageBox.Show("Done");
        }
    }
}