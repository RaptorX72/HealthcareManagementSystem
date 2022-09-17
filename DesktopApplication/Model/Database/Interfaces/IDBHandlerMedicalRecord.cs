using DesktopApplication.Model.Healthcare;
using DesktopApplication.Model.Management;

namespace DesktopApplication.Model.Database {
    public interface IDBHandlerMedicalRecord {
        public MedicalRecord AddMedicalRecord(MedicalRecord record);

        public List<MedicalRecord> GetAllMedicalRecords();

        public MedicalRecord GetMedicalRecordById(Guid medicalRecordId);

        public MedicalRecord GetMedicalRecordOfPatientById(Guid patientId);

        public MedicalRecord GetMedicalRecordOfPatient(Patient patient);

        public void UpdateMedicalRecordById(Guid medicalRecordId, MedicalRecord MedicalRecord);

        public void UpdateMedicalRecord(MedicalRecord MedicalRecord);

        public void UpdateMedicalRecordOfPatientById(Guid patientId, MedicalRecord MedicalRecord);

        public void UpdateMedicalRecordOfPatient(Patient patient, MedicalRecord MedicalRecord);

        public void DeleteMedicalRecordById(Guid medicalRecordId);

        public void DeleteMedicalRecord(MedicalRecord MedicalRecord);

        public void DeleteMedicalRecordOfPatientById(Guid patientId);

        public void DeleteMedicalRecordOfPatient(Patient patient);
    }
}
