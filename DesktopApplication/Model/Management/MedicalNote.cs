namespace DesktopApplication.Model.Management {
    public class MedicalNote {
        #region fields
        public Guid Id { get; }

        public Guid? AppointmentId { get; }

        public string Note { get; }
        #endregion

        #region constructors
        public MedicalNote(Guid id, Guid? appointmentId, string note) {
            Id = id;
            AppointmentId = appointmentId;
            Note = note;
        }
        #endregion
    }
}
