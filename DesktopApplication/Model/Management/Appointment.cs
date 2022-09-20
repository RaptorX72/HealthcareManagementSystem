namespace DesktopApplication.Model.Management {
    public class Appointment {
        #region fields
        public Guid Id { get; }

        public DateTime Date { get; }

        public Guid DoctorId { get; }

        public Guid PatientId { get; }

        public string Notes { get; }

        public static Appointment Empty { get { return new Appointment(Guid.Empty, DateTime.MinValue, Guid.Empty, Guid.Empty, String.Empty); } }
        #endregion

        #region constructors
        public Appointment(Guid id, DateTime date, Guid doctorId, Guid patientId, string notes) {
            Id = id;
            Date = date;
            DoctorId = doctorId;
            PatientId = patientId;
            Notes = notes;
        }

        public Appointment(DateTime date, Guid doctorId, Guid patientId, string notes) {
            Id = Guid.NewGuid();
            Date = date;
            DoctorId = doctorId;
            PatientId = patientId;
            Notes = notes;
        }
        #endregion
    }
}
