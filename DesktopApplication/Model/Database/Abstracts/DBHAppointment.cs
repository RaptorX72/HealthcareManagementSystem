using DesktopApplication.Model.Healthcare;
using DesktopApplication.Model.Management;

namespace DesktopApplication.Model.Database {
    public abstract class DBHAppointment : IDBHandlerAppointment {
        public abstract Appointment AddAppointment(Appointment appointment);
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
        public abstract void UpdateAppointment(Appointment appointment);
        public abstract void UpdateAppointmentById(Guid appointmentId, Appointment appointment);
        public abstract void UpdateAppointments(List<Appointment> appointments);
    }
}
