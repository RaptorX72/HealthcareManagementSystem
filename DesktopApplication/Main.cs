using MySql.Data.MySqlClient;
using DesktopApplication.Model;
using DesktopApplication.Model.Database;
using DesktopApplication.Model.Healthcare;
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
        }

        private void buttonTest_Click(object sender, EventArgs e) {
            try {
            } catch (MySqlException ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
}