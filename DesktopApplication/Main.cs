using MySql.Data.MySqlClient;
using DesktopApplication.Model;
using DesktopApplication.Model.Database;
using DesktopApplication.Model.Management;

namespace DesktopApplication {
    public partial class Main : Form {
        public Main() {
            InitializeComponent();
            /*DBConnectionInfo info = new DBConnectionInfo() {
                address = "localhost",
                username = "root",
                password = "",
                databaseName = "testdb"
            };
            DBHandler.SetDataBaseType(DataBaseType.MySQL, info);
            Appointment ap = new Appointment(
                Guid.Empty, DateTime.Now, Guid.Empty, Guid.Empty, "notes"
            );
            DBHandler.DB.Appointment().AddAppointment(ap);*/
        }
    }
}