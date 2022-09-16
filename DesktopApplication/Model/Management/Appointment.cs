namespace DesktopApplication.Model.Management {
    public class Appointment {
        #region fields
        public Guid Id { get; }

        public DateTime Date { get; }

        public Guid DoctorId { get; }

        public Guid PatientId { get; }

        public string Notes { get; }
        #endregion

        #region constructors
        public Appointment(Guid id, DateTime date, Guid doctorId, Guid patientId, string notes) {
            Id = id;
            Date = date;
            DoctorId = doctorId;
            PatientId = patientId;
            Notes = notes;
        }
        #endregion
    }
}
