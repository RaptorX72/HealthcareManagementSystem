namespace DesktopApplication.Model.Management {
    public class MedicalNote {
        #region fields
        public Guid Id { get; }

        public Guid PatientId { get; }

        public Guid DoctorId { get; }

        public Guid? AppointmentId { get; }

        public string Note { get; }
        #endregion
        #region constructors
        public MedicalNote(Guid id, Guid patientId, Guid doctorId, Guid? appointmentId, string note) {
            Id = id;
            PatientId = patientId;
            DoctorId = doctorId;
            AppointmentId = appointmentId;
            Note = note;
        }
        #endregion
    }
}
