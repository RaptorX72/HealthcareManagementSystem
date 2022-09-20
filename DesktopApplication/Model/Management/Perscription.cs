using DesktopApplication.Model.Supplies;
namespace DesktopApplication.Model.Management {
    public class Perscription {
        #region fields
        public Guid Id { get; }
        
        public Guid PatientId { get; }

        public Guid DoctorId { get; }

        public Medication Medication { get; }

        public string Note { get; }

        public static Perscription Empty { get { return new Perscription(Guid.Empty, Guid.Empty, Medication.Empty, String.Empty); } }
        #endregion

        #region constructors
        public Perscription(Guid id, Guid patientId, Guid doctorId, Medication medication, string note) {
            Id = id;
            PatientId = patientId;
            DoctorId = doctorId;
            Medication = medication;
            Note = note;
        }

        public Perscription(Guid patientId, Guid doctorId, Medication medication, string note) {
            Id = Guid.NewGuid();
            PatientId = patientId;
            DoctorId = doctorId;
            Medication = medication;
            Note = note;
        }
        #endregion
    }
}
