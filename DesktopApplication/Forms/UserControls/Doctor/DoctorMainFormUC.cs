using DesktopApplication.Model.Database;
using DesktopApplication.Model.Healthcare;
using DesktopApplication.Model.Management;

namespace DesktopApplication {
    public partial class DoctorMainFormUC : UserControl {
        private Main parentForm;
        private User user;
        private Doctor doctor;
        public DoctorMainFormUC(Main parentForm, User user) {
            InitializeComponent();
            this.parentForm = parentForm;
            this.user = user;
            //dummy code for testing
            doctor = DBHandler.Doctor.GetAllDoctors()[0];
            Setup();
        }

        private void Setup() {
            labelFirstName.Text = $"Dr. {doctor.FirstName} {doctor.LastName}";
        }

        private void buttonExit_Click(object sender, EventArgs e) {
            Dispose();
        }
    }
}
