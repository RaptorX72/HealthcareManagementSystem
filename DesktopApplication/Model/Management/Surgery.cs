namespace DesktopApplication.Model.Management {
    public class Surgery {
        #region fields
        public Guid Id { get; }

        public Guid AppointerDoctorId { get; }

        public Guid SurgeonDoctorId { get; }

        public Guid PatientId { get; }

        public DateTime Date { get; }

        public string Notes { get; }

        public SurgeryOutcome Outcome { get; }
        #endregion
        #region constructors
        public Surgery(
            Guid id, Guid appointerDoctorId, Guid surgeonDoctorId, Guid patientId,
            DateTime date, string notes, SurgeryOutcome outcome
            ) {
            Id = id;
            AppointerDoctorId = appointerDoctorId;
            SurgeonDoctorId = surgeonDoctorId;
            PatientId = patientId;
            Date = date;
            Notes = notes;
            Outcome = outcome;
        }
        #endregion
    }
}
