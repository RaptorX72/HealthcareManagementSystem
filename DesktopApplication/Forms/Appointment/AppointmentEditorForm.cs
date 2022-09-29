using DesktopApplication.Model;
using DesktopApplication.Model.Database;
using DesktopApplication.Model.Healthcare;
using DesktopApplication.Model.Management;

namespace DesktopApplication.Forms {
    public partial class AppointmentEditorForm : Form {
        private Doctor doctor;
        private Appointment appointment = Appointment.Empty;
        private List<Patient> patients = new List<Patient>();
        public Appointment Appointment { get => appointment; }

        public AppointmentEditorForm(Doctor doctor) {
            InitializeComponent();
            this.doctor = doctor;
            Setup();
            buttonAddEdit.Text = "Add";
        }

        public AppointmentEditorForm(Doctor doctor, Appointment appointment) {
            InitializeComponent();
            this.doctor = doctor;
            this.appointment = appointment;
            Setup();
        }

        private void Setup() {
            patients = DBHandler.Patient.GetPatientsOfDoctor(doctor);
            FillPatientsDropDownList(patients);
            if (appointment.Id != Guid.Empty) {
                dateTimePickerAppointmentDate.Value = appointment.Date;
                numericUpDownHour.Value = appointment.Date.Hour;
                numericUpDownMinute.Value = appointment.Date.Minute;
                SelectPatientInDropDownList(patients, appointment.PatientId);
                richTextBoxNotes.Text = appointment.Notes;
            } else {
                dateTimePickerAppointmentDate.Value = DateTime.Now;
                numericUpDownHour.Value = DateTime.Now.Hour;
                numericUpDownMinute.Value = DateTime.Now.Minute;
                if (patients.Count > 0) comboBoxPatients.SelectedIndex = 0;
            }
        }

        private void FillPatientsDropDownList(List<Patient> patients) {
            comboBoxPatients.Items.Clear();
            foreach (Patient patient in patients)
                comboBoxPatients.Items.Add($"{patient.FirstName} {patient.MiddleName} {patient.LastName}");
        }

        private void SelectPatientInDropDownList(List<Patient> patients, Guid patientId) {
            for (int i = 0; i < patients.Count; i++) {
                if (patients[i].Id == patientId) {
                    comboBoxPatients.SelectedIndex = i;
                    break;
                }
            }
        }

        private void buttonAddEdit_Click(object sender, EventArgs e) {
            if (comboBoxPatients.SelectedIndex == -1 || comboBoxPatients.SelectedIndex >= patients.Count) return;

            DateTime tmpdt = dateTimePickerAppointmentDate.Value;
            DateTime dt = new DateTime(
                tmpdt.Year, tmpdt.Month, tmpdt.Day,
                (int)numericUpDownHour.Value, (int)numericUpDownMinute.Value, 0
            );

            Guid patientId = patients[comboBoxPatients.SelectedIndex].Id;
            try {
                if (appointment.Id == Guid.Empty)
                    appointment = DBHandler.Appointment.AddAppointment(new Appointment(dt, doctor.Id, patientId, richTextBoxNotes.Text));
                else {
                    appointment = new Appointment(appointment.Id, dt, doctor.Id, patientId, richTextBoxNotes.Text);
                    DBHandler.Appointment.UpdateAppointment(appointment);
                }
            } catch (GenericDatabaseException ex) {
                MessageBox.Show(ex.Message);
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e) {
            bool unsavedChanges = false;
            //TODO: Implement check if anything changed
            /*if (appointment.Id != Guid.Empty) {

            }
            if (MessageBox.Show("Are you sure you want to cancel?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes) this.Close();*/
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void checkBoxOwnPatients_CheckedChanged(object sender, EventArgs e) {
            if (checkBoxOwnPatients.Checked) patients = DBHandler.Patient.GetPatientsOfDoctor(doctor);
            else patients = DBHandler.Patient.GetAllPatients();
            FillPatientsDropDownList(patients);
        }
    }
}
