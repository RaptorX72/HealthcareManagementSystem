using DesktopApplication.Model.Healthcare;
using MySql.Data.MySqlClient;

namespace DesktopApplication.Model.Database {
    public class MySQLDBHPatient : DBHPatient {
        private MySqlConnection con;

        public MySQLDBHPatient(MySqlConnection con) {
            this.con = con;
        }

        public override Patient AddPatient(Patient patient) {
            throw new NotImplementedException();
        }

        public override void DeletePatient(Patient patient) {
            throw new NotImplementedException();
        }

        public override void DeletePatientById(Guid patientId) {
            throw new NotImplementedException();
        }

        public override List<Patient> GetAllPatients() {
            throw new NotImplementedException();
        }

        public override Patient GetPatientById(Guid patientId) {
            throw new NotImplementedException();
        }

        public override List<Patient> GetPatientsOfDoctor(Doctor doctor) {
            throw new NotImplementedException();
        }

        public override List<Patient> GetPatientsOfDoctorById(Guid doctorId) {
            throw new NotImplementedException();
        }

        public override void UpdatePatient(Patient patient) {
            throw new NotImplementedException();
        }

        public override void UpdatePatientById(Guid patientId, Patient patient) {
            throw new NotImplementedException();
        }

        public override void UpdatePatientsOfDoctor(Doctor doctor, List<Patient> patients) {
            throw new NotImplementedException();
        }

        public override void UpdatePatientsOfDoctorById(Guid doctorId, List<Patient> patients) {
            throw new NotImplementedException();
        }
    }
}
