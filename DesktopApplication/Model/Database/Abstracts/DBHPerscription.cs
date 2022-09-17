using DesktopApplication.Model.Healthcare;
using DesktopApplication.Model.Management;

namespace DesktopApplication.Model.Database {
    public abstract class DBHPerscription : IDBHandlerPerscription {
        public abstract void DeleteAllPerscriptionsByDoctor(Doctor doctor);
        public abstract void DeleteAllPerscriptionsByDoctorId(Guid doctorId);
        public abstract void DeleteAllPerscriptionsByPatient(Patient patient);
        public abstract void DeleteAllPerscriptionsByPatientId(Guid patientId);
        public abstract void DeletePerscription(Perscription Perscription);
        public abstract void DeletePerscriptionById(Guid perscriptionId);
        public abstract List<Perscription> GetAllPerscriptions();
        public abstract List<Perscription> GetAllPerscriptionsByDoctor(Doctor doctor);
        public abstract List<Perscription> GetAllPerscriptionsByDoctorId(Guid doctorId);
        public abstract List<Perscription> GetAllPerscriptionsByPatient(Patient patient);
        public abstract List<Perscription> GetAllPerscriptionsByPatientId(Guid patientId);
        public abstract Perscription GetPerscriptionById(Guid perscriptionId);
        public abstract void UpdateAllPerscriptionsByDoctor(Doctor doctor, List<Perscription> Perscriptions);
        public abstract void UpdateAllPerscriptionsByDoctorId(Guid doctorId, List<Perscription> Perscriptions);
        public abstract void UpdateAllPerscriptionsByPatient(Patient patient, List<Perscription> Perscriptions);
        public abstract void UpdateAllPerscriptionsByPatientId(Guid patientId, List<Perscription> Perscriptions);
        public abstract void UpdatePerscription(Perscription Perscription);
        public abstract void UpdatePerscriptionById(Guid perscriptionId, Perscription Perscription);
    }
}
