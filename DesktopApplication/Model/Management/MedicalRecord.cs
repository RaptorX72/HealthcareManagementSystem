using DesktopApplication.Model.Supplies;

namespace DesktopApplication.Model.Management {
    public class MedicalRecord {
        #region fields
        public Guid Id { get; }

        public Guid PatientId { get; }

        public DateTime BirthDate { get; }

        public string Gender { get; }

        public BloodType BloodType { get; }

        public double Height { get; }

        public double Weight { get; }

        public List<Perscription> Perscriptions { get; }

        public List<MedicalNote> Notes { get; }
        #endregion

        #region constructors
        public MedicalRecord(
            Guid id, Guid patientId, DateTime birthDate,
            string gender, BloodType bloodType, double height,
            double weight, List<Perscription> perscriptions, List<MedicalNote> notes
            ) {
            Id = id;
            PatientId = patientId;
            BirthDate = birthDate;
            Gender = gender;
            BloodType = bloodType;
            Height = height;
            Weight = weight;
            Perscriptions = perscriptions;
            Notes = notes;
        }
        #endregion
    }
}
