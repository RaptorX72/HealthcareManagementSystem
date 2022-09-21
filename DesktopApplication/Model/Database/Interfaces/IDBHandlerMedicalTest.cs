using DesktopApplication.Model.Healthcare;
using DesktopApplication.Model.Management;

namespace DesktopApplication.Model.Database {
    public interface IDBHandlerMedicalTest {
        public MedicalTest AddMedicalTest(MedicalTest medicalTest);

        public List<MedicalTest> GetAllMedicalTests();

        public MedicalTest GetMedicalTestById(Guid medicalTestId);

        public void UpdateMedicalTestById(Guid medicalTestId, MedicalTest medicalTest);

        public void UpdateMedicalTest(MedicalTest medicalTest);

        public void DeleteMedicalTestById(Guid medicalTestId);

        public void DeleteMedicalTest(MedicalTest medicalTest);

        #region GetAll
        public List<MedicalTest> GetAllMedicalTestsOfPatientById(Guid patientId);

        public List<MedicalTest> GetAllMedicalTestsOfPatient(Patient patient);

        public List<MedicalTest> GetAllMedicalTestsByDoctorId(Guid doctorId);

        public List<MedicalTest> GetAllMedicalTestsByDoctor(Doctor doctor);

        public List<MedicalTest> GetAllMedicalTestsByType(MedicalTestType medicalTestType);
        #endregion

        #region UpdateAll
        public void UpdateMedicalTests(List<MedicalTest> medicalTests);
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
