namespace DesktopApplication.Model.Management {
    public class MedicalTest {
        #region fields
        public Guid Id { get; }

        public Guid DoctorId { get; }

        public Guid PatientId { get; }

        public MedicalTestType MedicalTestType { get; }

        public MedicalTestResult? Result { get; }
        #endregion

        #region constructors
        public MedicalTest(Guid id, Guid doctorId, Guid patientId, MedicalTestType medicalTestType, MedicalTestResult result) {
            Id = id;
            DoctorId = doctorId;
            PatientId = patientId;
            MedicalTestType = medicalTestType;
            Result = result;
        }
        #endregion
    }

    public class MedicalTestResult {
        #region fields
        public Guid Id { get; }

        public Guid MedicalTestId { get; }

        public string Note { get; }

        public List<Image>? Attachments { get; }
        #endregion
        #region constructors
        public MedicalTestResult(Guid id, Guid medicalTestId,  string note, List<Image>? attachments) {
            Id = id;
            MedicalTestId = medicalTestId;
            Note = note;
            Attachments = attachments;
            MedicalTestId = medicalTestId;
        }
        #endregion
    }
}
