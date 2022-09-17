using DesktopApplication.Model.Healthcare;
using DesktopApplication.Model.Management;

namespace DesktopApplication.Model.Database {
    public abstract class DBHMedicalNote : IDBHandlerMedicalNote {
        public abstract MedicalNote AddMedicalNote(MedicalNote mediicalNote);
        public abstract void DeleteAllMedicalNotesByDoctor(Doctor doctor);
        public abstract void DeleteAllMedicalNotesByDoctorId(Guid doctorId);
        public abstract void DeleteAllMedicalNotesByMedicalRecord(MedicalRecord medicalRecord);
        public abstract void DeleteAllMedicalNotesByMedicalRecordId(Guid medicalRecordId);
        public abstract void DeleteAllMedicalNotesOfPatient(Patient patient);
        public abstract void DeleteAllMedicalNotesOfPatientById(Guid patientId);
        public abstract void DeleteMedicalNote(MedicalNote MedicalNote);
        public abstract void DeleteMedicalNoteByAppointment(Appointment appointment);
        public abstract void DeleteMedicalNoteByAppointmentId(Guid appointmentId);
        public abstract void DeleteMedicalNoteById(Guid medicalNoteId);
        public abstract List<MedicalNote> GetAllMedicalNotes();
        public abstract List<MedicalNote> GetAllMedicalNotesByDoctor(Doctor doctor);
        public abstract List<MedicalNote> GetAllMedicalNotesByDoctorId(Guid doctorId);
        public abstract List<MedicalNote> GetAllMedicalNotesByMedicalRecord(MedicalRecord medicalRecord);
        public abstract List<MedicalNote> GetAllMedicalNotesByMedicalRecordId(Guid medicalRecordId);
        public abstract List<MedicalNote> GetAllMedicalNotesOfPatient(Patient patient);
        public abstract List<MedicalNote> GetAllMedicalNotesOfPatientId(Guid patientId);
        public abstract MedicalNote GetMedicalNoteByAppointment(Appointment appointment);
        public abstract MedicalNote GetMedicalNoteByAppointmentId(Guid appointmentId);
        public abstract MedicalNote GetMedicalNoteById(Guid medicalNoteId);
        public abstract void UpdateAllMedicalNotesByDoctor(Doctor doctor, List<MedicalNote> MedicalNotes);
        public abstract void UpdateAllMedicalNotesByDoctorId(Guid doctorId, List<MedicalNote> MedicalNotes);
        public abstract void UpdateAllMedicalNotesByMedicalRecord(MedicalRecord medicalRecord, List<MedicalNote> medicalNotes);
        public abstract void UpdateAllMedicalNotesByMedicalRecordId(Guid medicalRecordId, List<MedicalNote> medicalNotes);
        public abstract void UpdateAllMedicalNotesOfPatient(Patient patient, List<MedicalNote> MedicalNotes);
        public abstract void UpdateAllMedicalNotesOfPatientById(Guid patientId, List<MedicalNote> MedicalNotes);
        public abstract void UpdateMedicalNote(MedicalNote MedicalNote);
        public abstract void UpdateMedicalNoteByAppointment(Appointment appointment, MedicalNote MedicalNote);
        public abstract void UpdateMedicalNoteByAppointmentId(Guid appointmentId, MedicalNote MedicalNote);
        public abstract void UpdateMedicalNoteById(Guid medicalNoteId, MedicalNote MedicalNote);
    }
}
