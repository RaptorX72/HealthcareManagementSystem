using DesktopApplication.Model.Healthcare;
using DesktopApplication.Model.Management;

namespace DesktopApplication.Model.Database {
    public interface IDBHandlerAppointment {
        public List<Appointment> GetAllAppointments();

        public Appointment GetAppointmentById(Guid appointmentId);

        public void UpdateAppointmentById(Guid appointmentId, Appointment appointment);

        public void UpdateAppointment(Appointment appointment);

        public void DeleteAppointmentById(Guid appointmentId);

        public void DeleteAppointment(Appointment appointment);

        #region GetAll
        public List<Appointment> GetAllAppointmentsByDoctorId(Guid doctorId);

        public List<Appointment> GetAllAppointmentsByDoctor(Doctor doctor);

        public List<Appointment> GetAllAppointmentsByPatientId(Guid patientId);

        public List<Appointment> GetAllAppointmentsByPatient(Patient patient);

        public List<Appointment> GetAllAppointmentsBySpecialityId(Guid specialityId);

        public List<Appointment> GetAllAppointmentsByDate(DateTime date);
        #endregion

        #region UpdateAll
        public void UpdateAllAppointmentsByDoctorId(Guid doctorId, List<Appointment> appointments);

        public void UpdateAllAppointmentsByDoctor(Doctor doctor, List<Appointment> appointments);

        public void UpdateAllAppointmentsByPatientId(Guid patientId, List<Appointment> appointments);

        public void UpdateAllAppointmentsByPatient(Patient patient, List<Appointment> appointments);

        public void UpdateAllAppointmentsBySpecialityId(Guid specialityId, List<Appointment> appointments);

        public void UpdateAllAppointmentsByDate(DateTime date, List<Appointment> appointments);
        #endregion

        #region DeleteAll
        public void DeleteAllAppointmentsByDoctorId(Guid doctorId);

        public void DeleteAllAppointmentsByDoctor(Doctor doctor);

        public void DeleteAllAppointmentsByPatientId(Guid patientId);

        public void DeleteAllAppointmentsByPatient(Patient patient);

        public void DeleteAllAppointmentsBySpecialityId(Guid specialityId);

        public void DeleteAllAppointmentsByDate(DateTime date);
        #endregion
    }
}
