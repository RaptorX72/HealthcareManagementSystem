using DesktopApplication.Model.Healthcare;
using DesktopApplication.Model.Supplies;
using MySql.Data.MySqlClient;

namespace DesktopApplication.Model.Database {
    public class MySQLDBHMedication : DBHMedication {
        private MySqlConnection con;

        public MySQLDBHMedication(DBConnectionInfo info) {
            con = CommonTools.CreateMySQLConnection(info);
        }

        public override Medication AddMedication(Medication medication) {
            throw new NotImplementedException();
        }

        public override void DeleteMedication(Medication Medication) {
            throw new NotImplementedException();
        }

        public override void DeleteMedicationById(Guid medicationId) {
            throw new NotImplementedException();
        }

        public override List<Medication> GetAllMedications() {
            throw new NotImplementedException();
        }

        public override List<Medication> GetAllMedicationsOfPatient(Patient patient) {
            throw new NotImplementedException();
        }

        public override List<Medication> GetAllMedicationsOfPatientById(Guid patientId) {
            throw new NotImplementedException();
        }

        public override Medication GetMedicationById(Guid medicationId) {
            throw new NotImplementedException();
        }

        public override void UpdateMedication(Medication Medication) {
            throw new NotImplementedException();
        }

        public override void UpdateMedicationById(Guid medicationId, Medication Medication) {
            throw new NotImplementedException();
        }
    }
}
