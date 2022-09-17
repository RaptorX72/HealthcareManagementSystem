using DesktopApplication.Model.Healthcare;
using DesktopApplication.Model.Management;

namespace DesktopApplication.Model.Database {
    public abstract class DBHMedicalTest : IDBHandlerMedicalTest {
        public abstract MedicalTest AddMedicalTest(MedicalTest medicalTest);
        public abstract void DeleteAllMedicalTestsByDoctor(Doctor doctor);
        public abstract void DeleteAllMedicalTestsByDoctorId(Guid doctorId);
        public abstract void DeleteAllMedicalTestsByType(MedicalTestType medicalTestType);
        public abstract void DeleteAllMedicalTestsOfPatient(Patient patient);
        public abstract void DeleteAllMedicalTestsOfPatientById(Guid patientId);
        public abstract void DeleteMedicalTest(MedicalTest MedicalTest);
        public abstract void DeleteMedicalTestById(Guid medicalTestId);
        public abstract List<MedicalTest> GetAllMedicalTests();
        public abstract List<MedicalTest> GetAllMedicalTestsByDoctor(Doctor doctor);
        public abstract List<MedicalTest> GetAllMedicalTestsByDoctorId(Guid doctorId);
        public abstract List<MedicalTest> GetAllMedicalTestsByType(MedicalTestType medicalTestType);
        public abstract List<MedicalTest> GetAllMedicalTestsOfPatient(Patient patient);
        public abstract List<MedicalTest> GetAllMedicalTestsOfPatientById(Guid patientId);
        public abstract MedicalTest GetMedicalTestById(Guid medicalTestId);
        public abstract void UpdateAllMedicalTestsByDoctor(Doctor doctor, List<MedicalTest> medicalTests);
        public abstract void UpdateAllMedicalTestsByDoctorId(Guid doctorId, List<MedicalTest> medicalTests);
        public abstract void UpdateAllMedicalTestsByType(MedicalTestType medicalTestType, List<MedicalTest> medicalTests);
        public abstract void UpdateAllMedicalTestsOfPatient(Patient patient, List<MedicalTest> medicalTests);
        public abstract void UpdateAllMedicalTestsOfPatientById(Guid patientId, List<MedicalTest> medicalTests);
        public abstract void UpdateMedicalTest(MedicalTest MedicalTest);
        public abstract void UpdateMedicalTestById(Guid medicalTestId, MedicalTest MedicalTest);
    }
}
