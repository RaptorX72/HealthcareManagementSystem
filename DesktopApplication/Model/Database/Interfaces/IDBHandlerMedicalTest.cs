using DesktopApplication.Model.Healthcare;
using DesktopApplication.Model.Management;

namespace DesktopApplication.Model.Database.Interfaces {
    public interface IDBHandlerMedicalTest {
        public List<MedicalTest> GetAllMedicalTests();

        public MedicalTest GetMedicalTestById(Guid medicalTestId);

        public void UpdateMedicalTestById(Guid medicalTestId, MedicalTest MedicalTest);

        public void UpdateMedicalTest(MedicalTest MedicalTest);

        public void DeleteMedicalTestById(Guid medicalTestId);

        public void DeleteMedicalTest(MedicalTest MedicalTest);

        #region GetAll
        public List<MedicalTest> GetAllMedicalTestsOfPatientById(Guid patientId);

        public List<MedicalTest> GetAllMedicalTestsOfPatient(Patient patient);

        public List<MedicalTest> GetAllMedicalTestsByDoctorId(Guid doctorId);

        public List<MedicalTest> GetAllMedicalTestsByDoctor(Doctor doctor);

        public List<MedicalTest> GetAllMedicalTestsByType(MedicalTestType medicalTestType);
        #endregion

        #region UpdateAll
        public void UpdateAllMedicalTestsOfPatientById(Guid patientId, List<MedicalTest> medicalTests);

        public void UpdateAllMedicalTestsOfPatient(Patient patient, List<MedicalTest> medicalTests);

        public void UpdateAllMedicalTestsByDoctorId(Guid doctorId, List<MedicalTest> medicalTests);

        public void UpdateAllMedicalTestsByDoctor(Doctor doctor, List<MedicalTest> medicalTests);

        public void UpdateAllMedicalTestsByType(MedicalTestType medicalTestType, List<MedicalTest> medicalTests);
        #endregion

        #region DeleteAll
        public void DeleteAllMedicalTestsOfPatientById(Guid patientId);

        public void DeleteAllMedicalTestsOfPatient(Patient patient);

        public void DeleteAllMedicalTestsByDoctorId(Guid doctorId);

        public void DeleteAllMedicalTestsByDoctor(Doctor doctor);

        public void DeleteAllMedicalTestsByType(MedicalTestType medicalTestType);
        #endregion
    }
}
