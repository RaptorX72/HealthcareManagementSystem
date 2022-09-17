using MySql.Data.MySqlClient;

namespace DesktopApplication.Model.Database {
    public class MySQLDBHandler : IDBHandler {
        private MySqlConnection con = new MySqlConnection();
        private MySQLDBHAppointment appointmentDb;
        private MySQLDBHDoctor doctorDb;
        private MySQLDBHMedicalNote medicalNoteDb;
        private MySQLDBHMedicalRecord medicalRecordDb;
        private MySQLDBHMedicalTest medicalTestDb;
        private MySQLDBHMedication medicationDb;
        private MySQLDBHPatient patientDb;
        private MySQLDBHPerscription perscriptionDb;
        private MySQLDBHSurgery surgeryDb;
        private MySQLDBHUser userDb;

        public MySQLDBHandler(DBConnectionInfo info) {
            Setup(info);
            appointmentDb = new MySQLDBHAppointment(con);
            doctorDb = new MySQLDBHDoctor(con);
            medicalNoteDb = new MySQLDBHMedicalNote(con);
            medicalRecordDb = new MySQLDBHMedicalRecord(con);
            medicalTestDb = new MySQLDBHMedicalTest(con);
            medicationDb = new MySQLDBHMedication(con);
            patientDb = new MySQLDBHPatient(con);
            perscriptionDb = new MySQLDBHPerscription(con);
            surgeryDb = new MySQLDBHSurgery(con);
            userDb = new MySQLDBHUser(con);
        }

        private void Setup(DBConnectionInfo info) {
            con.ConnectionString = $"server={info.address};userid={info.username};password={info.password};database={info.databaseName}";
            //TODO: Set up database tables if they don't exist
        }

        public DBHAppointment Appointment() {
            return appointmentDb;
        }

        public DBHDoctor Doctor() {
            return doctorDb;
        }

        public DBHMedicalNote MedicalNote() {
            return medicalNoteDb;
        }

        public DBHMedicalRecord MedicalRecord() {
            return medicalRecordDb;
        }

        public DBHMedicalTest MedicalTest() {
            return medicalTestDb;
        }

        public DBHMedication Medication() {
            return medicationDb;
        }

        public DBHPatient Patient() {
            return patientDb;
        }

        public DBHPerscription Perscription() {
            return perscriptionDb;
        }

        public DBHSurgery Surgery() {
            return surgeryDb;
        }

        public DBHUser User() {
            return userDb;
        }
    }
}
