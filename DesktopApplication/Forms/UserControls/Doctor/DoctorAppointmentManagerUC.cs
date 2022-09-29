using DesktopApplication.Model.Database;
using DesktopApplication.Model.Healthcare;
using DesktopApplication.Model.Management;
using DesktopApplication.Forms;

namespace DesktopApplication {
    public partial class DoctorAppointmentManagerUC : UserControl {
        private DoctorMainFormUC parentUC;
        private Doctor doctor;
        List<Appointment> upcomingAppointments = new List<Appointment>();
        List<Appointment> pastAppointments = new List<Appointment>();
        public DoctorAppointmentManagerUC(DoctorMainFormUC parent, Doctor doctor) {
            InitializeComponent();
            parentUC = parent;
            this.doctor = doctor;
            RefreshLists();
        }

        private void RefreshLists() {
            List<Appointment> appointments = DBHandler.Appointment.GetAllAppointmentsByDoctor(this.doctor);
            appointments.Sort((x, y) => x.Date.CompareTo(y.Date));

            foreach (Appointment item in appointments) {
                if (item.Date > DateTime.Now) upcomingAppointments.Add(item);
                else pastAppointments.Add(item);
            }

            PopulateAppointmentListBox(listBoxUpcomingAppointments, upcomingAppointments);
            PopulateAppointmentListBox(listBoxPastAppointments, pastAppointments);
        }

        private void PopulateAppointmentListBox(ListBox lb, List<Appointment> appointments) {
            lb.Items.Clear();
            foreach (Appointment item in appointments) {
                Patient p = DBHandler.Patient.GetPatientById(item.PatientId);
                lb.Items.Add($"{item.Date.ToString("MM/dd HH:mm")} ({p.FirstName} {p.MiddleName} {p.LastName}) {item.Notes}");
            }
        }

        private void listBoxUpcomingAppointments_SelectedIndexChanged(object sender, EventArgs e) {
            int i = listBoxUpcomingAppointments.SelectedIndex;
            if (i >= upcomingAppointments.Count || i == -1) return;
        }

        private void buttonUpcomingAdd_Click(object sender, EventArgs e) {
            if (new AppointmentEditorForm(doctor).ShowDialog() == DialogResult.OK) RefreshLists();
        }

        private void buttonUpcomingEdit_Click(object sender, EventArgs e) {
            if (listBoxUpcomingAppointments.SelectedIndex == -1) return;
            if (new AppointmentEditorForm(doctor, upcomingAppointments[listBoxUpcomingAppointments.SelectedIndex]).ShowDialog() == DialogResult.OK) RefreshLists();
        }

        private void buttonUpcomingDelete_Click(object sender, EventArgs e) {
            if (listBoxUpcomingAppointments.SelectedIndex == -1) return;
            if (MessageBox.Show("Are you sure you want to delete appointment?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                Appointment ap = upcomingAppointments[listBoxUpcomingAppointments.SelectedIndex];
                listBoxUpcomingAppointments.Items.Remove(ap);
                DBHandler.Appointment.DeleteAppointment(ap);
            }
        }

        private void buttonUpcomingRefresh_Click(object sender, EventArgs e) {
            RefreshLists();
        }

        private void buttonPastRefresh_Click(object sender, EventArgs e) {
            RefreshLists();
        }
    }
}
