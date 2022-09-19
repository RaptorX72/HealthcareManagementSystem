using MySql.Data.MySqlClient;
using System.Text;

namespace DesktopApplication.Model.Database {
    public class MySQLDBHandler : IDBHandler {
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
            appointmentDb = new MySQLDBHAppointment(info);
            doctorDb = new MySQLDBHDoctor(info);
            medicalNoteDb = new MySQLDBHMedicalNote(info);
            medicalRecordDb = new MySQLDBHMedicalRecord(info);
            medicalTestDb = new MySQLDBHMedicalTest(info);
            medicationDb = new MySQLDBHMedication(info);
            patientDb = new MySQLDBHPatient(info);
            perscriptionDb = new MySQLDBHPerscription(info);
            surgeryDb = new MySQLDBHSurgery(info);
            userDb = new MySQLDBHUser(info);
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
