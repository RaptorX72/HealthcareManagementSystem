using DesktopApplication.Model.Healthcare;
using DesktopApplication.Model.Management;
using MySql.Data.MySqlClient;

namespace DesktopApplication.Model.Database {
    public class MySQLDBHAppointment : DBHAppointment {
        private MySqlConnection con;

        public MySQLDBHAppointment(MySqlConnection con) {
            this.con = con;
        }

        public override Appointment AddAppointment(Appointment appointment) {
            throw new NotImplementedException();
        }

        public override void DeleteAllAppointmentsByDate(DateTime date) {
            throw new NotImplementedException();
        }

        public override void DeleteAllAppointmentsByDoctor(Doctor doctor) {
            throw new NotImplementedException();
        }

        public override void DeleteAllAppointmentsByDoctorId(Guid doctorId) {
            throw new NotImplementedException();
        }

        public override void DeleteAllAppointmentsByPatient(Patient patient) {
            throw new NotImplementedException();
        }

        public override void DeleteAllAppointmentsByPatientId(Guid patientId) {
            throw new NotImplementedException();
        }

        public override void DeleteAllAppointmentsBySpecialityId(Guid specialityId) {
            throw new NotImplementedException();
        }

        public override void DeleteAppointment(Appointment appointment) {
            throw new NotImplementedException();
        }

        public override void DeleteAppointmentById(Guid appointmentId) {
            throw new NotImplementedException();
        }

        public override List<Appointment> GetAllAppointments() {
            throw new NotImplementedException();
        }

        public override List<Appointment> GetAllAppointmentsByDate(DateTime date) {
            throw new NotImplementedException();
        }

        public override List<Appointment> GetAllAppointmentsByDoctor(Doctor doctor) {
            throw new NotImplementedException();
        }

        public override List<Appointment> GetAllAppointmentsByDoctorId(Guid doctorId) {
            throw new NotImplementedException();
        }

        public override List<Appointment> GetAllAppointmentsByPatient(Patient patient) {
            throw new NotImplementedException();
        }

        public override List<Appointment> GetAllAppointmentsByPatientId(Guid patientId) {
            throw new NotImplementedException();
        }

        public override List<Appointment> GetAllAppointmentsBySpecialityId(Guid specialityId) {
            throw new NotImplementedException();
        }

        public override Appointment GetAppointmentById(Guid appointmentId) {
            throw new NotImplementedException();
        }

        public override void UpdateAllAppointmentsByDate(DateTime date, List<Appointment> appointments) {
            throw new NotImplementedException();
        }

        public override void UpdateAllAppointmentsByDoctor(Doctor doctor, List<Appointment> appointments) {
            throw new NotImplementedException();
        }

        public override void UpdateAllAppointmentsByDoctorId(Guid doctorId, List<Appointment> appointments) {
            throw new NotImplementedException();
        }

        public override void UpdateAllAppointmentsByPatient(Patient patient, List<Appointment> appointments) {
            throw new NotImplementedException();
        }

        public override void UpdateAllAppointmentsByPatientId(Guid patientId, List<Appointment> appointments) {
            throw new NotImplementedException();
        }

        public override void UpdateAllAppointmentsBySpecialityId(Guid specialityId, List<Appointment> appointments) {
            throw new NotImplementedException();
        }

        public override void UpdateAppointment(Appointment appointment) {
            throw new NotImplementedException();
        }

        public override void UpdateAppointmentById(Guid appointmentId, Appointment appointment) {
            throw new NotImplementedException();
        }
    }
}
