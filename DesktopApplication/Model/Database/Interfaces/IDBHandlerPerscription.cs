using DesktopApplication.Model.Healthcare;
using DesktopApplication.Model.Management;

namespace DesktopApplication.Model.Database {
    public interface IDBHandlerPerscription {
        public List<Perscription> GetAllPerscriptions();

        public Perscription GetPerscriptionById(Guid perscriptionId);

        public void UpdatePerscriptionById(Guid perscriptionId, Perscription Perscription);

        public void UpdatePerscription(Perscription Perscription);

        public void DeletePerscriptionById(Guid perscriptionId);

        public void DeletePerscription(Perscription Perscription);

        #region GetAll
        public List<Perscription> GetAllPerscriptionsByDoctorId(Guid doctorId);

        public List<Perscription> GetAllPerscriptionsByDoctor(Doctor doctor);

        public List<Perscription> GetAllPerscriptionsByPatientId(Guid patientId);

        public List<Perscription> GetAllPerscriptionsByPatient(Patient patient);
        #endregion

        #region UpdateAll
        public void UpdateAllPerscriptionsByDoctorId(Guid doctorId, List<Perscription> Perscriptions);

        public void UpdateAllPerscriptionsByDoctor(Doctor doctor, List<Perscription> Perscriptions);

        public void UpdateAllPerscriptionsByPatientId(Guid patientId, List<Perscription> Perscriptions);

        public void UpdateAllPerscriptionsByPatient(Patient patient, List<Perscription> Perscriptions);
        #endregion

        #region DeleteAll
        public void DeleteAllPerscriptionsByDoctorId(Guid doctorId);

        public void DeleteAllPerscriptionsByDoctor(Doctor doctor);

        public void DeleteAllPerscriptionsByPatientId(Guid patientId);

        public void DeleteAllPerscriptionsByPatient(Patient patient);
        #endregion
    }
}
