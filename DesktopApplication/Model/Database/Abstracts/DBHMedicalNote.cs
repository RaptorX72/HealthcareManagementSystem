using DesktopApplication.Model.Healthcare;
using DesktopApplication.Model.Management;

namespace DesktopApplication.Model.Database {
    public abstract class DBHMedicalNote : IDBHandlerMedicalNote {
        public abstract MedicalNote AddMedicalNote(MedicalNote medicalNote);
        public abstract void DeleteAllMedicalNotesByDoctor(Doctor doctor);
        public abstract void DeleteAllMedicalNotesByDoctorId(Guid doctorId);
        public abstract void DeleteAllMedicalNotesOfPatient(Patient patient);
        public abstract void DeleteAllMedicalNotesOfPatientById(Guid patientId);
        public abstract void DeleteMedicalNote(MedicalNote medicalNote);
        public abstract void DeleteMedicalNoteById(Guid medicalNoteId);
        public abstract List<MedicalNote> GetAllMedicalNotes();
        public abstract List<MedicalNote> GetAllMedicalNotesByDoctor(Doctor doctor);
        public abstract List<MedicalNote> GetAllMedicalNotesByDoctorId(Guid doctorId);
        public abstract List<MedicalNote> GetAllMedicalNotesOfPatient(Patient patient);
        public abstract List<MedicalNote> GetAllMedicalNotesOfPatientId(Guid patientId);
        public abstract MedicalNote GetMedicalNoteByAppointment(Appointment appointment);
        public abstract MedicalNote GetMedicalNoteByAppointmentId(Guid appointmentId);
        public abstract MedicalNote GetMedicalNoteById(Guid medicalNoteId);
        public abstract void UpdateMedicalNote(MedicalNote medicalNote);
        public abstract void UpdateMedicalNoteById(Guid medicalNoteId, MedicalNote medicalNote);
        public abstract void UpdateMedicalNotes(List<MedicalNote> medicalNotes);
    }
}
