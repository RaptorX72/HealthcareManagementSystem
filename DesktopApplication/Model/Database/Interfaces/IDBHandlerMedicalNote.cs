using DesktopApplication.Model.Healthcare;
using DesktopApplication.Model.Management;

namespace DesktopApplication.Model.Database {
    public interface IDBHandlerMedicalNote {
        public MedicalNote AddMedicalNote(MedicalNote mediicalNote);

        public List<MedicalNote> GetAllMedicalNotes();

        public MedicalNote GetMedicalNoteById(Guid medicalNoteId);

        public MedicalNote GetMedicalNoteByAppointmentId(Guid appointmentId);

        public MedicalNote GetMedicalNoteByAppointment(Appointment appointment);

        public void UpdateMedicalNoteById(Guid medicalNoteId, MedicalNote MedicalNote);

        public void UpdateMedicalNote(MedicalNote MedicalNote);

        public void UpdateMedicalNoteByAppointmentId(Guid appointmentId, MedicalNote MedicalNote);

        public void UpdateMedicalNoteByAppointment(Appointment appointment, MedicalNote MedicalNote);

        public void DeleteMedicalNoteById(Guid medicalNoteId);

        public void DeleteMedicalNote(MedicalNote MedicalNote);

        public void DeleteMedicalNoteByAppointmentId(Guid appointmentId);

        public void DeleteMedicalNoteByAppointment(Appointment appointment);

        #region GetAll
        public List<MedicalNote> GetAllMedicalNotesByDoctorId(Guid doctorId);

        public List<MedicalNote> GetAllMedicalNotesByDoctor(Doctor doctor);

        public List<MedicalNote> GetAllMedicalNotesOfPatientId(Guid patientId);

        public List<MedicalNote> GetAllMedicalNotesOfPatient(Patient patient);

        public List<MedicalNote> GetAllMedicalNotesByMedicalRecordId(Guid medicalRecordId);

        public List<MedicalNote> GetAllMedicalNotesByMedicalRecord(MedicalRecord medicalRecord);
        #endregion

        #region UpdateAll
        public void UpdateAllMedicalNotesByDoctorId(Guid doctorId, List<MedicalNote> MedicalNotes);

        public void UpdateAllMedicalNotesByDoctor(Doctor doctor, List<MedicalNote> MedicalNotes);

        public void UpdateAllMedicalNotesOfPatientById(Guid patientId, List<MedicalNote> MedicalNotes);

        public void UpdateAllMedicalNotesOfPatient(Patient patient, List<MedicalNote> MedicalNotes);

        public void UpdateAllMedicalNotesByMedicalRecordId(Guid medicalRecordId, List<MedicalNote> medicalNotes);

        public void UpdateAllMedicalNotesByMedicalRecord(MedicalRecord medicalRecord, List<MedicalNote> medicalNotes);
        #endregion

        #region DeleteAll
        public void DeleteAllMedicalNotesByDoctorId(Guid doctorId);

        public void DeleteAllMedicalNotesByDoctor(Doctor doctor);

        public void DeleteAllMedicalNotesOfPatientById(Guid patientId);

        public void DeleteAllMedicalNotesOfPatient(Patient patient);

        public void DeleteAllMedicalNotesByMedicalRecordId(Guid medicalRecordId);

        public void DeleteAllMedicalNotesByMedicalRecord(MedicalRecord medicalRecord);
        #endregion
    }
}
