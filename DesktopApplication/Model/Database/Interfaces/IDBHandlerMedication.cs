using DesktopApplication.Model.Healthcare;
using DesktopApplication.Model.Supplies;

namespace DesktopApplication.Model.Database {
    public interface IDBHandlerMedication {
        public Medication AddMedication(Medication medication);

        public List<Medication> GetAllMedications();

        public Medication GetMedicationById(Guid medicationId);

        public void UpdateMedicationById(Guid medicationId, Medication Medication);

        public void UpdateMedication(Medication Medication);

        public void DeleteMedicationById(Guid medicationId);

        public void DeleteMedication(Medication Medication);

        public List<Medication> GetAllMedicationsOfPatientById(Guid patientId);

        public List<Medication> GetAllMedicationsOfPatient(Patient patient);
    }
}