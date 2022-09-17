using DesktopApplication.Model.Healthcare;
using DesktopApplication.Model.Management;

namespace DesktopApplication.Model.Database {
    public abstract class DBHAppointment : IDBHandlerAppointment {
        public abstract void DeleteAllAppointmentsByDate(DateTime date);
        public abstract void DeleteAllAppointmentsByDoctor(Doctor doctor);
        public abstract void DeleteAllAppointmentsByDoctorId(Guid doctorId);
        public abstract void DeleteAllAppointmentsByPatient(Patient patient);
        public abstract void DeleteAllAppointmentsByPatientId(Guid patientId);
        public abstract void DeleteAllAppointmentsBySpecialityId(Guid specialityId);
        public abstract void DeleteAppointment(Appointment appointment);
        public abstract void DeleteAppointmentById(Guid appointmentId);
        public abstract List<Appointment> GetAllAppointments();
        public abstract List<Appointment> GetAllAppointmentsByDate(DateTime date);
        public abstract List<Appointment> GetAllAppointmentsByDoctor(Doctor doctor);
        public abstract List<Appointment> GetAllAppointmentsByDoctorId(Guid doctorId);
        public abstract List<Appointment> GetAllAppointmentsByPatient(Patient patient);
        public abstract List<Appointment> GetAllAppointmentsByPatientId(Guid patientId);
        public abstract List<Appointment> GetAllAppointmentsBySpecialityId(Guid specialityId);
        public abstract Appointment GetAppointmentById(Guid appointmentId);
        public abstract void UpdateAllAppointmentsByDate(DateTime date, List<Appointment> appointments);
        public abstract void UpdateAllAppointmentsByDoctor(Doctor doctor, List<Appointment> appointments);
        public abstract void UpdateAllAppointmentsByDoctorId(Guid doctorId, List<Appointment> appointments);
        public abstract void UpdateAllAppointmentsByPatient(Patient patient, List<Appointment> appointments);
        public abstract void UpdateAllAppointmentsByPatientId(Guid patientId, List<Appointment> appointments);
        public abstract void UpdateAllAppointmentsBySpecialityId(Guid specialityId, List<Appointment> appointments);
        public abstract void UpdateAppointment(Appointment appointment);
        public abstract void UpdateAppointmentById(Guid appointmentId, Appointment appointment);
    }
}
