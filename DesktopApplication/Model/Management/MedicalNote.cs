namespace DesktopApplication.Model.Management {
    public class MedicalNote {
        #region fields
        public Guid Id { get; }

        public Guid? AppointmentId { get; }

        public string Note { get; }

        public static MedicalNote Empty { get { return new MedicalNote(Guid.Empty, Guid.Empty, String.Empty); } }
        #endregion

        #region constructors
        public MedicalNote(Guid id, Guid? appointmentId, string note) {
            Id = id;
            AppointmentId = appointmentId;
            Note = note;
        }

        public MedicalNote(Guid? appointmentId, string note) {
            Id = Guid.NewGuid();
            AppointmentId = appointmentId;
            Note = note;
        }
        #endregion
    }
}
