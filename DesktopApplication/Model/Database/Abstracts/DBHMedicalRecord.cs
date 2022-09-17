using DesktopApplication.Model.Healthcare;
using DesktopApplication.Model.Management;

namespace DesktopApplication.Model.Database {
    public abstract class DBHMedicalRecord : IDBHandlerMedicalRecord {
        public abstract void DeleteMedicalRecord(MedicalRecord MedicalRecord);
        public abstract void DeleteMedicalRecordById(Guid medicalRecordId);
        public abstract void DeleteMedicalRecordOfPatient(Patient patient);
        public abstract void DeleteMedicalRecordOfPatientById(Guid patientId);
        public abstract List<MedicalRecord> GetAllMedicalRecords();
        public abstract MedicalRecord GetMedicalRecordById(Guid medicalRecordId);
        public abstract MedicalRecord GetMedicalRecordOfPatient(Patient patient);
        public abstract MedicalRecord GetMedicalRecordOfPatientById(Guid patientId);
        public abstract void UpdateMedicalRecord(MedicalRecord MedicalRecord);
        public abstract void UpdateMedicalRecordById(Guid medicalRecordId, MedicalRecord MedicalRecord);
        public abstract void UpdateMedicalRecordOfPatient(Patient patient, MedicalRecord MedicalRecord);
        public abstract void UpdateMedicalRecordOfPatientById(Guid patientId, MedicalRecord MedicalRecord);
    }
}
