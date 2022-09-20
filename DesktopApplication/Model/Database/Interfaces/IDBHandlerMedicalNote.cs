using DesktopApplication.Model.Healthcare;
using DesktopApplication.Model.Management;

namespace DesktopApplication.Model.Database {
    public interface IDBHandlerMedicalNote {
        public MedicalNote AddMedicalNote(MedicalNote medicalNote);

        public List<MedicalNote> GetAllMedicalNotes();

        public MedicalNote GetMedicalNoteById(Guid medicalNoteId);

        public MedicalNote GetMedicalNoteByAppointmentId(Guid appointmentId);

        public MedicalNote GetMedicalNoteByAppointment(Appointment appointment);

        public void UpdateMedicalNoteById(Guid medicalNoteId, MedicalNote medicalNote);

        public void UpdateMedicalNote(MedicalNote medicalNote);

        public void DeleteMedicalNoteById(Guid medicalNoteId);

        public void DeleteMedicalNote(MedicalNote medicalNote);

        #region GetAll
        public List<MedicalNote> GetAllMedicalNotesByDoctorId(Guid doctorId);

        public List<MedicalNote> GetAllMedicalNotesByDoctor(Doctor doctor);

        public List<MedicalNote> GetAllMedicalNotesOfPatientId(Guid patientId);

        public List<MedicalNote> GetAllMedicalNotesOfPatient(Patient patient);
        #endregion

        #region UpdateAll
        public void UpdateMedicalNotes(List<MedicalNote> medicalNotes);
        #endregion

        #region DeleteAll
        public void DeleteAllMedicalNotesByDoctorId(Guid doctorId);

        public void DeleteAllMedicalNotesByDoctor(Doctor doctor);

        public void DeleteAllMedicalNotesOfPatientById(Guid patientId);

        public void DeleteAllMedicalNotesOfPatient(Patient patient);
        #endregion
    }
}
