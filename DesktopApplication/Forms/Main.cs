using DesktopApplication.Model;
using DesktopApplication.Model.Database;
using DesktopApplication.Model.Management;

namespace DesktopApplication {
    public partial class Main : Form {
        private User user = User.Empty;

        public Main() {
            InitializeComponent();

            //dummy code for testing
            DBHandler.SetDataBaseType(DataBaseType.MySQL,
                new DBConnectionInfo() {
                    address = "localhost",
                    databaseName = "testdb",
                    password = "",
                    username = "root"
                }
            );
            flowLayoutPanelMain.Controls.Add(new LoginUC(this));

        }

        public void SetUser(User user) {
            this.user = user;
        }
    }
}
