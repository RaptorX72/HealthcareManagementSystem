using DesktopApplication.Model.Healthcare;
using DesktopApplication.Model.Management;

namespace DesktopApplication.Model.Database {
    public abstract class DBHSurgery : IDBHandlerSurgery {
        public abstract Surgery AddSurgery(Surgery surgery);
        public abstract void DeleteAllSurgeriesByAppointerDoctor(Doctor doctor);
        public abstract void DeleteAllSurgeriesByAppointerDoctorId(Guid doctorId);
        public abstract void DeleteAllSurgeriesByDate(DateTime date);
        public abstract void DeleteAllSurgeriesByOutcome(SurgeryOutcome outcome);
        public abstract void DeleteAllSurgeriesBySurgeon(Doctor doctor);
        public abstract void DeleteAllSurgeriesBySurgeonId(Guid doctorId);
        public abstract void DeleteAllSurgeriesOfPatient(Patient patient);
        public abstract void DeleteAllSurgeriesOFPatientById(Guid patientId);
        public abstract void DeleteSurgery(Surgery surgery);
        public abstract void DeleteSurgeryById(Guid surgeryId);
        public abstract List<Surgery> GetAllSurgeries();
        public abstract List<Surgery> GetAllSurgeriesByAppointerDoctor(Doctor doctor);
        public abstract List<Surgery> GetAllSurgeriesByAppointerDoctorId(Guid doctorId);
        public abstract List<Surgery> GetAllSurgeriesByDate(DateTime date);
        public abstract List<Surgery> GetAllSurgeriesByOutcome(SurgeryOutcome outcome);
        public abstract List<Surgery> GetAllSurgeriesBySurgeon(Doctor doctor);
        public abstract List<Surgery> GetAllSurgeriesBySurgeonId(Guid doctorId);
        public abstract List<Surgery> GetAllSurgeriesOfPatient(Patient patient);
        public abstract List<Surgery> GetAllSurgeriesOfPatientById(Guid patientId);
        public abstract Surgery GetSurgeryById(Guid surgeryId);
        public abstract void UpdateSurgeries(List<Surgery> surgeries);
        public abstract void UpdateSurgery(Surgery surgery);
        public abstract void UpdateSurgeryById(Guid surgeryId, Surgery surgery);
    }
}
