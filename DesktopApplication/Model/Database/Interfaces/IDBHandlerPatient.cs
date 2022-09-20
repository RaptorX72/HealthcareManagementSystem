using DesktopApplication.Model.Healthcare;

namespace DesktopApplication.Model.Database {
    public interface IDBHandlerPatient {
        public Patient AddPatient(Patient patient);

        public List<Patient> GetAllPatients();

        public Patient GetPatientById(Guid patientId);

        public void UpdatePatientById(Guid patientId, Patient patient);

        public void UpdatePatient(Patient patient);

        public void DeletePatientById(Guid patientId);

        public void DeletePatient(Patient patient);

        public List<Patient> GetPatientsOfDoctorById(Guid doctorId);

        public List<Patient> GetPatientsOfDoctor(Doctor doctor);

        public void UpdatePatients(List<Patient> patients);
    }
}
