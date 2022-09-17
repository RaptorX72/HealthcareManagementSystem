using MySql.Data.MySqlClient;
using System.Text;

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
            con.ConnectionString = $"server={info.address};uid={info.username};pwd={info.password};database={info.databaseName}";
            //Task.Run(() => { Setup(info); });
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
            string[] tableCreationQueries = new string[] {
                "CREATE TABLE IF NOT EXISTS User(id CHAR(36) PRIMARY KEY, userName VARCHAR(64), email VARCHAR(256), salt VARCHAR(128), password VARCHAR(512));",
                "CREATE TABLE IF NOT EXISTS Doctor(id CHAR(36) PRIMARY KEY, firstName VARCHAR(128), lastName VARCHAR(128), middleName VARCHAR(128));",
                "CREATE TABLE IF NOT EXISTS Patient(id CHAR(36) PRIMARY KEY, firstName VARCHAR(128), lastName VARCHAR(128), middleName VARCHAR(128));",
                "CREATE TABLE IF NOT EXISTS UnitOfMeasurement(id INTEGER AUTO_INCREMENT PRIMARY KEY, name VARCHAR(64));",
                "CREATE TABLE IF NOT EXISTS Medication(id CHAR(36) PRIMARY KEY, name VARCHAR(256), mainIngredient VARCHAR(256), dosage FLOAT, size FLOAT, unitOfMeasurementId INTEGER, FOREIGN KEY (unitOfMeasurementId) REFERENCES UnitOfMeasurement(id));",
                "CREATE TABLE IF NOT EXISTS Perscription(id CHAR(36) PRIMARY KEY, patientId CHAR(36), doctorId CHAR(36), medicationId CHAR(36), note TEXT, FOREIGN KEY (patientId) REFERENCES Patient(id), FOREIGN KEY (doctorId) REFERENCES Doctor(id), FOREIGN KEY (medicationId) REFERENCES Medication(id));",
                "CREATE TABLE IF NOT EXISTS Appointment(id CHAR(36) PRIMARY KEY, appointmentDate DATETIME, doctorId CHAR(36), patientId CHAR(36), note TEXT, FOREIGN KEY (doctorId) REFERENCES Doctor(id), FOREIGN KEY (patientId) REFERENCES Patient(id));",
                "CREATE TABLE IF NOT EXISTS MedicalNote(id CHAR(36) PRIMARY KEY, appointmentId CHAR(36), note TEXT, FOREIGN KEY (appointmentId) REFERENCES Appointment(id));",
                "CREATE TABLE IF NOT EXISTS BloodType(id INTEGER AUTO_INCREMENT PRIMARY KEY, protein CHAR(2), rh BOOLEAN);",
                "CREATE TABLE IF NOT EXISTS MedicalRecord(id CHAR(36) PRIMARY KEY, patientId CHAR(36), birthDate DATETIME, gender VARCHAR(16), bloodTypeId INTEGER, height FLOAT, weight FLOAT, FOREIGN KEY (patientId) REFERENCES Patient(id), FOREIGN KEY (bloodTypeId) REFERENCES BloodType(id));",
                "CREATE TABLE IF NOT EXISTS PatientPerscription(id INTEGER AUTO_INCREMENT PRIMARY KEY, patientId CHAR(36), perscriptionId CHAR(36), FOREIGN KEY (patientId) REFERENCES Patient(id), FOREIGN KEY (perscriptionId) REFERENCES Perscription(id));",
                "CREATE TABLE IF NOT EXISTS MedicalTestType(id INTEGER AUTO_INCREMENT PRIMARY KEY, name VARCHAR(128));",
                "CREATE TABLE IF NOT EXISTS MedicalTest(id CHAR(36) PRIMARY KEY, doctorId CHAR(36), patientId CHAR(36), testTypeId INTEGER, FOREIGN KEY (doctorId) REFERENCES Doctor(id), FOREIGN KEY (patientId) REFERENCES Patient(id), FOREIGN KEY (testTypeId) REFERENCES MedicalTestType(id));",
                "CREATE TABLE IF NOT EXISTS SurgeryOutcome(id INTEGER AUTO_INCREMENT PRIMARY KEY, name VARCHAR(128));",
                "CREATE TABLE IF NOT EXISTS Surgery(id CHAR(36) PRIMARY KEY, appointerId CHAR(36), surgeonId CHAR(36), patientId CHAR(36), surgeryDate DATETIME, note TEXT, outcomeId INTEGER, FOREIGN KEY (appointerId) REFERENCES Doctor(id), FOREIGN KEY (surgeonId) REFERENCES Doctor(id), FOREIGN KEY (patientId) REFERENCES Patient(id), FOREIGN KEY (outcomeId) REFERENCES SurgeryOutcome(id));"
            };

            StringBuilder sb = new StringBuilder();
            foreach (string query in tableCreationQueries) sb.AppendLine(query);
            using (MySqlCommand cmd = new MySqlCommand(sb.ToString(), con)) {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
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
