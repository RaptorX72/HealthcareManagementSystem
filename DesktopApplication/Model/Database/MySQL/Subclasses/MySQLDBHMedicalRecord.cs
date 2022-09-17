using DesktopApplication.Model.Healthcare;
using DesktopApplication.Model.Management;
using MySql.Data.MySqlClient;

namespace DesktopApplication.Model.Database {
    public class MySQLDBHMedicalRecord : DBHMedicalRecord {
        private MySqlConnection con;

        public MySQLDBHMedicalRecord(MySqlConnection con) {
            this.con = con;
        }

        public override MedicalRecord AddMedicalRecord(MedicalRecord record) {
            throw new NotImplementedException();
        }

        public override void DeleteMedicalRecord(MedicalRecord MedicalRecord) {
            throw new NotImplementedException();
        }

        public override void DeleteMedicalRecordById(Guid medicalRecordId) {
            throw new NotImplementedException();
        }

        public override void DeleteMedicalRecordOfPatient(Patient patient) {
            throw new NotImplementedException();
        }

        public override void DeleteMedicalRecordOfPatientById(Guid patientId) {
            throw new NotImplementedException();
        }

        public override List<MedicalRecord> GetAllMedicalRecords() {
            throw new NotImplementedException();
        }

        public override MedicalRecord GetMedicalRecordById(Guid medicalRecordId) {
            throw new NotImplementedException();
        }

        public override MedicalRecord GetMedicalRecordOfPatient(Patient patient) {
            throw new NotImplementedException();
        }

        public override MedicalRecord GetMedicalRecordOfPatientById(Guid patientId) {
            throw new NotImplementedException();
        }

        public override void UpdateMedicalRecord(MedicalRecord MedicalRecord) {
            throw new NotImplementedException();
        }

        public override void UpdateMedicalRecordById(Guid medicalRecordId, MedicalRecord MedicalRecord) {
            throw new NotImplementedException();
        }

        public override void UpdateMedicalRecordOfPatient(Patient patient, MedicalRecord MedicalRecord) {
            throw new NotImplementedException();
        }

        public override void UpdateMedicalRecordOfPatientById(Guid patientId, MedicalRecord MedicalRecord) {
            throw new NotImplementedException();
        }
    }
}
