using DesktopApplication.Model.Healthcare;
using DesktopApplication.Model.Supplies;

namespace DesktopApplication.Model.Database {
    public abstract class DBHMedication : IDBHandlerMedication {
        public abstract Medication AddMedication(Medication medication);
        public abstract void DeleteMedication(Medication Medication);
        public abstract void DeleteMedicationById(Guid medicationId);
        public abstract List<Medication> GetAllMedications();
        public abstract List<Medication> GetAllMedicationsOfPatient(Patient patient);
        public abstract List<Medication> GetAllMedicationsOfPatientById(Guid patientId);
        public abstract Medication GetMedicationById(Guid medicationId);
        public abstract void UpdateMedication(Medication Medication);
        public abstract void UpdateMedicationById(Guid medicationId, Medication Medication);
    }
}
