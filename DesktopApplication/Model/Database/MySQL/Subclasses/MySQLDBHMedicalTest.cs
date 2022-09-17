using DesktopApplication.Model.Healthcare;
using DesktopApplication.Model.Management;
using MySql.Data.MySqlClient;

namespace DesktopApplication.Model.Database {
    public class MySQLDBHMedicalTest : DBHMedicalTest {
        private MySqlConnection con;

        public MySQLDBHMedicalTest(MySqlConnection con) {
            this.con = con;
        }

        public override MedicalTest AddMedicalTest(MedicalTest medicalTest) {
            throw new NotImplementedException();
        }

        public override void DeleteAllMedicalTestsByDoctor(Doctor doctor) {
            throw new NotImplementedException();
        }

        public override void DeleteAllMedicalTestsByDoctorId(Guid doctorId) {
            throw new NotImplementedException();
        }

        public override void DeleteAllMedicalTestsByType(MedicalTestType medicalTestType) {
            throw new NotImplementedException();
        }

        public override void DeleteAllMedicalTestsOfPatient(Patient patient) {
            throw new NotImplementedException();
        }

        public override void DeleteAllMedicalTestsOfPatientById(Guid patientId) {
            throw new NotImplementedException();
        }

        public override void DeleteMedicalTest(MedicalTest MedicalTest) {
            throw new NotImplementedException();
        }

        public override void DeleteMedicalTestById(Guid medicalTestId) {
            throw new NotImplementedException();
        }

        public override List<MedicalTest> GetAllMedicalTests() {
            throw new NotImplementedException();
        }

        public override List<MedicalTest> GetAllMedicalTestsByDoctor(Doctor doctor) {
            throw new NotImplementedException();
        }

        public override List<MedicalTest> GetAllMedicalTestsByDoctorId(Guid doctorId) {
            throw new NotImplementedException();
        }

        public override List<MedicalTest> GetAllMedicalTestsByType(MedicalTestType medicalTestType) {
            throw new NotImplementedException();
        }

        public override List<MedicalTest> GetAllMedicalTestsOfPatient(Patient patient) {
            throw new NotImplementedException();
        }

        public override List<MedicalTest> GetAllMedicalTestsOfPatientById(Guid patientId) {
            throw new NotImplementedException();
        }

        public override MedicalTest GetMedicalTestById(Guid medicalTestId) {
            throw new NotImplementedException();
        }

        public override void UpdateAllMedicalTestsByDoctor(Doctor doctor, List<MedicalTest> medicalTests) {
            throw new NotImplementedException();
        }

        public override void UpdateAllMedicalTestsByDoctorId(Guid doctorId, List<MedicalTest> medicalTests) {
            throw new NotImplementedException();
        }

        public override void UpdateAllMedicalTestsByType(MedicalTestType medicalTestType, List<MedicalTest> medicalTests) {
            throw new NotImplementedException();
        }

        public override void UpdateAllMedicalTestsOfPatient(Patient patient, List<MedicalTest> medicalTests) {
            throw new NotImplementedException();
        }

        public override void UpdateAllMedicalTestsOfPatientById(Guid patientId, List<MedicalTest> medicalTests) {
            throw new NotImplementedException();
        }

        public override void UpdateMedicalTest(MedicalTest MedicalTest) {
            throw new NotImplementedException();
        }

        public override void UpdateMedicalTestById(Guid medicalTestId, MedicalTest MedicalTest) {
            throw new NotImplementedException();
        }
    }
}
