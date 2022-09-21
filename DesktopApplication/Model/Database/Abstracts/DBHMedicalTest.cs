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
        public abstract void DeleteMedicalTest(MedicalTest medicalTest);
        public abstract void DeleteMedicalTestById(Guid medicalTestId);
        public abstract List<MedicalTest> GetAllMedicalTests();
        public abstract List<MedicalTest> GetAllMedicalTestsByDoctor(Doctor doctor);
        public abstract List<MedicalTest> GetAllMedicalTestsByDoctorId(Guid doctorId);
        public abstract List<MedicalTest> GetAllMedicalTestsByType(MedicalTestType medicalTestType);
        public abstract List<MedicalTest> GetAllMedicalTestsOfPatient(Patient patient);
        public abstract List<MedicalTest> GetAllMedicalTestsOfPatientById(Guid patientId);
        public abstract MedicalTest GetMedicalTestById(Guid medicalTestId);
        public abstract void UpdateMedicalTest(MedicalTest medicalTest);
        public abstract void UpdateMedicalTestById(Guid medicalTestId, MedicalTest medicalTest);
        public abstract void UpdateMedicalTests(List<MedicalTest> medicalTests);
    }
}
