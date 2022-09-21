using DesktopApplication.Model.Healthcare;
using DesktopApplication.Model.Management;

namespace DesktopApplication.Model.Database {
    public abstract class DBHMedicalRecord : IDBHandlerMedicalRecord {
        public abstract MedicalRecord AddMedicalRecord(MedicalRecord record);
        public abstract void DeleteMedicalRecord(MedicalRecord medicalRecord);
        public abstract void DeleteMedicalRecordById(Guid medicalRecordId);
        public abstract List<MedicalRecord> GetAllMedicalRecords();
        public abstract MedicalRecord GetMedicalRecordById(Guid medicalRecordId);
        public abstract MedicalRecord GetMedicalRecordOfPatient(Patient patient);
        public abstract MedicalRecord GetMedicalRecordOfPatientById(Guid patientId);
        public abstract void UpdateMedicalRecord(MedicalRecord medicalRecord);
        public abstract void UpdateMedicalRecordById(Guid medicalRecordId, MedicalRecord medicalRecord);
    }
}
