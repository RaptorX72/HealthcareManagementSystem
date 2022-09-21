using DesktopApplication.Model.Healthcare;
using DesktopApplication.Model.Management;

namespace DesktopApplication.Model.Database {
    public interface IDBHandlerMedicalRecord {
        public MedicalRecord AddMedicalRecord(MedicalRecord record);

        public List<MedicalRecord> GetAllMedicalRecords();

        public MedicalRecord GetMedicalRecordById(Guid medicalRecordId);

        public MedicalRecord GetMedicalRecordOfPatientById(Guid patientId);

        public MedicalRecord GetMedicalRecordOfPatient(Patient patient);

        public void UpdateMedicalRecordById(Guid medicalRecordId, MedicalRecord medicalRecord);

        public void UpdateMedicalRecord(MedicalRecord medicalRecord);

        public void DeleteMedicalRecordById(Guid medicalRecordId);

        public void DeleteMedicalRecord(MedicalRecord medicalRecord);
    }
}
