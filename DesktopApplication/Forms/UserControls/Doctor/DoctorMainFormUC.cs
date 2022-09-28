using DesktopApplication.Model.Database;
using DesktopApplication.Model.Healthcare;
using DesktopApplication.Model.Management;

namespace DesktopApplication {
    public partial class DoctorMainFormUC : UserControl {
        private Main parentForm;
        private User user;
        private Doctor doctor;
        private DoctorAppointmentManagerUC doctorAppointmentManagerUC;
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

        private void buttonAppointments_Click(object sender, EventArgs e) {
            panelMain.Controls.Clear();
            if (doctorAppointmentManagerUC == null) {
                doctorAppointmentManagerUC = new DoctorAppointmentManagerUC(this, doctor) { Dock = DockStyle.Fill };
            }
            panelMain.Controls.Add(doctorAppointmentManagerUC);
        }
    }
}
