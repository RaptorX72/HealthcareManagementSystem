using DesktopApplication.Model.Healthcare;
using DesktopApplication.Model.Management;
using MySql.Data.MySqlClient;

namespace DesktopApplication.Model.Database {
    public class MySQLDBHMedicalNote : DBHMedicalNote {
        private MySqlConnection con;

        public MySQLDBHMedicalNote(MySqlConnection con) {
            this.con = con;
        }

        public override MedicalNote AddMedicalNote(MedicalNote mediicalNote) {
            throw new NotImplementedException();
        }

        public override void DeleteAllMedicalNotesByDoctor(Doctor doctor) {
            throw new NotImplementedException();
        }

        public override void DeleteAllMedicalNotesByDoctorId(Guid doctorId) {
            throw new NotImplementedException();
        }

        public override void DeleteAllMedicalNotesByMedicalRecord(MedicalRecord medicalRecord) {
            throw new NotImplementedException();
        }

        public override void DeleteAllMedicalNotesByMedicalRecordId(Guid medicalRecordId) {
            throw new NotImplementedException();
        }

        public override void DeleteAllMedicalNotesOfPatient(Patient patient) {
            throw new NotImplementedException();
        }

        public override void DeleteAllMedicalNotesOfPatientById(Guid patientId) {
            throw new NotImplementedException();
        }

        public override void DeleteMedicalNote(MedicalNote MedicalNote) {
            throw new NotImplementedException();
        }

        public override void DeleteMedicalNoteByAppointment(Appointment appointment) {
            throw new NotImplementedException();
        }

        public override void DeleteMedicalNoteByAppointmentId(Guid appointmentId) {
            throw new NotImplementedException();
        }

        public override void DeleteMedicalNoteById(Guid medicalNoteId) {
            throw new NotImplementedException();
        }

        public override List<MedicalNote> GetAllMedicalNotes() {
            throw new NotImplementedException();
        }

        public override List<MedicalNote> GetAllMedicalNotesByDoctor(Doctor doctor) {
            throw new NotImplementedException();
        }

        public override List<MedicalNote> GetAllMedicalNotesByDoctorId(Guid doctorId) {
            throw new NotImplementedException();
        }

        public override List<MedicalNote> GetAllMedicalNotesByMedicalRecord(MedicalRecord medicalRecord) {
            throw new NotImplementedException();
        }

        public override List<MedicalNote> GetAllMedicalNotesByMedicalRecordId(Guid medicalRecordId) {
            throw new NotImplementedException();
        }

        public override List<MedicalNote> GetAllMedicalNotesOfPatient(Patient patient) {
            throw new NotImplementedException();
        }

        public override List<MedicalNote> GetAllMedicalNotesOfPatientId(Guid patientId) {
            throw new NotImplementedException();
        }

        public override MedicalNote GetMedicalNoteByAppointment(Appointment appointment) {
            throw new NotImplementedException();
        }

        public override MedicalNote GetMedicalNoteByAppointmentId(Guid appointmentId) {
            throw new NotImplementedException();
        }

        public override MedicalNote GetMedicalNoteById(Guid medicalNoteId) {
            throw new NotImplementedException();
        }

        public override void UpdateAllMedicalNotesByDoctor(Doctor doctor, List<MedicalNote> MedicalNotes) {
            throw new NotImplementedException();
        }

        public override void UpdateAllMedicalNotesByDoctorId(Guid doctorId, List<MedicalNote> MedicalNotes) {
            throw new NotImplementedException();
        }

        public override void UpdateAllMedicalNotesByMedicalRecord(MedicalRecord medicalRecord, List<MedicalNote> medicalNotes) {
            throw new NotImplementedException();
        }

        public override void UpdateAllMedicalNotesByMedicalRecordId(Guid medicalRecordId, List<MedicalNote> medicalNotes) {
            throw new NotImplementedException();
        }

        public override void UpdateAllMedicalNotesOfPatient(Patient patient, List<MedicalNote> MedicalNotes) {
            throw new NotImplementedException();
        }

        public override void UpdateAllMedicalNotesOfPatientById(Guid patientId, List<MedicalNote> MedicalNotes) {
            throw new NotImplementedException();
        }

        public override void UpdateMedicalNote(MedicalNote MedicalNote) {
            throw new NotImplementedException();
        }

        public override void UpdateMedicalNoteByAppointment(Appointment appointment, MedicalNote MedicalNote) {
            throw new NotImplementedException();
        }

        public override void UpdateMedicalNoteByAppointmentId(Guid appointmentId, MedicalNote MedicalNote) {
            throw new NotImplementedException();
        }

        public override void UpdateMedicalNoteById(Guid medicalNoteId, MedicalNote MedicalNote) {
            throw new NotImplementedException();
        }
    }
}
