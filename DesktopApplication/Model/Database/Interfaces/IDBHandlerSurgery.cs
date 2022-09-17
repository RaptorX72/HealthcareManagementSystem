using DesktopApplication.Model.Healthcare;
using DesktopApplication.Model.Management;

namespace DesktopApplication.Model.Database {
    public interface IDBHandlerSurgery {
        public Surgery AddSurgery(Surgery surgery);

        public List<Surgery> GetAllSurgeries();

        public Surgery GetSurgeryById(Guid surgeryId);

        public void UpdateSurgeryById(Guid surgeryId, Surgery Surgery);

        public void UpdateSurgery(Surgery Surgery);

        public void DeleteSurgeryById(Guid surgeryId);

        public void DeleteSurgery(Surgery Surgery);

        #region GetAll
        public List<Surgery> GetAllSurgeriesByAppointerDoctorId(Guid doctorId);

        public List<Surgery> GetAllSurgeriesByAppointerDoctor(Doctor doctor);

        public List<Surgery> GetAllSurgeriesBySurgeonId(Guid doctorId);

        public List<Surgery> GetAllSurgeriesBySurgeon(Doctor doctor);

        public List<Surgery> GetAllSurgeriesOfPatientById(Guid patientId);

        public List<Surgery> GetAllSurgeriesOfPatient(Patient patient);

        public List<Surgery> GetAllSurgeriesByDate(DateTime date);

        public List<Surgery> GetAllSurgeriesByOutcome(SurgeryOutcome outcome);
        #endregion

        #region UpdateAll
        public void UpdateAllSurgeriesByAppointerDoctorId(Guid doctorId, List<Surgery> Surgeries);

        public void UpdateAllSurgeriesByAppointerDoctor(Doctor doctor, List<Surgery> Surgeries);

        public void UpdateAllSurgeriesBySurgeonId(Guid doctorId, List<Surgery> Surgeries);

        public void UpdateAllSurgeriesBySurgeon(Doctor doctor, List<Surgery> Surgeries);

        public void UpdateAllSurgeriesOfPatientById(Guid patientId, List<Surgery> Surgeries);

        public void UpdateAllSurgeriesOfPatient(Patient patient, List<Surgery> Surgeries);

        public void UpdateAllSurgeriesByDate(DateTime date, List<Surgery> Surgeries);

        public void UpdateAllSurgeriesByOutcome(SurgeryOutcome outcome, List<Surgery> Surgeries);
        #endregion

        #region DeleteAll
        public void DeleteAllSurgeriesByAppointerDoctorId(Guid doctorId);

        public void DeleteAllSurgeriesByAppointerDoctor(Doctor doctor);

        public void DeleteAllSurgeriesBySurgeonId(Guid doctorId);

        public void DeleteAllSurgeriesBySurgeon(Doctor doctor);

        public void DeleteAllSurgeriesOFPatientById(Guid patientId);

        public void DeleteAllSurgeriesOfPatient(Patient patient);

        public void DeleteAllSurgeriesByDate(DateTime date);

        public void DeleteAllSurgeriesByOutcome(SurgeryOutcome outcome);
        #endregion
    }
}
